using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRByte
{
    public class CalculateLateServices
    {
        public CalculateLateServices() { }

        public List<TimeSpan> ListCalculateLate(List<InformationTime> inputs)
        {
            List<TimeSpan> lateTimes = new List<TimeSpan>();
            foreach (var input in inputs)
            {
                // Add late time to the list
                var late = CalculateTimeLate(input);
                lateTimes.Add(late);
            }
            return lateTimes;
        }

        public TimeSpan CalculateTimeLate(InformationTime input)
        {
            // Calculate shift duration
            input.ShiftDuration = input.ShiftEndTime - input.ShiftStartTime;
            // Calculate break duration
            input.BreakDuration = input.BreakEndTime - input.BreakStartTime;
            // Calculate late time
            // If sign in is within shift start and before the break, adjust late time
            input.LateTime = input.SignInTime - input.ShiftStartTime;

            // If sign in is within shift end and greater the break, adjust late time
            if (input.SignInTime <= input.ShiftEndTime && input.SignInTime >= input.BreakEndTime)
            {
                // Subtract break duration if sign-in is before the break
                input.LateTime -= input.BreakDuration;
            }
            // If sign in is greater after shift end, late time is negative
            if (input.SignInTime > input.ShiftEndTime)
            {
                input.LateTime = (input.SignInTime - input.ShiftEndTime) + (input.ShiftDuration - input.BreakDuration);
            }
            // If leave time is provided, adjust late time
            if ((input.LeaveFromTime.HasValue && input.LeaveFromTime != DateTime.MinValue) && (input.LeaveToTime.HasValue && input.LeaveToTime.Value != DateTime.MinValue))
            {
                input.LeaveDuration = input.LeaveToTime.Value - input.LeaveFromTime.Value;

                if (input.LeaveFromTime.Value <= input.SignInTime && input.SignInTime <= input.LeaveToTime.Value)
                {
                    input.LateTime -= (input.SignInTime - input.LeaveFromTime.Value);
                }
                else if (input.SignInTime > input.LeaveToTime.Value)
                {
                    input.LateTime = input.LateTime - input.LeaveDuration;
                }
                else if (input.BreakStartTime <= input.SignInTime && input.SignInTime <= input.BreakEndTime)
                {
                    input.LateTime -= (input.SignInTime - input.BreakStartTime);
                }
                else if (input.SignInTime > input.BreakEndTime)
                {
                    input.LateTime -=  input.BreakDuration;
                }
                   
            }
            // If late time is negative, set it to zero
            if (input.LateTime < TimeSpan.Zero)
            {
                input.LateTime = TimeSpan.Zero;
            }
            return input.LateTime;
        }

        public List<InformationTime> SetListData()
        {
            InformationTime informationTime = new InformationTime("08:00", "17:00", "12:00", "13:00", "08:15", null, null); // 15m
            InformationTime informationTime1 = new InformationTime("08:00", "17:00", "12:00", "13:00", "13:15", null, null); // 4h15m
            InformationTime informationTime2 = new InformationTime("08:00", "17:00", "12:00", "13:00", "10:15", "08:00", "10:00"); //15m
            InformationTime informationTime3 = new InformationTime("08:00", "17:00", "12:00", "13:00", "13:15", "09:00", "12:00"); //1h:15m
            InformationTime informationTime4 = new InformationTime("08:00", "17:00", "12:00", "13:00", "13:15", "09:00", "11:00"); //2h:15m
            InformationTime informationTime5 = new InformationTime("08:00", "17:00", "12:00", "13:00", "10:15", "09:00", "11:00"); //1h
            InformationTime informationTime6 = new InformationTime("08:00", "17:00", "12:00", "13:00", "14:00", "13:00", "15:00"); //4h
            InformationTime informationTime7 = new InformationTime("08:00", "17:00", "12:00", "13:00", "09:15", "08:00", "10:00"); //0h
            InformationTime informationTime8 = new InformationTime("08:00", "17:00", "12:00", "13:00", "11:15", "09:00", "11:00"); // 1h15m
            InformationTime informationTime9 = new InformationTime("08:00", "17:00", "12:00", "13:00", "13:15", "09:00", "11:00"); // 2h15m
            InformationTime informationTime10 = new InformationTime("08:00", "17:00", "12:00", "13:00", "14:00", "09:00", "11:00"); //3h

            List<InformationTime> listDataInfor = new List<InformationTime>();

            listDataInfor.Add(informationTime);
            listDataInfor.Add(informationTime1);
            listDataInfor.Add(informationTime2);
            listDataInfor.Add(informationTime3);
            listDataInfor.Add(informationTime4);
            listDataInfor.Add(informationTime5);
            listDataInfor.Add(informationTime6);
            listDataInfor.Add(informationTime7);
            listDataInfor.Add(informationTime8);
            listDataInfor.Add(informationTime9);
            listDataInfor.Add(informationTime10);

            return listDataInfor;
        }
    }
    
}
