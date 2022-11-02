using System;
using System.Net;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;

namespace waltered
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        private static System.Timers.Timer aTimer;
        public static void Main(string[] args)
        {
            ShowWindow(GetConsoleWindow(), SW_HIDE);
            startWalter();
            if (Directory.Exists(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\"))
            {
                if (File.Exists(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt"))
                {
                    DateTime now = DateTime.Now;
                    using StreamWriter file = new(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt", append: true);
                    file.WriteLineAsync("[" + now + "] Waltered Started");
                    file.WriteLineAsync("[" + now + "] Not first time started");
                    file.Close();
                } 
                else
                {
                    DateTime now = DateTime.Now;
                    var uss = File.Create(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt");
                    uss.Close();
                    using StreamWriter file = new(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt", append: true);
                    file.WriteLineAsync("[" + now + "] Waltered Started");
                    file.WriteLineAsync("[" + now + "] Not first time started but log was deleted");
                    file.Close();
                }
            } 
            else
            {
                Directory.CreateDirectory(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\");
                if (File.Exists(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt"))
                {
                    DateTime now = DateTime.Now;
                    using StreamWriter file = new(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt", append: true);
                    file.WriteLineAsync("[" + now + "] Waltered Started");
                    file.WriteLineAsync("[" + now + "] First time started");
                    file.Close();
                } 
                else
                {
                    DateTime now = DateTime.Now;
                    var uss = File.Create(@"%userprofile%\waltered\log.txt");
                    uss.Close();
                    using StreamWriter file = new(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt", append: true);
                    file.WriteLineAsync("[" + now + "] Waltered Started");
                    file.WriteLineAsync("[" + now + "] First time started");
                    file.Close();
                }
            }
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
        }
        private static void startWalter()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(6000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Random rand = new Random();
            DateTime now = DateTime.Now;
            int random = rand.Next(0, 2000);
            var client = new WebClient();
            var walter = rand.Next(0, 15000000);
            using StreamWriter file = new(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt", append: true);
            if (random <= 750)
            {
                switch (rand.Next(0, 4))
                {
                    case 0:
                        client.DownloadFile("https://duckduckgo.com/i/d19b8c59.png", Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\Downloads\walter" + walter + ".png");
                        file.WriteLineAsync("[" + now + "] Downloaded new walter varient 0 file 😊! File Name: walter" + walter + ".png , Number: " + random);
                        file.Close();
                        break;
                    case 2:
                        //DateTime now = DateTime.Now;
                        client.DownloadFile("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fs-media-cache-ak0.pinimg.com%2Foriginals%2F57%2F46%2Fe9%2F5746e9611d16aacfa1eb9dc66fe298f8.jpg", Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\Downloads\walter" + walter + ".jpg");
                        //using StreamWriter file = new(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt", append: true);
                        file.WriteLineAsync("[" + now + "] Downloaded new walter varient 2 file 😊! File Name: walter" + walter + ".png , Number: " + random);
                        file.Close();
                        break;
                    case 3:
                        //DateTime now = DateTime.Now;
                        //var client = new WebClient();
                        //var walter = rand.Next(0, 15000000);
                        client.DownloadFile("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmir-s3-cdn-cf.behance.net%2Fproject_modules%2F1400%2Ff4413531507903.5653d14a045ed.jpg", Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\Downloads\walter" + walter + ".jpg");
                        //using StreamWriter file = new(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\waltered\log.txt", append: true);
                        file.WriteLineAsync("[" + now + "] Downloaded new walter varient 3 file 😊! File Name: walter" + walter + ".png , Number: " + random);
                        file.Close();
                        break;
                    case 1:
                        client.DownloadFile("https://duckduckgo.com/i/d19b8c59.png", Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + @"\Downloads\walter" + walter + ".png");
                        file.WriteLineAsync("[" + now + "] Downloaded new walter varient 1 file 😊! File Name: walter" + walter + ".png , Number: " + random);
                        file.Close();
                        break;
                    default:
                        file.WriteLineAsync("[" + now + "] [ERROR] Switch Case Defualt Number: " + random);
                        file.Close();
                        break;
                }
            } else
            {
                file.WriteLineAsync("[" + now + "] No walter 😒! Number: " + random);
                file.Close();
            }
        }
    }
}