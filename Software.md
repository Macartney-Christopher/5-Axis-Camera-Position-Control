# Software

## Getting Familiar
&nbsp;&nbsp;&nbsp;In total there are over 2000 lines of code. The best way to approach it is to get familiar with each library and then the functions in the code.
The AccelStepper and MultiStepper libraries are complimentary, often one used together. [Isaac879](https://github.com/isaac879/Pan-Tilt-Mount) uses EEPROM to store values while the system is off.

## Obstacles
### EEPROM & FlashStorage
&nbsp;&nbsp;&nbsp;When changing from the Nano to the Nano 33 BLE and the Nano 33 IoT there's a complete loss of EEPROM. That issue was mitigated by including the FlashStorage library.
FlashStorage is more reliable than EEPROM. If the Nano was reset then none of the functions would function because the EEPROM values were uninitialized. With the Nano 33 IoT and FlashStorage there is still functionality even when reset.

### Adding 2 Stepper Motors
&nbsp;&nbsp;&nbsp;When initializing the 2 additional motors in the code using AccelStepper ensure the other functions are not affected. Each function is modified by increasing data arrays, modifying function inputs/outputs, and adding functions and variables.

&nbsp;&nbsp;&nbsp;It's simple to implement the functions and variables because they follow the same structure as the native code. Ensuring the initial values are correct for the system's parameters requires a lot of empirical testing based on visual results of the motor actuation.

&nbsp;&nbsp;&nbsp;Increasing the arrays and the function inputs can cause other issues in the call sequence. Three motors have a home (neutral) position based on hall effect sensors although the two additional motors do not. When adding the motors to ```findHome()``` they weren't included with the hall sensing section or else the two additional motors would continuously rotate attempting to find a home position.

### Driving CPU Port Directly
&nbsp;&nbsp;&nbsp;[Isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s implements a function that drives the microcontroller directly to set the step mode on their TMC2208 drivers.

##### Arduino Nano Microcontroller Ports
<img src="https://user-images.githubusercontent.com/59852573/110517405-d2089080-80d8-11eb-86dc-c39aba4eb1f4.png" alt="drawing" width="350"/>
&nbsp;&nbsp;&nbsp;As shown below, PORTB is used yet undeclared in the entire code. Moreover, no results come up when searching for PORTB.

```c++
if(newMode == HALF_STEP){
        PORTB |=   B00001000; //MS1 high
        PORTB &= ~(B00000100); //MS2 low 
    }
    else if(newMode == QUARTER_STEP){
        PORTB |=   B00000100; //MS2 high
        PORTB &= ~(B00001000); //MS1 low
    }
    else if(newMode == EIGHTH_STEP){
        PORTB &= ~(B00001100); //MS1 and MS2 low
    }
    else if(newMode == SIXTEENTH_STEP){
        PORTB |= B00001100; //MS1 and MS2 high
    }
```
&nbsp;&nbsp;&nbsp;Here, isaac879 uses the microcontroller ports directly. As seen above, there are eight B Ports which correspond to the 8 digits in the code. Despite how efficient it is for the regular Nano, the Nano 33 IoT is faster and the code could be simplified using digitalWrite().

### Bit Manipulation - Bluetooth Implementation
&nbsp;&nbsp;&nbsp;Sending the commands from the controller involves sending a character array. The information is allocated in the array like the following:
```c++
int sendSliderPanTiltStepSpeed(int command, short* arr) {
	char data[11]; //Data array to send

	data[0] = command;
	data[1] = (arr[0] >> 8) & 0xFF; //Gets the most significant byte
	data[2] = arr[0] & 0xFF; //Gets the second most significant byte
	data[3] = (arr[1] >> 8) & 0xFF;
	....
	data[9] = (arr[4] >> 8) & 0xFF;
	data[10] = arr[4] & 0xFF; //Gets the least significant byte

	serialWrite(data, sizeof(data)); //Send the command and the 10 bytes of data
```
&nbsp;&nbsp;&nbsp;On the receiving end, in Arduino, the native code takes in the information by shifting 8 bits at a time:
```c++
    int sliderStepSpeed = (Serial.read() << 8) + Serial.read(); 
    int panStepSpeed = (Serial.read() << 8) + Serial.read(); 
    ...
    int zoomStepSpeed = (Serial.read() << 8) + Serial.read();
```       
&nbsp;&nbsp;&nbsp;The data was not receiving properly with the Nano 33 IoT. After further testing, all the ```int```'s had to be changed to ```int16_t```'s to explicitly convert it to a 16 bit integer. That would be due to the Nano 33 IoT being configured slightly differently than the Nano.

### Adding Multi-Button Functions
Isaac879 can get the state of the Xbox Controller buttons using, for example:
```c++
if ((lastwButtons & UP_BUTTON) < (state.Gamepad.wButtons & UP_BUTTON))
```
The above simply checks if the last button pressed corresponds to the Up button on the D-Pad.
To add a multi-button function there  needs to be a toggle button which allows the user to use other buttons for different actions.
Let us set the Y Button as the toggle button. When pressed we can switch a bool value:
```c++
if ((lastwButtons & Y_BUTTON) < (state.Gamepad.wButtons & Y_BUTTON)) { //if Y Button is pressed
	toggleButton = true;  					       //turn on the toggle feature
}
```
Now, when the Up Button is pressed there is one of two functions that gets called depending on the value of ```toggleButton```.
```c++
if ((lastwButtons & UP_BUTTON) < (state.Gamepad.wButtons & UP_BUTTON) && !toggleButton) { //when Y is NOT pressed the Up Button calls this function
...
}

if ((lastwButtons & UP_BUTTON) < (state.Gamepad.wButtons & UP_BUTTON) && toggleButton){ //when Y is pressed the Up Button calls this function
...
}
```
## Batch Files - Ease of use
nspb;nspb;nspb;Any user of the Camera Rig should be able to click on a few buttons to have the system ready. The solution to this is batch files:
For this project the user only needs a connection from the gaming controller to the Arduino Nano 33 IoT and a document to explain the command functions.
From one batch file there is no way to simoultaneously run/open code and a pdf. One needs to be closed for the other to open. 
A simple work-around is to integrate two seperate ```.bat``` files into a master batch file:
```bat
@ECHO OFF
start Xbox_Controller_Connection.bat 	rem Connects the Xbox controller to the Arduino Nano 33 IoT.
start Xbox_Controller_Commands.bat 	rem Shows Xbox controller commands to the user.
PAUSE
```
