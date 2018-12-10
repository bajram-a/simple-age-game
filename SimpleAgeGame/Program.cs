using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAgeGame
{
    class Program
    {
        static string dayString, monthString, yearString, choiceString, birthday, finalChoiceString;
        static int day, month, year, choice, finalChoice;
        static bool leapYear = false;
        static DateTime dayOfBirth;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to The Age Game! \nWhere we deduce exactly how old you are");
            dateInput();
            game();

            Console.ReadLine();

        }


        static void dateInput()
        {
            Console.WriteLine("Please input the day of your birth: ");
            dayString = Console.ReadLine();
            int.TryParse(dayString, out day);

            while (day < 1 || day > 31)
            {
                Console.WriteLine("It seems you made a mistake. Please input again: ");
                dayString = Console.ReadLine();
                int.TryParse(dayString, out day);
            }

            Console.WriteLine("Please input the month of your birth (in number form): ");
            monthString = Console.ReadLine();
            int.TryParse(monthString, out month);

            while (month < 1 || month > 12)
            {
                Console.WriteLine("It seems you made a mistake. Please input again: ");
                monthString = Console.ReadLine();
                int.TryParse(monthString, out month);
            }

            Console.WriteLine("Please input the year you were born: ");
            yearString = Console.ReadLine();
            int.TryParse(yearString, out year);

            while (year < 1900 || year > DateTime.Now.Year)
            {
                Console.WriteLine("It seems you made a mistake. Please input again: ");
                yearString = Console.ReadLine();
                int.TryParse(yearString, out year);
            }

            dateValidation();
        }
        static void dateValidation()
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                leapYear = true;
            }

            if (day > 29 && month == 2)
            {
                Console.WriteLine("It seems you made a mistake. Try again: \n");
                dateInput();
            }
            else if (day == 29 && month == 2 && leapYear == false)
            {
                Console.WriteLine("It seems you made a mistake. Try again: \n");
                dateInput();
            }

            birthday = day + "/" + month + "/" + year;
            DateTime.TryParse(birthday, out dayOfBirth);
        }
        static void game()
        {
            Console.WriteLine("Splendid! \nIf you want to find out exactly how long you've lived input: " +
                "\n1)for days \n2)for hours \n3)for minutes \n4)for seconds");

            choiceString = Console.ReadLine();
            int.TryParse(choiceString, out choice);

            while (choice < 1 || choice > 4)
            {
                Console.WriteLine("It seems you made a mistake. Please input again: ");
                choiceString = Console.ReadLine();
                int.TryParse(choiceString, out choice);
            }

            if (choice == 1)
            {
                Console.WriteLine("You've lived for " + DateTime.Now.Subtract(dayOfBirth).TotalDays + " days! ");
            }
            else if (choice == 2)
            {
                Console.WriteLine("You've lived for " + DateTime.Now.Subtract(dayOfBirth).TotalHours + " hours! ");
            }
            else if (choice == 3)
            {
                Console.WriteLine("You've lived for " + DateTime.Now.Subtract(dayOfBirth).TotalMinutes + " minutes! ");
            }
            else
            {
                Console.WriteLine("You've lived for " + DateTime.Now.Subtract(dayOfBirth).TotalSeconds + " seconds! ");
            }

            Console.WriteLine("\nThank you for playing The Age Game! \nIf you want to play again withe the same date input 1," +
                "with a different date input 2, or if you want to quit press enter. ");
            finalChoiceString = Console.ReadLine();
            int.TryParse(finalChoiceString, out finalChoice);

            if (finalChoice == 1)
            {
                game();

            }
            else if (finalChoice == 2)
            {
                Console.WriteLine("Thank you for choosing to play again.");
                dateInput();
                game();

            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}
