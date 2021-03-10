# Hardware

&nbsp;&nbsp;&nbsp;The final objective for the Camera is to control it via Bluetooth with the given code using the custom PCB.


## CNC Shield: Driving Steppers Directly

&nbsp;&nbsp;&nbsp;With the mechanical parts fully assembled, the Camera system needed to be tested. Before this project I never touched a stepper motor. To mitigate any issues that could arise from code and wiring, I chose to drive the stepper directly using a CNC Shield through Arduino. [Find code here](CNC_Shield_Direct_Drive.ino).

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

&nbsp;&nbsp;&nbsp;The C# program asks for angle of tilting and panning, and the distance of slider travel. It gives in return two G commands, the first to set the initial position and the second to execute the desired move.
[Watch an example video on Youtube](https://youtu.be/lNg3zl9IBe4).

## Using a Custom PCB
&nbsp;&nbsp;&nbsp;Isaac879 includes the files and the component list to build the PCB in his repository. After soldering the components to the board we can begin testing.
*Note: The final objective is to have five total stepper motors, two more than what the PCB accounts for.*

##### Soldering
&nbsp;&nbsp;&nbsp;The only challenge wben soldering is keeping the headers in the upright position while soldering on the opposite side. This project upgrade accounts 3x hall sensors wired to headers, 8x 7-10cm M-M wires, and 2x 7-10cm M-M split wires.
### Nano Compatibility
#### Using an Arduino Nano 
&nbsp;&nbsp;&nbsp;Isaac879 uses the just about the entire static and dynamic memory available on an Arduino Nano to complete his project. The PCB worked when adding the Nano to the PCB and uploading isaac879's original code.

##### Problem
&nbsp;&nbsp;&nbsp;Initializing the two additional steppers with AccelStepper quickly took up memory in the Nano. The code took 107% capacity only with initilization. Removing functions that were not critical, such as all that would operate the camera shutter, was still not enough. An alternative board was necessary.

##### Solution
&nbsp;&nbsp;&nbsp;The Arduino Nano 33 BLE to solves the memory issue. Moreover, the board had CPU Flash Memory which replaces the EEPROM.

#### Using an Arduino Nano 33 BLE
&nbsp;&nbsp;&nbsp;With the Arduino Nano 33 BLE there's plenty of memory to initialize all five stepper motors. The integrated bluetooth on this Nano made the Bluetooth header on the PCB available.

##### Problem
&nbsp;&nbsp;&nbsp;When changing the EEPROM code to Flash Storage the same an architecture error came up:
![image](https://user-images.githubusercontent.com/59852573/110384195-4edd3100-802b-11eb-953d-3ee4fa40a7a4.png)
The architecture of the CPU is not compatible with FlashStorage library. The workarounds with the same board aer complex and require extensive knowledge of CPU architecture.

##### Solution
&nbsp;&nbsp;&nbsp;Finally, the Arduino Nano 33 IoT doesn't present any compilation issues and worked great.

#### Using an Arduino Nano 33 IoT
&nbsp;&nbsp;&nbsp;With the Arduino Nano 33 IoT everything was compiling perfectly. There was enough memory and the correct architecture for the FlashStorage library.

### Finding PCB Pinouts
&nbsp;&nbsp;&nbsp;Adding two more steppers is critical for the project. There are eight free pins on the PCB that can be used for digital signals: D0 (RX), D1 (TX), D2, D13, A1, A2, A6, and A7. Pins 0 and 1, and pin 2 on H1 belong to the camera trigger and a hall sensor respectively. The camera trigger is not necessary for this project, the fourth hall sensor does not add value to this project.
Thankfully the 28BYJ-48 stepper motors and their respective ULN2003 drivers only require four digital pins. The eight pins are perfect for the two small stepper motors.

### Modifying the PCB

Finding the correct motors (not too big, not many pins, enough torque)
Using free pinouts for two additional steppers (add screenshot of layout with available pins);
Shorting R1
Shorting A1 and removing R5
Adding wires to small stepper drivers
Wire from Nano Vin to H3 power
Wire from Nano 3.3V to P2 5V
Cutting 5V supply from H1 through the P1 because the nano 33 iot can only output 3.3V. Short 5V supply  to H1

had to sacrifice the camera shutter trigger function to use the pinout
