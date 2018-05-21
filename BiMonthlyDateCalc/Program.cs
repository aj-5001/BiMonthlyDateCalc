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
            Console.WriteLine("The end payday is: " + payDay.Month + "/" + payDay.Day + "/" + payDay.Year);
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
                    Console.WriteLine("Today is payday");
                    return currentDay;
                }
                else // runs if today is not payday
                {
                    daysTilPaid = 15 - currentDay.Day;
                    var newPaydate = currentDay;
                    newPaydate.AddDays(daysTilPaid);
                    if (newPaydate.DayOfWeek == DayOfWeek.Saturday) // double checking payday is correct
                    {
                        daysTilPaid = 14 - currentDay.Day;  // sets remainder days until payday
                        currentDay = currentDay.AddDays(daysTilPaid); // sets value^
                        return currentDay;
                    }
                    if (newPaydate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        daysTilPaid = 13 - currentDay.Day;  // sets remainder days until payday
                        currentDay = currentDay.AddDays(daysTilPaid); // sets value^
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
                if (currentDay.DayOfWeek == DayOfWeek.Saturday)
                {
                    daysTilPaid = DateTime.DaysInMonth(today.Year, today.Month) - (currentDay.Day + 1);
                    currentDay.AddDays(daysTilPaid);
                    Console.WriteLine("sat, after 15th, new set day: " + currentDay.Day);
                    return currentDay;
                }
                if (currentDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    daysTilPaid = DateTime.DaysInMonth(today.Year, today.Month) - (currentDay.Day + 2);
                    currentDay.AddDays(daysTilPaid);
                    Console.WriteLine("sun, after 15th, new set day: " + currentDay.Day);
                    return currentDay;

                }
                // same thing for dates after the 15th, uses DaysInMonth for difference in months days
                daysTilPaid = DateTime.DaysInMonth(today.Year, today.Month) - currentDay.Day;
                currentDay.AddDays(daysTilPaid);
                Console.WriteLine("sat, after 15th, new set day: " + currentDay.Day);
                return currentDay;
            }
            
        }
    }
}
