using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiMonthlyDateCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            DateTime payDay = new DateTime();
              
            Console.WriteLine("Today is: " + today.Month + "/" + today.Day + "/" + today.Year);
            payDay = getPayday(today);
            Console.WriteLine("The end payday is: ");
            Console.ReadKey();
        }

        static public DateTime getPayday(DateTime currentDay)
        {
            //do something to currentday
            return currentDay;
        }
    }
}
