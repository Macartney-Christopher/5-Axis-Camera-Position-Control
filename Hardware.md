# Hardware

&nbsp;&nbsp;&nbsp;The final objective for the camera is to control it via Bluetooth with the given code using the custom PCB. Keep in mind that this report is from a maker who didn't know what a stepper motor was before starting the project.

## CNC Shield: Driving Steppers Directly

&nbsp;&nbsp;&nbsp;With the mechanical parts fully assembled, the camera system needed to be tested. Driving the steppers directly using a CNC Shield through Arduino mitigates any issues that could arise from code and wiring. [Find code here](Iteration-Code/CNC_Shield_Direct_Drive.ino) .

## CNC Shield: Driving Steppers with Universal G-Code Sender (UGS)
Use Universal G-Code Sender with the CNC Shield to rapidly and realistically simulate the controls of the steppers. 
1. Upload Grbl source code to the Arduino Uno [here on Github](https://github.com/grbl/grbl/blob/master/grbl/examples/grblUpload/grblUpload.ino).
2. Download Universal G-Code Sender and connect your Arduino Uno.
3. Setup stepper motors and drivers to CNC shield.
4. Press connect on the top corner and ensure the Arduino Uno is connected.
5. You're done!
 
#### Problem 
&nbsp;&nbsp;&nbsp;Using UGS for the camera position control is not ideal because entering the G commands manually is tedious. The issue is that the three core motors don't move the body in cartesian axes. Two motors rotate the body around its center and one moves along the x axis. Moreover, the two motors also have a gear ratios which don't represent the rotation of the body 1:1 with the motors. 

#### Solution
1. Draw what the motors would do in cartesian coordinates and convert to G commands.
	This is an interesting idea because the user could visually see the sequence of motor actuation. The biggest issue is being able to constantly convert to cartesian coordinates as the user draws on two of three axes. 
2. Write code to enter the desired angles of the camera and output the G commands.
	This idea is feasible and both ends of the blackbox make sense for the user. [See C# code here](Iteration-Code/GCode_Maker.cs).

&nbsp;&nbsp;&nbsp;The C# program asks for angle of tilting and panning, and the distance of slider travel. It gives in return two G commands, the first to set the initial position and the second to execute the desired move.
[Watch an example video on Youtube](https://youtu.be/lNg3zl9IBe4).

## Using a Custom PCB
&nbsp;&nbsp;&nbsp;Isaac879 includes the files and the component list to build the PCB in his repository. After soldering the components to the board we can begin testing.
*Note: The final objective is to have five total stepper motors, two more than what the PCB accounts for.*

##### Soldering
&nbsp;&nbsp;&nbsp;The only challenge is keeping the headers in the upright position while soldering on the opposite side. Additionally, this project upgrade counts 3x hall sensors wired to headers, 8x 7-10cm F-F wires, and 2x 7-10cm F-F split wires.

### Nano Compatibility
#### Using an Arduino Nano 
&nbsp;&nbsp;&nbsp;Isaac879 uses almost the entire static and dynamic memory available on an Arduino Nano to complete his project. The PCB worked when adding the Nano to the PCB and uploading isaac879's original code.

##### Problem
&nbsp;&nbsp;&nbsp;Initializing the two additional steppers with AccelStepper quickly takes up memory in the Nano. The code takes up 107% capacity only with initilization. Removing functions that are not critical, such as all that operate the camera shutter, is still not enough. An alternative board is necessary.

##### Solution
&nbsp;&nbsp;&nbsp;The Arduino Nano 33 BLE solves the memory issue. Moreover, the board has CPU Flash Memory which replaces the EEPROM.

#### Using an Arduino Nano 33 BLE
&nbsp;&nbsp;&nbsp;With the Arduino Nano 33 BLE there's plenty of memory to initialize all five stepper motors. The integrated bluetooth on the Nano 33 BLE makes the Bluetooth header on the PCB available.

##### Problem
&nbsp;&nbsp;&nbsp; An architecture error comes up when changing the EEPROM to FlashStorage:
![image](https://user-images.githubusercontent.com/59852573/110384195-4edd3100-802b-11eb-953d-3ee4fa40a7a4.png)
The architecture of the CPU is not compatible with FlashStorage library. The workarounds with the same board are complex and require extensive knowledge of CPU architecture.

##### Solution
&nbsp;&nbsp;&nbsp;Finally, the Arduino Nano 33 IoT doesn't present any compilation issues and worked great.

#### Using an Arduino Nano 33 IoT
&nbsp;&nbsp;&nbsp;With the Arduino Nano 33 IoT everything compiles perfectly. There's enough memory and the correct architecture for the FlashStorage library.

### Finding PCB Pinouts
&nbsp;&nbsp;&nbsp;Adding two more steppers is critical for the project. There are eight free pins on the PCB that can be used for digital signals: D0 (RX), D1 (TX), D2, D13, A1, A2, A6, and A7. Pins 0 and 1, and pin 2 on H1 belong to the camera trigger and a hall sensor respectively. The camera trigger is not necessary for this project, the fourth hall sensor does not add value to this project.
Thankfully the 28BYJ-48 stepper motors and their respective ULN2003 drivers only require four digital pins. The eight pins are perfect for the two small stepper motors.

### Modifying the PCB
&nbsp;&nbsp;&nbsp;*Note: To implement the two additional steppers the camera shutter trigger function must be sacrificed to use its digital pinout.*<br/>
&nbsp;&nbsp;&nbsp;***Suggestion: To not lose the camera trigger function and make the setup cleaner it is suggested to improve on the PCB design and simply order it with the correct modifications as explained below.***

&nbsp;&nbsp;&nbsp;The first step to implement the additional stepper motors is to solder male headers on the free pinouts to connect the ULN2003 drivers. For pin A2 there is no free pinout on the PCB but soldering a wire with a female end straight underneath the Nano header works just as well. <br/>
&nbsp;&nbsp;&nbsp;Secondly, R1 and R5 must be shorted because their corresponding pins D0 (RX) and A1 pins are not being used for what the PCB intended. Ensure that the resistance is not part of the circuit at all or it will affect the digital signal to the stepper motor.  
&nbsp;&nbsp;&nbsp;The Nano 33 IoT only supplies 3.3V as opposed to 5V for the Nano. To supply enough power to the hall sensor on H1 cut with an knife the line to the 5V through-hole on H1. Then proceed to short from Vin on the Nano header to the 5V through-hole on H1.  
&nbsp;&nbsp;&nbsp;Finally, connect the 7-10cm wires from the digital pinouts to the ULN2003 drivers and the two split wires from the PCB ground and power to the two drivers. The wiring should look like the below.

## Connecting a Gaming Controller
&nbsp;&nbsp;&nbsp;The use of a gaming controller to control the system is a great addition. Issac879 uses an Xbox controller although there didn't seem to be an issue with using any other standard remote.
### Problem
&nbsp;&nbsp;&nbsp;After some attemps the serial port would not recognize any remote, whether it was USB or Bluetooth. All controllers used to use DirectInput to communicate games and programs. Windows then created XInput for so only Xbox controllers could be used with Xbox. 
&nbsp;&nbsp;&nbsp;Isaac879 uses XInput to connect the Xbox controller to the camera system which meant that the serial port issue was due to the controller not being Xbox. Either the code or the controller had to be changed. 

### Solution
#### Solution 1: 
&nbsp;&nbsp;&nbsp;By using an application called MogaSerial, the Moga Pro 2 on-hand acted as an XInput controller. It worked great for a couple days. Unfortunately, in February 2021, MogaSerial is still inconsistent and does not always connect to the Moga Pro 2. Despite the program not being supported by Windows, the maker [Zel-oz](https://github.com/Zel-os/MogaSerial) is still improving it.
#### Solution 2: 
&nbsp;&nbsp;&nbsp;Modifying the code to use DirectInput is the ideal solution but it is a complex task for any individual unfamiliar with this old Microsoft API.
#### Solution 3:
&nbsp;&nbsp;&nbsp;For reliability and timing it is better to purchase an Xbox controller if any of the previous solutions don't work but try them!
