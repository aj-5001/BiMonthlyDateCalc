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
            payDay = getPayday(today);
            Console.WriteLine("The end payday is: " + payDay.Month + "/" + payDay.Day + "/" + payDay.Year);
            Console.WriteLine("You get paid in " + daysTilPaid + " Days");
            Console.WriteLine("Hit any key to close..");
            Console.ReadKey();
        }

        static public DateTime getPayday(DateTime currentDay)
        {
            if (currentDay.Day < 15) // checks the 15th has not passed
            {
                daysTilPaid = 15 - currentDay.Day;  // sets remainder days until payday
                currentDay = currentDay.AddDays(daysTilPaid); // sets value^
                return currentDay;
            }
            else
            {   // same thing for dates after the 15th, uses DaysInMonth for difference in months days
                daysTilPaid = DateTime.DaysInMonth(today.Year, today.Month) - currentDay.Day;
                currentDay.AddDays(daysTilPaid);
                return currentDay;
            }
            
        }
    }
}
