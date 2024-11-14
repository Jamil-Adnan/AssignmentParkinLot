using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public class TDD
    {        
        public static double CalculateTotalAmount(int desiredTime, int checkOutTime) 
        {
            desiredTime = Math.Abs(desiredTime);
            checkOutTime = Math.Abs(checkOutTime);
            int checkInTime = 0;
            double pricePerSecond = 1.5;
            int expectedCheckOutTime = checkInTime + desiredTime;
            double totalAmount = desiredTime * pricePerSecond;            
            int timeSpanDiff = checkOutTime - expectedCheckOutTime;
            int fine = 500;
            if (timeSpanDiff > 0)
            {
                return totalAmount += fine;                
            }            
            return 0;            
        }        
    }
}
