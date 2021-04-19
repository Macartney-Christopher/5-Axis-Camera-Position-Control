# Mechanical
![image](https://user-images.githubusercontent.com/59852573/114465532-3bd2f900-9bb5-11eb-834a-06dfd75de625.png)

## Camera Mount Adaptability
  - Design 1: Extendable Camera Mount
    - Motive: Possibility that a camera will not fit
      - Allows a snug fit for any camera
      -	Reduces possibility for camera to rotate on center screw
      -	Required additional sliding mechanisms
      -	Involved too little rigidity in the system
  - Design 2: Freedom of Screw Position & Larger Mount
    - Motive: Not enough options for camera position
      -	Allows fit for all current and future DSLRs
      -	Allows for lateral and longitudinal positioning of camera
      -	Allows for optimal position of center of mass
      -	Possibility of camera rotation (mitigated by tightness 

    #### Design 2 outweighed Design 1
 <img src="https://user-images.githubusercontent.com/59852573/115062228-1812fa00-9eb8-11eb-8f24-fafb93f37250.png" alt="drawing" width="500"/>

## Slider Mount Tightening
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

    #### Design 2 outweighed Design 1
    <img src="https://user-images.githubusercontent.com/59852573/115077743-8f528900-9ecc-11eb-9502-9e0999e6e293.png" alt="drawing" width="500"/>

## Additional Stepper Motors - Focus & Zoom Control
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

	  #### Design 2 outweighed Design 1
	  <img src="https://user-images.githubusercontent.com/59852573/115255186-03bf3f00-a0fc-11eb-8c53-ad4d4107cd8d.png" alt="drawing" width="400" height="325"/><img src="https://user-images.githubusercontent.com/59852573/115255222-0ae64d00-a0fc-11eb-864f-c737a50ace0e.png" alt="drawing" width="400" height="325"/>
	 


  
## Dynamic Lighting
&nbsp;&nbsp;&nbsp;To control the lights alongside the entire "Tasmanian Devil" the design must be compatible with the current light and tripod design. The following design allows for the rig to be easily set on the tripod and controlled from a distance.

<img src="https://user-images.githubusercontent.com/59852573/114408162-263ede80-9b77-11eb-93f3-7eef6c4e0d40.png" alt="drawing" width="300"/>

## 3D Printing Material
&nbsp;&nbsp;&nbsp;The entire 5-axis camera rig is made of PLA, a relatively strong plastic and easy to work with. Two axes work with gears to increase ratio and precision. The contact from the gears could lead to increased vibrations and inconsistent filming. When printing one of the gears twice, once in semi-flexible and another in flexible, there was no significant change to the video. Moreover, softer teeth could increase the chances of gears skipping which would create shaking in the video at higher speeds. Gears as shown below:<br/>
<img src="https://user-images.githubusercontent.com/59852573/115081672-b01ddd00-9ed2-11eb-9368-d9599d85b351.png" alt="drawing" width="500"/>


## Assembling In SolidWorks
### Assembly
&nbsp;&nbsp;&nbsp;When assembling mechanical parts it is to your advantage to include screws, nuts, and other typically ignored components. All CAD files the nuts, screws, and bearings can be found on McMaster-Carr's website with many options for thread, pitch, head, etc. Ignoring to include the screws can lead to possible collisions with parts or even worse, a camera.
For a project like this one it may be advantageous to have a second assembly in which you can include the components to be printed. Often, when printing, offsets and chamfers are required depending on the printer's quality. A second assembly helps visualize the offsets and where you might be missing some.
