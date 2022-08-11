using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forensics_Tool_Kit
{
    internal class main
    {
        static void Main(string[] args)
        {
            printTitle();

            while (true)
            {
                mainMenu();
            }
        }

        public static void printTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n █████╗ ████████╗ █████╗ ██╗     ███████╗\r\n██╔══██╗╚══██╔══╝██╔══██╗██║     ██╔════╝\r\n███████║   ██║   ███████║██║     ███████╗\r\n██╔══██║   ██║   ██╔══██║██║     ╚════██║\r\n██║  ██║   ██║   ██║  ██║███████╗███████║\r\n╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚══════╝\r\n                                         \r");
            Console.WriteLine("A Forensics Tool Kit By Mateusz Peplinski \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            //showloadingPercent();
            Console.Clear();
            resetTextColour();
        }
        public static void printMenuTitle()
        {
            Console.WriteLine("\r\n╔═╗╔╦╗╔═╗╦  ╔═╗  ╔╦╗╔═╗╔╗╔╦ ╦\r\n╠═╣ ║ ╠═╣║  ╚═╗  ║║║║╣ ║║║║ ║\r\n╩ ╩ ╩ ╩ ╩╩═╝╚═╝  ╩ ╩╚═╝╝╚╝╚═╝\r");
        }
        public static void mainMenu()
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            printMenuTitle();
            printSplitLine();
            Console.WriteLine(String.Format("[1] - {0,20}", "IP Address Analysis"));
            Console.WriteLine(String.Format("[2] - {0,20}", "Malware Analysis"));
            Console.WriteLine(String.Format("[3] - {0,20}", "Open Investigation Tools"));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("[4] - {0,20}", "Quit"));
            Console.ForegroundColor = ConsoleColor.Green;
            printSplitLine();
            Console.WriteLine("Select an option: ");

            Console.Write("> ");
            resetTextColour();

            String userChoice = Console.ReadLine();
            int selectedOption_INT;

            if (int.TryParse(userChoice, out selectedOption_INT))
            {
                switch (selectedOption_INT)
                {
                    case 1:                                                   
                        IPMenu();                      
                        break;
                    case 2:
                        malwareMenu();
                        break;
                    case 3:
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option !");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter A Valid Number !");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }

        public static void IPMenu()
        {
            
            bool netflag = true;
            while (netflag)
            {
                
                Console.ForegroundColor = ConsoleColor.Green;

                printSplitLine();
                Console.WriteLine(String.Format("{0,20}", "IP Address Menu"));
                printSplitLine();
                Console.WriteLine(String.Format("[1] - {0,20}", "IP Address Gather All Information"));
                Console.WriteLine(String.Format("[2] - {0,20}", "IP Address Ping Test"));
                Console.WriteLine(String.Format("[3] - {0,20}", "IP Address Locator"));
                Console.WriteLine(String.Format("[4] - {0,20}", "Check If IP Address is Malicious"));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("[6] - {0,20}", "Quit"));
                Console.ForegroundColor = ConsoleColor.Green;
                printSplitLine();
                Console.WriteLine("Select an option: ");

                Console.Write("> ");
                resetTextColour();

                String userChoice = Console.ReadLine();
                int selectedOption_INT;

                if (int.TryParse(userChoice, out selectedOption_INT))
                {
                    switch (selectedOption_INT)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter a Vaild IP Address to Gather Intelligence");                    
                            Console.Write("> ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            String IPAddr = Console.ReadLine();

                            bool pingStatus = ping(IPAddr);
                            Console.ForegroundColor = ConsoleColor.White;


                            if (pingStatus == true)
                            {
                                Console.Write("Ping Status: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("SUCCESS");
                                Console.WriteLine("Staring Intelligence Gathering...");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Ping Status: ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed to Ping Unable to Complete Scan");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            
                            break;

                        case 2:
                            tryPing();
                            break;

                        case 6:
                            netflag = false;
                            break;


                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Option !");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter A Valid Number !");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.Clear();

        }

        public static void malwareMenu()
        {

        }

        public static void tryPing()
        {
            Console.WriteLine("    - Ping -");
            Console.WriteLine("Enter a Vaild IP Address to ping: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.Blue;

            String IPAddr = Console.ReadLine();


            bool pingStatus = ping(IPAddr);
            Console.ForegroundColor = ConsoleColor.White;


            if (pingStatus == true)
            {
                Console.Write("Ping Status: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("SUCCESS");
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ping Status: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to Ping");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static bool ping(String IPAddr)
        {

            bool pingStatus = false;
            Ping pingObj = null;

            try
            {

                pingObj = new Ping();
                PingReply reply = pingObj.Send(IPAddr);

                pingStatus = reply.Status == IPStatus.Success;
            }

            catch (PingException)
            {
                pingStatus = false;
            }
            finally
            {
                if (pingObj != null)
                {
                    pingObj.Dispose();
                }
            }

            return pingStatus;
        }
        public static void printSplitLine()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void showloadingPercent()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rProgress: {i}%   ");
                Thread.Sleep(20);
            }
            
            Console.Write("\r\n");
        }

        public static void resetTextColour()
        {
            Console.ResetColor();
        }
    }
}
