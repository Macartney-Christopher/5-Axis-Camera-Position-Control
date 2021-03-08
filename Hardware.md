# HARDWARE

The final objective for the Camera is to control it via Bluetooth with the given code using the custom PCB.


## CNC Shield: Driving Steppers Directly

With the mechanical parts fully assembled, the Camera system needed to be tested. To mitigate any issues that could arise from code and wiring, I chose to drive the stepper directly using a CNC Shield through Arduino.
	
```
const int stepXPin = 2; //X.STEP
 const int dirXPin = 5; // X.DIR
 void setup() {
 // Sets the two pins as Outputs
 pinMode(stepXPin,OUTPUT); 
 pinMode(dirXPin,OUTPUT);
 }
 void loop() {
 digitalWrite(dirXPin,HIGH); // Enables the motor to move in a particular direction
 // Makes 200 pulses for making one full cycle rotation
 for(int x = 0; x < 1000; x++) {
 digitalWrite(stepXPin,HIGH); 
 delayMicroseconds(500); 
 digitalWrite(stepXPin,LOW); 
 delayMicroseconds(500); 
 }
 delay(1000); // One second delay
 
 digitalWrite(dirXPin,LOW); //Changes the rotations direction

 // Makes 400 pulses for making two full cycle rotation
 for(int x = 0; x < 400; x++) {
 digitalWrite(stepXPin,HIGH);
 delayMicroseconds(500);
 digitalWrite(stepXPin,LOW);
 delayMicroseconds(500);
 }
 delay(1000);
 }
```

## CNC Shield: Driving Steppers with Universal G-Code Sender (UGS)
To realistically simulate the controls of the steppers I chose to use Universal G-Code Sender with the CNC Shield. 
1. Upload Grbl source code to the Arduino Uno: https://github.com/grbl/grbl/blob/master/grbl/examples/grblUpload/grblUpload.ino.
2. Download Universal G-Code Sender and connect your Arduino Uno.
3. Setup stepper motors and drivers to CNC shield.
4. Press connect on the top corner and ensure the Arduino Uno is connected.
5. Begin messing around.
 
Using UGS for the camera position control was not ideal because I had to enter the G commands manually everytime. It is an issue because the three core motors don't move the body in cartesian axes. Two motors rotate the body on its own axes and one moves along the x axis. Moreover, the two motors also have a gear ratio which don't represent the rotation of the body 1:1 with the motors. A few solutions came to mind:
- Draw what the motors would do in cartesian coordinates and convert to G commands.
- Write code to enter the desired angles of the camera and output the G commands.

The first option is an interesting idea because the user could visually see the sequence of motor actuation. The biggest issue is being able to constantly convert to cartesions as the user draws on two of three axes. 


grbl to arduino
geany C# 
using gcode (making visual paths, enter lines)

## Using a Custom PCB
