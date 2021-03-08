# 5-Axis-Camera-Position-Control
  What I call the "Tasmanian Devil" is a 5-axis camera position control system to get all the video shots you can think of. The entire design is an extension from Isaac879 who did camera rig with three axes, and a shutter control. Using Isaac879's available pinouts and step files, his design was modified to account for focus and zoom control 



	

## HARDWARE

The final objective for the Camera is to control it via Bluetooth with the given code using the custom PCB.


### CNC Shield: Driving Stepper Directly
	With the mechanical part put in place the Camera system needed to be tested. To mitigate any issues that could arise from code and wiring, I chose to drive the stepper directly using a CNC Shield.
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
### Using a Custom PCB


