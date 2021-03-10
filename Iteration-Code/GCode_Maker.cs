using System;
using System.IO;
using static System.Console;

namespace CameraRail
{
    class Program
    {
        static void Main()
        {
			//Travel along rail
			WriteLine("----Travel----");
			Write("Enter travel distance (in cm): ");
			int Travel = Int32.Parse(ReadLine());
				double Travelx10 = Travel * 10; //in mm
				double XGCode = Travelx10 *2* 55 / 250; // 198cart/930cm 
				double XInitialPos = 0;
				
			//Panning
			WriteLine("\n----Panning----");
			Write("Which would you like (a or b): \na)Pan around object \nb)No pan \nDecision: ");
			string PanAnswer = ReadLine();
			bool Pan = false;
			double YCoords = 0;
			double YInitialPos= 0;
																//double PanDirec; would need this if we have the option right-to-left or left-to-right
			int x = 1;
				for(int i=0; i < x; i++){
					if(PanAnswer == "a" || PanAnswer == "A") {
						Pan = true;
					}else if(PanAnswer == "b" || PanAnswer == "B") {
						Pan = false;
						YCoords = 0;
						
					}else{
							Write("Invalid entry, please choose a or b: \nDecision: ");
							PanAnswer = ReadLine();
							x++;
					}
				}	
				
				//Degrees Of Pan
				double YGCode=0;
				if(Pan){
					Write("\nEnter total degrees of pan: ");
					double PanRotation = Int32.Parse(ReadLine());
					YCoords = PanRotation* 10 / 30;
					YInitialPos = YCoords / 2;
					YGCode = -(YCoords / 2);
				}
			
			//Tilting
			WriteLine("\n----Tilt----");
			Write("Which would you like (a or b): \na)Tilt \nb)No tilt \nDecision: ");
			string TiltAnswer = ReadLine();
			bool Tilt = false;
			int y = 1;
			for(int i = 0; i < y; i++){
				if(TiltAnswer == "a" || TiltAnswer == "A") {
					Tilt = true;
				}else if(TiltAnswer == "b" || TiltAnswer == "B"){
					Tilt = false;
				}else{
						Write("Invalid entry, please choose a or b \nDecision");
						TiltAnswer = ReadLine();
						y++;
				}
			}
			
			double ZCoords;
			double ZInitialPos = 0;
			double ZGCode = 0;
			double TiltDirec = 1;
				if(Tilt){
					Write("\nWhich would you like (a or b): \na)Tilt bottom-up \nb)Tilt top-down \nDecision: ");
					string TiltOption = ReadLine();
					
					int z = 1;
					for(int i = 0; i < z; i++){
						if(TiltOption == "a" || TiltOption == "A"){
							TiltDirec = 1;
						}else if(TiltOption == "b" || TiltOption == "B"){
							TiltDirec = -1;
						}else{
							Write("Invalid entry, please choose a or b \nDecision: ");
							TiltOption = ReadLine();
							z++;
						}
					}
					Write("\nEnter total degrees of tilt (max 60 degrees): ");
					double VertRotation = Int32.Parse(ReadLine());
					ZCoords = VertRotation * 40 / 360;
					ZInitialPos = TiltDirec * ZCoords/2;
					ZGCode = -ZInitialPos;
				}
			
			
			//Display G-Code	
			string[] GCode = {"X","Y","Z","F"};
			double[] InitialPos = { XInitialPos, YInitialPos, ZInitialPos};
			double[] GValues = { XGCode, YGCode, /*ZInitialPos,*/ ZGCode};
			Write("\nHere is the GCode to input: \n");
			
			//Initial Position
			Write("G00 ");
			for(int i = 0; i < 3; i++){
				Write(GCode[i]);
				Write("{0:N3}", InitialPos[i]);
				Write(" ");
			}
			
			//Movement Function
			Write("\nG01 ");
			for(int i =0; i < 3; i++){
				Write(GCode[i]);
				Write("{0:N3}", GValues[i]);
				Write(" ");
			}
			WriteLine("F200\n");
			
			
        }
    }
}
