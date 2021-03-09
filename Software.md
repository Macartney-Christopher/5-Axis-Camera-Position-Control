# Software

## Getting Familiar
   In total there are over 2000 lines of code. The best way to approach it is to get familiar with each library and then the functions in the code.
The AccelStepper and MultiStepper libraries are complimentary, often one will be used with the other. [Isaac879](https://github.com/isaac879/Pan-Tilt-Mount) uses EEPROM but was replaced by FlashStorage

## EEPROM & FlashStorage
   When changing from the Nano to the Nano 33 BLE and the Nano 33 IoT there was a complete loss of EEPROM. That issue was mitigated by including the FlashStorage library.
FlashStorage ended up being more reliable. If the Nano was reset then none of the functions would function because the EEPROM values were uninitialized. With the Nano 33 IoT and FlashStorage there is still functionality even when reset.

## Adding 2 Stepper Motors
   When initializing the 2 additional motors in the code using AccelStepper I made sure none of the other functions were affected. I went through each function to increase data arrays, modify function inputs/outputs, and add functions and variables .
   It's simple to implement the functions and variables because they follow the same structure as the native code. Ensuring the initial value for the variables requires a lot of empirical testing based on visual results of the motor actuation.
   I was careful when increasing the arrays and the function inputs. Three motors have a home (neutral) position based on hall effect sensors although the two additional motors do not. When adding the motors to ```findHome()``` I didn't include them with the hall sensing section or else the two additional motors would continuously rotate.

## Driving CPU Port Directly
[Isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s implements a function that drives the microcontroller directly.

#### Arduino Nano Microcontroller Ports
<img src="https://user-images.githubusercontent.com/59852573/110517405-d2089080-80d8-11eb-86dc-c39aba4eb1f4.png" alt="drawing" width="350"/>
For a beginner it is confusing to see PORTB undeclared and no immediate results come up on the internet:
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
    Here isaac879 uses the microcontroller ports directly. As seen above, there are eight B Ports which correspond to the 8 digits in the code.
Despite how efficient it was for the regular Nano, the Nano 33 IoT was faster and the code could be simplified.

## Bit Manipulation - Bluetooth Implementation
   Sending the commands from the controller involve sending a character array. The information is allocated in the array like the following:
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
   On the receiving end, in Arduino, the native code takes in the information by shifting 8 bits at a time:
```c++
    int sliderStepSpeed = (Serial.read() << 8) + Serial.read(); 
    int panStepSpeed = (Serial.read() << 8) + Serial.read(); 
    ...
    int zoomStepSpeed = (Serial.read() << 8) + Serial.read();
```       
   The data was not receiving properly with the Nano 33 IoT. After further testing, all the ```int```'s had to be changed to ```int16_t```'s to explicitly convert it to a 16 bit integer. 
