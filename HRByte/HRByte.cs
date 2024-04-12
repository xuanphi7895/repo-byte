// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
using System;
using System.Collections.Generic;

namespace HRByte
{
    public class Calculate
    {
        public static void Main(string[] args)
        {

            CalculateLateServices services = new CalculateLateServices();

            var listData = services.SetListData();
            List<TimeSpan> listTimeLate = services.ListCalculateLate(listData);

            foreach (var item in listTimeLate)
            {
                Console.WriteLine("Late time: {0}", item.ToString());
            }
        }    
    }
}
