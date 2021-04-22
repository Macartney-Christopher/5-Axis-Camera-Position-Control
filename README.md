# 5-Axis-Camera-Position-Control
  The "Tasmanian Devil" is a 5-axis camera position control system to get all the video shots you could dream of. The design is an extension of [isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s camera rig which allows the use of three axes, and shutter control. Using Isaac879's available pinouts and step files, their design was modified to account for focus and zoom, or dynamic lighting control.
  Go see the final product in action on YouTube [here](https://www.youtube.com/watch?v=kPsWlgf-iiQ)! 
  To understand the modifications made it is strongly suggested to look at [isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s original work on this project.


## Table of Contents
### 1. [Mechanical Design](Mechanical.md)
### 2. [Hardware Design](Hardware.md)
### 3. [Software Design](Software.md)

## Setup
1. Plug the power cable to an outlet
2. Plug the Xbox controller and the USB cable to your computer
3. Download the repository and extract the folder [Tasmanian_Launch](Tasmanian_Launch).
4. Update [serial_port.txt](Tasmanian_Launch/serial_port.txt) in the folder with the port that the Nano is connected to. Go to Device Manager>Ports to find the port number (ex: COM4).
5. Double-click on [Tasmanian_Launch.bat](Tasmanian_Launch/Tasmanian_Launch.bat)
6. Enjoy!

## Do It Yourself
### Build
1. Upload the Arduino code to the Nano 33 IoT
3. Assemble the 3D prints
4. Set up the wiring
5. Open the and compile the Bluetooth code on C++ compiler

#### With Gaming Controller
&nbsp;&nbsp;&nbsp;Follow the "Setup" protocol

#### Without Gaming Controller
1. Compile the Arduino code [here](FlashStorage_PanTiltMount/FlashStorage_PanTiltMount.ino) 
3. Ensure all cables are connected
4. Compile and execute
5. Operate in Arduino IDE using [these commands](FlashStorage_PanTiltMount/5-Axis_Position_Control_Commands.pdf)

## Credits
  The mechanical, hardware and software design is an adapted version of [isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s project. Isaac879 did a tremendous job with every aspect of the project and shows great skill in his other project as well. [Isaac879's video](https://www.youtube.com/watch?v=1FfB7cLkUyQ) is very well structured and edited.
## License
[Project license](LICENSE).
