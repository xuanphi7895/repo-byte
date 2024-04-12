using NUnit.Framework;
using HRByte;

namespace TestHRByte
{
    [TestFixture]
    public class LateCalculatorTests
    {
        [Test]
        public void TestCalculateLate()
        {
            // Define test input data
            //var inputs = new List<InformationTime>
            //{
            //    new InformationTime("08:00", "17:00", "12:00", "13:00", "08:15", null, null),
            //    new InformationTime("08:00", "17:00", "12:00", "13:00", "17:00", "13:00", "14:00")
            //    // Add more test cases as needed
            //};

            CalculateLateServices services = new CalculateLateServices();
            
            var inputs = services.SetListData();
            // Calculate late times
            var lateTimes = services.ListCalculateLate(inputs);

            // Assert the calculated late times match the expected late times
            foreach (var item in lateTimes)
            {
                Console.WriteLine("Late time: {0}", item.ToString());
            }
            
        }
    }
}