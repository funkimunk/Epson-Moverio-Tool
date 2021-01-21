using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Epson3DSwitcher
{

    /*
     * Author: Funkimunk
     */

    class Program
    {
        static void Main(string[] args)
        {

            Boolean bPortSet = false;
            Boolean bCommandSet = false;
 
            String comTarget = "";
            String comCommand = "";

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" Welcome to the CraftComputing Epson HMD tool");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");

            if (args.Length != 2)
            {

         
            }
            else
            {
                comTarget = args[0];
                bPortSet = int.TryParse(comTarget, out _);

                if (args[1].ToLower().Equals("3don"))
                {

                    comCommand = "set2d3d 1";
                    bCommandSet = true;

                }

                if (args[1].ToLower().Equals("3doff"))
                {
                    comCommand = "set2d3d 0";
                    bCommandSet = true;
                }


            }


            if(bCommandSet && bPortSet) { 

                SerialPort serialPort = new SerialPort("COM5", 9600);

                try
                {
                    Console.WriteLine("Opening COM"+ comTarget);
                    serialPort.Open();
                    Console.WriteLine("Sending " + comCommand);
                    serialPort.WriteLine(comCommand);

                }catch(Exception e)
                {
                    Console.WriteLine("There was an error");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Source);
                    Console.WriteLine(e.InnerException);
                }

                serialPort.Close();
            }
            else
            {
                Console.WriteLine("You did not provide the correct arguments.");
                Console.WriteLine("");
                Console.WriteLine("The syntax is: Epson3DSwitcher <port> <command>");
                Console.WriteLine("Where <port> is the number of the COM port the headset is attached to");
                Console.WriteLine("and <command> is the command which can be 3DOn or 3DOff");


            }

        }
    }
}
