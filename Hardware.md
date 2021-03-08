# Hardware

The final objective for the Camera is to control it via Bluetooth with the given code using the custom PCB.


## CNC Shield: Driving Steppers Directly

With the mechanical parts fully assembled, the Camera system needed to be tested. Before this project I never touched a stepper motor. To mitigate any issues that could arise from code and wiring, I chose to drive the stepper directly using a CNC Shield through Arduino. [Find code here](CNC_Shield_Direct_Drive.ino).

## CNC Shield: Driving Steppers with Universal G-Code Sender (UGS)
To realistically simulate the controls of the steppers I chose to use Universal G-Code Sender with the CNC Shield. 
1. Upload Grbl source code to the Arduino Uno [here on Github](https://github.com/grbl/grbl/blob/master/grbl/examples/grblUpload/grblUpload.ino).
2. Download Universal G-Code Sender and connect your Arduino Uno.
3. Setup stepper motors and drivers to CNC shield.
4. Press connect on the top corner and ensure the Arduino Uno is connected.
5. Begin messing around.
 
#### Problem 
Using UGS for the camera position control was not ideal because I had to enter the G commands manually everytime. It is an issue because the three core motors don't move the body in cartesian axes. Two motors rotate the body on its own axes and one moves along the x axis. Moreover, the two motors also have a gear ratio which don't represent the rotation of the body 1:1 with the motors. 

#### Solution
1. Draw what the motors would do in cartesian coordinates and convert to G commands.
	This is an interesting idea because the user could visually see the sequence of motor actuation. The biggest issue is being able to constantly convert to cartesions as the user draws on two of three axes. 
2. Write code to enter the desired angles of the camera and output the G commands.
	This idea is feasible and both ends of the blackbox make sense for the user. [See C# code here](GCode_Maker.cs).

The C# program asks for angle of tilting and panning, and the distance of slider travel. It gives in return two G commands, the first to set the initial position and the second to execute the desired move.
[Watch an example video on Youtube](https://youtu.be/lNg3zl9IBe4).

## Using a Custom PCB
In Isaac879's project he kindly includes the files and the component list to build the PCB. I started soldering immediately when they came in.


preface by saying the final goal is to have two additional motors

#### Soldering
It was my first time soldering components onto a PCB. The only challenge was keeping headers in the upright position while I soldered on the opposite side.
MENTION HALL SENSORS

### Using an Arduino Nano 
Isaac879 uses an Arduino Nano to complete his project. That is a great solution for what he needed. He used almost the entire static and dynamic memory of the Nano. 
To test the PCB I plugged in the Nano and uploaded Isaac879's code. It worked great.
#### Problem
When initialized the two other steppers with AccelStepper it quickly took up memory and I was at 107% capacity only with initilization. I removed a couple functions in the code that I did not need, such as all the functions that would operate the camera shutter. **It still was not enough memory so I looked at alternative boards.**

#### Solution
My colleague chose the Arduino Nano 33 BLE to solve the memory issue. The board had CPU Flash Memory which replaced the EEPROM.

### Using an Arduino Nano 33 BLE
With the Arduino Nano 33 BLE there was plenty of memory to initialize all five stepper motors. The integrated bluetooth on this Nano allowed me to remove the bluetooth header on the PCB
#### Problem
When changing the EEPROM code to Flash Storage I kept getting an architecture error:
![image](https://user-images.githubusercontent.com/59852573/110384195-4edd3100-802b-11eb-953d-3ee4fa40a7a4.png)
After further research it was the architecture of the CPU that was not compatible with the FlashStorage library. The workarounds were complex and required extensive knowledge of CPU architecture.
#### Solution
Finally, we chose to move to the Arduino Nano 33 IoT which didn't present any issues.

### Using an Arduino Nano 33 IoT
With the Arduino Nano 33 IoT everything was compiling perfectly. There was enough memory and the correct architecture for the FlashStorage library.


Finding the correct motors (not too big, not many pins, enough torque)
Using free pinouts for two additional steppers (add screenshot of layout with available pins);
Shorting R1
Shorting A1 and removing R5
Adding wires to small stepper drivers
Wire from Nano Vin to H3 power
Wire from Nano 3.3V to P2 5V
Cutting 5V supply from H1 through the P1 because the nano 33 iot can only output 3.3V. Short 5V supply  to H1

had to sacrifice the camera shutter trigger function to use the pinout
