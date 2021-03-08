# 5-Axis-Camera-Position-Control
  What I call the "Tasmanian Devil" is a 5-axis camera position control system to get all the video shots you can think of. The entire design is an extension from Isaac879 who did camera rig with three axes, and a shutter control. Using Isaac879's available pinouts and step files, his design was modified to account for focus and zoom control 


## Mechanical
### Adaptable mount to most DSLR cameras and lenses
  - Design 1: Extendable Camera Mount
    -Motive: Possibility that a camera will not fit
      - Allows a snug fit for any camera
      -	Reduces possibility for camera to rotate on center screw
      -	Required additional sliding mechanisms
      -	Involved too little rigidity in the system
  - Design 2: Freedom of Screw Position & Larger Mount
    -Motive: Not enough options for camera position
      -	Allows fit for all current and future DSLRs
      -	Allows for lateral and longitudinal positioning of camera
      -	Allows for optimal position of center of mass
      -	Possibility of camera rotation (mitigated by tightness 

    ##### Design 2 outweighed Design 1
    ![image](https://user-images.githubusercontent.com/59852573/110351632-0a3d9f80-8003-11eb-894d-47ed1a3b9d3a.png)

### Adjustable tightness to sliding rail
  - Design 1: Spring Loaded Wheel Shaft (4 wheels total)
    - Motive: Consistent Fitment to Rail 
      - Allows for simple setup
      - Requires strong springs in compression
      - Not mechanically reliable
  - Design 2: Eccentric Screw (3 wheels total)
    - Motive: More efficient design solution
      - Uses less wheels
      -	Allows for higher mechanical reliability
      -	Allows for desired tightness using tools
      -	3D printable

    ##### Design 2 outweighed Design 1
    ![image](https://user-images.githubusercontent.com/59852573/110356542-5e974e00-8008-11eb-9604-2b08a7cf43be.png)
    
### Additional stepper motors and adjustability for focus & zoom
  - Design 1: Motors attached on the camera mount and adjustable
    - Motive: Fixed on the path of the camera
      -	Allows adjustability of both axes (focus & zoom)
      -	Proximity to lens
      -	Collides with the board and wiring in all optimal camera shots
  - Design 2: Motors attached to the external flash unit of the camera
    - Motive: Fixed on the path of the camera
      -	Allows adjustability of both axes (focus & zoom)
      -	Proximity to lens
      -	Only collides with board if camera is upside-down (unlikely)
      -	Gravity helps prevent any skipping of the gears because they are above the lens

	  ##### Design 2 outweighed Design 1
	

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


