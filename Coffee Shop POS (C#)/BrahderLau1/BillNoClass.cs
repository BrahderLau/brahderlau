using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_registration_by_Nesa
{
    class BillNoClass //https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
    {
        private string _BillNo;

        public BillNoClass(string BillNo)
        {
            _BillNo = BillNo;
        }

        // Generate a random number between two numbers  
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random bill no. from 10000 to 99999
        public string RandomBillNo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomNumber(10000, 100000));
            return builder.ToString();
        }
    }
}
