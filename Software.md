# Software

## Getting Familiar
In total there are over 2000 lines of code. I found the best way to approach it was to get familiar with each library and then the functions in the code.
The AccelStepper and MultiStepper libraries are complimentary, often one will be used with the other.
INSERT SCREENSHOT OF CODE


## EEPROM & FlashStorage


## Adding 2 Stepper Motors
When initializing the 2 additional motors in the code using AccelStepper I had to make sure none of the other functions were affected. This involved going through every function and increasing data arrays, modifying function inputs/outputs, and adding functions and variables .
It was simple to implement the functions and variables because they followed the same structure as the native code. Ensuring the initial value for the variables required a lot of empirical testing based on visual results of the motor actuation.
I was careful when increasing the arrays and the function inputs. Three motors have a home (neutral) position found by hall effect sensors although the two additional motors do not. When adding the motors to ```findHome()``` I didn't include them with the hall sensing section. Otherwise the two additional motors would continuously rotate.

## Driving CPU Port Directly
Isaac879's implements a function that drives the microcontroller directly.

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


## Bit Manipulation
