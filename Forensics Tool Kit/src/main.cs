using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Runtime.InteropServices;
using System.Diagnostics;
using RestSharp;

namespace Forensics_Tool_Kit
{
    internal class main
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        [STAThread]

        static void Main(string[] args)
        {
            printTitle();

            bool EXIT_FLAG = false;

            while (!EXIT_FLAG)
            {
                EXIT_FLAG = mainMenu();
            }
            Environment.Exit(0);


        }

        public static void printTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n █████╗ ████████╗ █████╗ ██╗     ███████╗\r\n██╔══██╗╚══██╔══╝██╔══██╗██║     ██╔════╝\r\n███████║   ██║   ███████║██║     ███████╗\r\n██╔══██║   ██║   ██╔══██║██║     ╚════██║\r\n██║  ██║   ██║   ██║  ██║███████╗███████║\r\n╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚══════╝\r\n                                         \r");
            Console.WriteLine("A Forensics Tool Kit By Mateusz Peplinski \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            showloadingPercent();
            Console.Clear();
            resetTextColour();
        }
        public static void printMenuTitle()
        {
            Console.WriteLine("\r\n╔═╗╔╦╗╔═╗╦  ╔═╗  ╔╦╗╔═╗╔╗╔╦ ╦\r\n╠═╣ ║ ╠═╣║  ╚═╗  ║║║║╣ ║║║║ ║\r\n╩ ╩ ╩ ╩ ╩╩═╝╚═╝  ╩ ╩╚═╝╝╚╝╚═╝\r");
        }
        public static bool mainMenu()
        {
            bool EXIT_FLAG = false;
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
                        Console.Clear();
                        IPMenu();                      
                        break;
                    case 2:
                        Console.Clear();
                        malwareMenu();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        EXIT_FLAG = true;
                        break ;
                    default:
                        Console.Clear();
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
            return EXIT_FLAG;
        }

        public static void IPMenu()
        {
            
            bool netflag = true;
            while (netflag)
            {
                
                Console.ForegroundColor = ConsoleColor.Green;

                printSplitLine();
                Console.WriteLine(String.Format("{0,20}", "IP Address Menu "));
                printSplitLine();
                Console.WriteLine(String.Format("[1] - {0,20}", "IP Address Gather All Information"));
                Console.WriteLine(String.Format("[2] - {0,20}", "IP Address Ping Test"));
                Console.WriteLine(String.Format("[3] - {0,20}", "IP Address Locator"));
                Console.WriteLine(String.Format("[4] - {0,20}", "Check If IP Address is Malicious"));
                Console.WriteLine(String.Format("[5] - {0,20}", "Clear Screen"));
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
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter a Vaild IP Address to Gather Intelligence");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter B to go back");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("> ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            String IPAddr = Console.ReadLine();
                            if(IPAddr == "b" || IPAddr == "B")
                            {
                                Console.Clear();
                                break;
                            }
                            bool pingStatus = ping(IPAddr);
                            Console.ForegroundColor = ConsoleColor.White;


                            if (pingStatus == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("---------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Ping Status: ");
                                Console.ForegroundColor = ConsoleColor.Green;                            
                                Console.WriteLine("SUCCESS|");
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Staring Intelligence Gathering...");
                                Console.WriteLine("---------------------");
                                getIPLocation(IPAddr);                              
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Ping Status: ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed to Ping Unable to Gather Intelligence");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            tryPing();
                            break;

                        case 3:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter a Vaild IP Address to Find The Location ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter B to go back");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("> ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            String IPAddrLoc = Console.ReadLine();
                            if (IPAddrLoc == "b" || IPAddrLoc == "B")
                            {
                                Console.Clear();
                                break;
                            }
                            bool pingStatusLoc = ping(IPAddrLoc);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (pingStatusLoc == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("---------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Ping Status: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("SUCCESS|");
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Staring Intelligence Gathering...");
                                Console.WriteLine("---------------------");
                                getIPLocation(IPAddrLoc);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
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
                        case 5:
                            Console.Clear();
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
            bool netflag = true;
            while (netflag)
            {

                Console.ForegroundColor = ConsoleColor.Green;

                printSplitLine();
                Console.WriteLine(String.Format("{0,20}", "Malware Menu "));
                printSplitLine();
                Console.WriteLine(String.Format("[1] - {0,20}", "Scan File"));
                Console.WriteLine(String.Format("[3] - {0,20}", "Clear Screen"));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("[3] - {0,20}", "Quit"));
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
                            var client = new RestClient("https://www.virustotal.com/vtapi/v2/ip-address/report?apikey={KEY}" + "8.8.8.8");
                            var request = new RestRequest(Method.Get);
                            request.AddHeader("Accept", "application/json");
                            var response = client.Execute(request);
                            break;
                        case 2:
                            Console.Clear();
                            break;
                        case 3:
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
        

        public static void getIPLocation(String IPAddr)
        {

            var Ip_Api_Url = "http://ip-api.com/json/" + IPAddr;
                      

            
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                httpClient.BaseAddress = new Uri(Ip_Api_Url);
                HttpResponseMessage httpResponse = httpClient.GetAsync(Ip_Api_Url).GetAwaiter().GetResult();
                
                if (httpResponse.IsSuccessStatusCode)
                {
                    var geolocationInfo = httpResponse.Content.ReadAsAsync<LocationDetails_IpApi>().GetAwaiter().GetResult();
                    if (geolocationInfo != null)
                    {
                        Console.WriteLine("Country: " + geolocationInfo.country);
                        Console.WriteLine("Region: " + geolocationInfo.regionName);
                        Console.WriteLine("City: " + geolocationInfo.city);
                        Console.WriteLine("Zip: " + geolocationInfo.zip);
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Press Any Key to finish");
                        Console.Write("> ");                 
                        Console.ReadKey();
                        Console.WriteLine("\n");
                    }
                }
            }
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

    public class LocationDetails_IpApi
    {
        public string query { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string isp { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string org { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string status { get; set; }
        public string timezone { get; set; }
        public string zip { get; set; }
    }
}
