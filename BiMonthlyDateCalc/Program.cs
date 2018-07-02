using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiMonthlyDateCalc
{
    class Program
    {
        static DateTime today = DateTime.Today;
        static DateTime payDay = new DateTime();
        static int daysTilPaid = 0;
        
        

        static void Main(string[] args)
        {
                 
            Console.WriteLine("Today is: " + today.Month + "/" + today.Day + "/" + today.Year);
            payDay = GetPayday(today);
            if (payDay == today)
            {
                Console.WriteLine("Today is payday");
            }
            else
            {
                Console.WriteLine("The end payday is: " + payDay.Month + "/" + payDay.Day + "/" + payDay.Year + " " + payDay.DayOfWeek);
            }
            Console.WriteLine("You get paid in " + daysTilPaid + " Days");
            Console.WriteLine("Hit any key to close..");
            Console.ReadKey();
            
        }

        static public DateTime GetPayday(DateTime currentDay)
        {
            if (currentDay.Day <= 15) // checks the 15th has not passed
            { // needs to check for if the 15 falls on a saturday or not
                if (currentDay.Day == 15 && currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    //today is payday
                    return currentDay;
                }
                else // runs if today is not payday
                {
                    daysTilPaid = 15 - currentDay.Day;
                    var newPaydate = currentDay;
                    newPaydate = newPaydate.AddDays(daysTilPaid);
                    Console.WriteLine("New Pay date Test: " + newPaydate.Month + "/" + newPaydate.Day + "/" + newPaydate.Year);
                    if (newPaydate.DayOfWeek == DayOfWeek.Saturday) // double checking payday is correct
                    {
                        daysTilPaid = 14 - currentDay.Day;  // sets remainder days until payday
                        currentDay = currentDay.AddDays(daysTilPaid); // sets value^
                        Console.WriteLine("New Pay date Test, before 15th, saturday: " + newPaydate.Month + "/" + newPaydate.Day + "/" + newPaydate.Year);
                        return currentDay;
                    }
                    if (newPaydate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        daysTilPaid = 13 - currentDay.Day;  // sets remainder days until payday
                        currentDay = currentDay.AddDays(daysTilPaid); // sets value^
                        Console.WriteLine("New Pay date Test, before 15th, sunday: " + newPaydate.Month + "/" + newPaydate.Day + "/" + newPaydate.Year);
                        Console.WriteLine("Currentday (returned value): " + currentDay.Month + "/" + currentDay.Day + "/" + currentDay.Year);
                        return currentDay;
                    }
                    else
                    {
                        return newPaydate;
                    }
                }  
            }
            else // current day is after the 15th
            {
                daysTilPaid = DateTime.DaysInMonth(currentDay.Year, currentDay.Month) - currentDay.Day;
                var newPayDate = currentDay;
                newPayDate = newPayDate.AddDays(daysTilPaid);
                // set the pay date to then be checked below
                if (newPayDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    daysTilPaid = DateTime.DaysInMonth(currentDay.Year, currentDay.Month) - (currentDay.Day - 1);
                    currentDay = currentDay.AddDays(daysTilPaid);
                    Console.WriteLine("New Pay date Test, after 15th, Saturday: " + newPayDate.Month + "/" + newPayDate.Day + "/" + newPayDate.Year);
                    return currentDay; // resets the payday based on whether it's a saturday
                }
                if (newPayDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    daysTilPaid = DateTime.DaysInMonth(currentDay.Year, currentDay.Month) - (currentDay.Day - 1);
                    currentDay = currentDay.AddDays(daysTilPaid);
                    Console.WriteLine("New Pay date Test, after 15th, sunday: " + newPayDate.Month + "/" + newPayDate.Day + "/" + newPayDate.Year);
                    return currentDay;
                }
                return newPayDate;
            }
            
        }
    }
}
