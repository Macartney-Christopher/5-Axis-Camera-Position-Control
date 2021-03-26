# 5-Axis-Camera-Position-Control
  The "Tasmanian Devil" is a 5-axis camera position control system to get all the video shots you could dream of. The entire design is an extension from [isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s camera rig with three axes, and a shutter control. Using Isaac879's available pinouts and step files, his design was modified to account for focus and zoom control.
  Before reading through the rest of the repository it is strongly suggested to look at [isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s original work on this project.
Go see the final product in action on YouTube [here](https://www.youtube.com/watch?v=kPsWlgf-iiQ)!

## Table of Contents
### 1. [Mechanical Design](Mechanical.md)
### 2. [Hardware Design](Hardware.md)
### 3. [Software Design](Software.md)

## Setup
### With Gaming Controller
1. Download the code [here](Gaming_Controller/Xbox_Control.cpp) 
2. Enter the Nano 33 IoT port in this [.txt file](Gaming_Controller/serial_port.txt)
3. Ensure all cables are connected
4. Rebuild and compile
5. Operate using [these commands](Gaming_Controller/Gaming_Controller_Commands.pdf)

### Without Gaming Controller
1. Compile the Arduino code [here](Gaming_Controller/Xbox_Control.cpp) 
3. Ensure all cables are connected
4. Compile and execute
5. Operate using [these commands](Gaming_Controller/Gaming_Controller_Commands.pdf)

## Installation & Build
1. Install Arduino IDE
2. Install a C++ compiler
3. Download & 3D Print the parts
4. Solder the components on the custom PCB

## Usage: This would also be a good place to include screenshots of your project in action.
1. Upload the Arduino code to the Nano 33 IoT
3. Assemble the 3D prints
4. Set up the wiring
5. Open the and compile the Bluetooth code on C++ compiler
6. Enjoy!

## Credits
  The mechanical, hardware, and software design is an adapted version of [isaac879](https://github.com/isaac879/Pan-Tilt-Mount)'s project. Isaac879 did a tremendous job with every aspect of the project and shows great skill in his other project as well. [Isaac879's video](https://www.youtube.com/watch?v=1FfB7cLkUyQ) is very well structured and edited.
## License
[Project license](LICENSE).
