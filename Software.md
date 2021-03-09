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
Isaac879's implements a function that drives the microcontroller directly. Despite how efficient it was, the Nano 33 IoT was faster and the code could be simplified.
![image](https://user-images.githubusercontent.com/59852573/110512443-332d6580-80d3-11eb-8be2-3b00ec9f609d.png)
### Arduino Nano Microcontroller Ports 
PORTB

## Bit Manipulation
