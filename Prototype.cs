using System;
using System.Collections.Generic;
using System.Threading;

namespace SchoolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the MobileApp class
            MobileApp app = new MobileApp();

            // Start the application in a separate thread
            Thread appThread = new Thread(new ThreadStart(app.Start));
            appThread.Start();

            // Wait for the user to press the "Enter" key to exit the application
            Console.WriteLine("Press Enter to exit the program...");
            Console.ReadLine();

            // Terminate the application thread
            app.Stop();
            appThread.Join();
        }
    }

    class MobileApp
    {
        private OnlineDiary diary;
        private MotivationalNotification notification;
        private VirtualCurrency currency;
        private string language;

        public MobileApp()
        {
            // Initialize objects of OnlineDiary, MotivationalNotification, and VirtualCurrency
            diary = new OnlineDiary();
            notification = new MotivationalNotification();
            currency = new VirtualCurrency();
            language = "English"; // Default language is English
        }

        public void Start()
        {
            while (true)
            {
                // Get a list of subjects from the diary
                List<string> subjects = diary.GetSubjects();

                // Send motivational notifications for each subject
                foreach (string subject in subjects)
                {
                    notification.Send(subject, language);
                }

                // Get the last grade and attendance from the diary
                int grade = diary.GetLastGrade();
                bool attendance = diary.GetAttendance();

                // If the grade is between 6 and 10, add virtual currency
                if (grade >= 6 && grade <= 10)
                {
                    currency.Add(grade);
                }

                // Send a reward for the grade in the form of virtual currency
                currency.SendReward(language);

                // Check attendance and display the corresponding notification
                if (attendance)
                {
                    if (language == "English")
                    {
                        Console.WriteLine("Good attendance!");
                    }
                    else if (language == "Russian")
                    {
                        Console.WriteLine("Хорошая посещаемость!");
                    }
                    else if (language == "Latvian")
                    {
                        Console.WriteLine("Laba apmeklēšanas statistika!");
                    }
                }
                else
                {
                    if (language == "English")
                    {
                        Console.WriteLine("Attendance needs improvement!");
                    }
                    else if (language == "Russian")
                    {
                        Console.WriteLine("Посещаемость надо улучшить!");
                    }
                    else if (language == "Latvian")
                    {
                        Console.WriteLine("Apmeklējumu jāuzlabo!");
                    }
                }

                // Display the balance of virtual currency
                currency.DisplayBalance(language);

                // Wait for 24 hours before the next notification
                Thread.Sleep(24 * 60 * 60 * 1000);
            }
        }

        public void Stop()
        {
            // Method to terminate the application (you can add necessary actions, e.g., data saving)
        }

        public void ChangeLanguage(string newLanguage)
        {
            language = newLanguage;
        }
    }

    class OnlineDiary
    {
        public List<string> GetSubjects()
        {
            // Method to get a list of subjects
            // (you can add necessary functionality, e.g., getting data from an online diary)
            List<string> subjects = new List<string>() { "Mathematics", "Physics", "Informatics" };
            return subjects;
        }

        public int GetLastGrade()
        {
            // Method to get the last grade
            // (you can add necessary functionality, e.g., getting data from an online diary)
            int grade = 9;
            return grade;
        }

        public bool GetAttendance()
        {
            // Method to get attendance
            // (you can add necessary functionality, e.g., getting data from an online diary)
            bool attendance = true;
            return attendance;
        }
    }

    class MotivationalNotification
    {
        public void Send(string subject, string language)
        {
            // Method to send a motivational notification
            // (you can add necessary functionality, e.g., sending a message to the user)
            if (language == "English")
            {
                Console.WriteLine($"You will find the subject {subject} interesting! Keep up the good work!");
            }
            else if (language == "Russian")
            {
                Console.WriteLine($"Тебе будет интересно изучать предмет {subject}! Продолжайте в том же духе!");
            }
            else if (language == "Latvian")
            {
                Console.WriteLine($"Tu atradīsi prieku mācoties priekšmetu {subject}! Turpiniet tāpat!");
            }
        }
    }

    class VirtualCurrency
    {
        private int balance;

        public VirtualCurrency()
        {
            balance = 0;
        }

        public void Add(int amount)
        {
            // Method to add virtual currency
            balance += amount;
        }

        public void SendReward(string language)
        {
            // Method to send a reward for the grade
            if (language == "English")
            {
                Console.WriteLine($"Congratulations! Your balance is {balance}!");
            }
            else if (language == "Russian")
            {
                Console.WriteLine($"Поздравляем! Ваш баланс баллов составляет {balance}!");
            }
            else if (language == "Latvian")
            {
                Console.WriteLine($"Apsveicam! Jūsu konta atlikums ir {balance}!");
            }
        }

        public void DisplayBalance(string language)
        {
            if (language == "English")
            {
                Console.WriteLine($"Congratulations! Your balance is {balance}!");
            }
            else if (language == "Russian")
            {
                Console.WriteLine($"Поздравляем! Ваш баланс баллов составляет {balance}!");
            }
            else if (language == "Latvian")
            {
                Console.WriteLine($"Apsveicam! Jūsu konta atlikums ir {balance}!");
            }
        }
    }

    
}
