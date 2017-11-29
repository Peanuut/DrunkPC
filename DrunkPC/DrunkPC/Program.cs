using System;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace DrunkPC
{


    class Program
    {

        public static Random _random = new Random();
        public static int _StartUpDelay = 10;
        public static int _TotalDurationDelay = 10;

        static void Main(string[] args)
        {

            Console.WriteLine("Booting...");

            if (args.Length >= 2)
            {
                _StartUpDelay = Convert.ToInt32(args[0]);
                _TotalDurationDelay = Convert.ToInt32(args[1]);
            }

            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopupThread = new Thread(new ThreadStart(DrunkPopupThread));

            DateTime future = DateTime.Now.AddSeconds(_StartUpDelay);

            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopupThread.Start();

            future = DateTime.Now.AddSeconds(_TotalDurationDelay);

            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPopupThread.Abort();
        }

        #region Thread Functions
        public static void DrunkMouseThread()
        {
            Console.WriteLine("Mouse Started...");
            int moveX = 0;
            int moveY = 0;
            while (true)
            {
                //Console.WriteLine(Cursor.Position.ToString());
                moveX = _random.Next(20) - 10;
                moveY = _random.Next(20) - 10;
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + moveX, Cursor.Position.Y + moveY);
                Thread.Sleep(50);
            }
        }
        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("Keyboard Started...");
            while (true)
            {
                char key = (char)(_random.Next(25) + 65);
                if (_random.Next(2) == 0)
                {
                    key = Char.ToLower(key);
                }
                SendKeys.SendWait(key.ToString());
                Thread.Sleep(_random.Next(500));
            }
        }
        public static void DrunkSoundThread()
        {
            Console.WriteLine("Sound Started...");
            while (true)
            {
                if (_random.Next(100) > 90)
                {
                    switch (_random.Next(4))
                    {
                        case 0:
                            SystemSounds.Beep.Play();
                            break;
                        case 1:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 2:
                            SystemSounds.Question.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;



                    }
                }
                Thread.Sleep(1000);

            }
        }
        public static void DrunkPopupThread()
        {
            Console.WriteLine("Popup Started...");
            while (true)
            {
                if (_random.Next(100) > 95)
                {
                    switch (_random.Next(3))
                    {
                        case 0:
                            MessageBox.Show("R u a Wizard?.",
                            "Wizard Test",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                            break;
                        case 1:
                            MessageBox.Show("Do you want to delete System32?",
                                "Microsoft",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Question);
                            break;
                        case 2:
                            MessageBox.Show("Restart System?",
                                "System",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Question);
                            break;
                    }

                }
                Thread.Sleep(1000);

            }


        }
        #endregion
    }
}