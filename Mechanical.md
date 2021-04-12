# Mechanical
![image](https://user-images.githubusercontent.com/59852573/112387791-940a8f80-8cc8-11eb-9668-d42f66579010.png)

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
 <img src="https://user-images.githubusercontent.com/59852573/110705766-d8743680-81c4-11eb-9c58-b186b4b31b31.png" alt="drawing" width="500"/>
 
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
    <img src="https://user-images.githubusercontent.com/59852573/110356542-5e974e00-8008-11eb-9604-2b08a7cf43be.png" alt="drawing" width="500"/>
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
	  <img src="https://user-images.githubusercontent.com/59852573/110705291-32283100-81c4-11eb-93de-697506ec297f.png" alt="drawing" width="500"/>
	  
## Dynamic Lighting
&nbsp;&nbsp;&nbsp;To control the lights alongside the entire "Tasmanian Devil" the design must be compatible with the current light and tripod design. The following design allows for the rig to be easily set on the tripod and controlled from a distance.
<img src="https://user-images.githubusercontent.com/59852573/114408162-263ede80-9b77-11eb-93f3-7eef6c4e0d40.png" alt="drawing" width="300"/>


## 3D Printing Material
&nbsp;&nbsp;&nbsp;The entire 5-axis camera rig is made of PLA, a relatively strong plastic and easy to work with. Two axes work with gears to increase ratio and precision. The contact from the gears could lead to increased vibrations and inconsistent filming. When printing one of the gears twice, once in semi-flexible and another in flexible, there was no significant change to the video. Moreover, softer teeth could increase the chances of gears skipping which would create shaking in the video at higher speeds. Gears as shown below:<br/>
<img src="https://user-images.githubusercontent.com/59852573/110848820-7e36ac80-827c-11eb-80bb-a8386c81696d.png" alt="drawing" width="500"/>

## Assembling In SolidWorks
### Assembly
&nbsp;&nbsp;&nbsp;When assembling mechanical parts it is to your advantage to include screws, nuts, and other ignored components. All CAD files for common pieces can be found on McMaster-Carr's website with many options. Ignoring to include the screws can lead to possible collisions with parts or even worse, a camera.
For a project like this one it may be advantageous to have a second assembly in which you can include the components to be printed. Often, when printing, offsets and chamfers are required depending on the printer's quality. A second assembly helps visualize the offsets and where you might be missing others.


