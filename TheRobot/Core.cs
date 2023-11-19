using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRobot
{
    internal class Core:IRoboInterface
    {
        int tableX = 4;
        int tableY = 4;

        public Core()
        {

        }
    
        public static Core? singletonInstance;
        public static Core GetInstance()
        {
            if (singletonInstance == null)
                singletonInstance = new Core();
            return singletonInstance;
        }
        public void play()
        {
            bool isPlaying = true;
            bool isPlaced = false;
            int currentX = 0;
            int currentY = 0;
            String currentFace = "";
            int currentFaceIndex = -1;


            Dictionary<String, String> faceMap;
            faceMap = new Dictionary<String, String>();
            faceMap.Add("NORTH", "N");
            faceMap.Add("WEST", "W");
            faceMap.Add("SOUTH", "S");
            faceMap.Add("EAST", "E");

            
            while (isPlaying)
            {
                String command = System.Console.ReadLine();
                if (command != null)
                {
                    if(command.StartsWith("PLACE"))
                    {
                        int x=0,y=0;
                        if (int.TryParse(command.Split(' ')[1].Split(",")[0], out int numx))
                        {
                            x = numx;
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid Position X");
                        }
                        if (int.TryParse(command.Split(' ')[1].Split(",")[1], out int numy))
                        {
                            x = numy;
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid Position Y");
                        }
                        //   int x = Convert.ToInt32(command.Split(' ')[1].Split(",")[0]);
                        // int y = Convert.ToInt32(command.Split(' ')[1].Split(",")[1]);
                        String f = command.Split(' ')[1].Split(",")[2];
                      
                        if (x <0 || y < 0 || x > tableX || y > tableY || faceMap.ContainsKey(f) == false)
                        {
                            System.Console.WriteLine("Invalid values");
                        }
                        else
                        {
                            currentX = x;
                            currentY = y;
                            currentFace = faceMap[f];
                            currentFaceIndex = faceMap.Values.ToList().IndexOf(currentFace);
                            faceMap.ElementAt(0);
                            isPlaced = true;
                        }
                    }
                    else if (isPlaced)
                    {
                        String action = command.Split(' ')[0];
                        switch (action)
                        {
                            case "MOVE":
                                switch (currentFace)
                                {
                                    case "N":
                                        if (currentY < tableY)
                                        {
                                            currentY++;
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Unable to move");
                                        }
                                        break;
                                    case "S":
                                        if (currentY > 0)
                                        {
                                            currentY--;
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Unable to move");
                                        }
                                        break;
                                    case "E":
                                        if (currentX < tableX)
                                        {
                                            currentX++;
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Unable to move");
                                        }
                                        break;
                                    case "W":
                                        if (currentX > 0)
                                        {
                                            currentX--;
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Unable to move");
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "LEFT":
                                currentFaceIndex++;
                                if (currentFaceIndex > 3) currentFaceIndex = 0;
                                currentFace = faceMap.Values.ToList()[currentFaceIndex];
                                break;
                            case "RIGHT":
                                currentFaceIndex--;
                                if (currentFaceIndex < 0) currentFaceIndex = 3;
                                currentFace = faceMap.Values.ToList()[currentFaceIndex];
                                break;
                            case "REPORT":
                                System.Console.WriteLine("Output : "+currentX + "," + currentY + "," + faceMap.Keys.ToList()[currentFaceIndex]);
                                break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Please place robot before issue any commands");
                    }
                }
                

            }
        }
    }
}
