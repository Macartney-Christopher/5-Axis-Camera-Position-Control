# Software

## Getting Familiar
&nbsp;&nbsp;&nbsp;In total there are over 2500 lines of code. The best way to approach it is to get familiar with each library and then the functions in the code.
The AccelStepper and MultiStepper libraries are complimentary, often one used together. [Isaac879](https://github.com/isaac879/Pan-Tilt-Mount) uses EEPROM to store values while the system is off.

## Obstacles
### EEPROM & FlashStorage
&nbsp;&nbsp;&nbsp;When changing from the Nano to the Nano 33 BLE and the Nano 33 IoT there's a complete loss of EEPROM. That issue was mitigated by including the FlashStorage library.
FlashStorage is more reliable than EEPROM. If the Nano was reset then none of the functions would function because the EEPROM values were uninitialized. With the Nano 33 IoT and FlashStorage there is still functionality even when reset.

### Adding 2 Stepper Motors
&nbsp;&nbsp;&nbsp;When initializing the 2 additional motors in the code using AccelStepper, ensure the other functions are not affected. Each function is modified by increasing data arrays, increasing function inputs/outputs, and adding functions and variables to integrate the extra motors.

&nbsp;&nbsp;&nbsp;It's simple to implement the functions and variables because they follow the same structure as the native code. Ensuring the initial values are correct for the system's parameters requires empirical testing based on visual results.

&nbsp;&nbsp;&nbsp;Increasing the arrays and the function inputs can cause other issues in the call sequence. Three motors have a home (neutral) position based on hall effect sensors although the two additional motors do not. When adding the motors to ```findHome()``` they weren't included with the hall sensing section because hall sensors were not added alongside the two motors.

### Driving CPU Port Directly
&nbsp;&nbsp;&nbsp;[Isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s implements a function that interacts the microcontroller ports directly to set the step mode on their TMC2208 drivers. For example, to set the step mode to 1/16:
```c++
if(newMode == SIXTEENTH_STEP){
        PORTB |= B00001100; //MS1 and MS2 high
}
```
&nbsp;&nbsp;&nbsp;The above indicates to set the 3rd and 4th B ports to high and keeping all other low. The reason for this syntax is efficiency, it sets the MS1 and MS2 pins to high directly instead of going through a complementary function. For a maker it's easier to understand the following:
```c++
if(newMode == SIXTEENTH_STEP){
	digitalWrite(PIN_MS1, HIGH);
	digitalWrite(PIN_MS2, HIGH);
}
```
&nbsp;&nbsp;&nbsp;For a comprehensive look at this, here are the pinouts of the CPU on the Nano:

<img src="https://user-images.githubusercontent.com/59852573/110517405-d2089080-80d8-11eb-86dc-c39aba4eb1f4.png" alt="drawing" width="350"/>

&nbsp;&nbsp;&nbsp;As seen above, there are eight B Ports which correspond to the 8 digits in the code. Despite how efficient it is for the regular Nano, the Nano 33 IoT is faster and the code could be simplified using digitalWrite().

### Bit Manipulation - Bluetooth Implementation
&nbsp;&nbsp;&nbsp;Sending the commands from the controller involves sending a character array. The information is allocated in the array as such:
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
&nbsp;&nbsp;&nbsp;The data was not receiving properly with the Nano 33 IoT. After further testing, all the ```int```'s had to be changed to ```int16_t```'s to explicitly convert it to a 16 bit integer. That is due to the Nano 33 IoT being configured slightly differently than the Nano.

### Adding Multi-Button Functions
&nbsp;&nbsp;&nbsp;Isaac879 can get the state of the Xbox Controller buttons using, for example:
```c++
if ((lastwButtons & UP_BUTTON) < (state.Gamepad.wButtons & UP_BUTTON))
```
&nbsp;&nbsp;&nbsp;The above simply checks if the last button pressed corresponds to the Up button on the D-Pad.
&nbsp;&nbsp;&nbsp;To add a multi-button function there  needs to be a toggle button which allows the user to use other buttons for different actions.
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
&nbsp;&nbsp;&nbsp;Any user of the camera rig should be able to click on a few buttons to have the system ready without going into code. The solution to this is batch files:
For this project the user only needs a connection from the gaming controller to the Arduino Nano 33 IoT and a document to explain the command functions.
From one batch file there is no way to simoultaneously run/open code and a pdf. One needs to be closed for the other to open. 
A simple work-around is to integrate two seperate ```.bat``` files into a master batch file:
```bat
@ECHO OFF
start Xbox_Controller_Connection.bat 	rem Connects the Xbox controller to the Arduino Nano 33 IoT.
start Xbox_Controller_Commands.bat 	rem Shows Xbox controller commands to the user.
PAUSE
```
