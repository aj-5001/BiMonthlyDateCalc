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
            Console.ReadKey();
        }

        static public DateTime getPayday(DateTime currentDay)
        {
            //do something to currentday
            if (currentDay.Day < 15)
            {
                daysTilPaid = 15 - currentDay.Day;
                currentDay = currentDay.AddDays(daysTilPaid);
                return currentDay;
            }
            else
            {
                daysTilPaid = 31 - currentDay.Day;
                currentDay.AddDays(daysTilPaid);
                return currentDay;
            }
            
        }
    }
}
