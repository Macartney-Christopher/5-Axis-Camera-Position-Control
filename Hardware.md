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
To simulate more realistically the controls of the steppers I chose to use Universal G-Code Sender with the CNC Shield.

grbl to arduino
geany C# 
using gcode (making visual paths, enter lines)

## Using a Custom PCB
