using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRByte
{
    public class InformationTime
    {
        private DateTime shiftStartTime;
        private DateTime shiftEndTime;
        private DateTime breakStartTime;
        private DateTime breakEndTime;
        private DateTime signInTime;
        private DateTime leaveFromTime;
        private DateTime leaveToTime;
        private TimeSpan shiftDuration;
        private TimeSpan breakDuration;
        private TimeSpan leaveDuration;
        private TimeSpan lateTime;
        public InformationTime(string shiftStart, string shiftEnd, string breakStart, string breakEnd, string signIn, string leaveFrom = null, string leaveTo = null)
        {
            shiftStartTime = DateTime.ParseExact(shiftStart, "HH:mm", null);
            shiftEndTime = DateTime.ParseExact(shiftEnd, "HH:mm", null);
            breakStartTime = DateTime.ParseExact(breakStart, "HH:mm", null);
            breakEndTime = DateTime.ParseExact(breakEnd, "HH:mm", null);
            signInTime = DateTime.ParseExact(signIn, "HH:mm", null);
            if (!string.IsNullOrEmpty(leaveFrom) && !string.IsNullOrEmpty(leaveTo))
            {
                leaveFromTime = DateTime.ParseExact(leaveFrom, "HH:mm", null);
                leaveToTime = DateTime.ParseExact(leaveTo, "HH:mm", null);
            }
        }
        public DateTime ShiftStartTime
        {
            get { return shiftStartTime; }
            set { shiftStartTime = value; }
        }
        public DateTime ShiftEndTime
        {
            get { return shiftEndTime; }
            set { shiftEndTime = value; }
        }
        public DateTime BreakStartTime
        {
            get { return breakStartTime; }
            set { breakStartTime = value; }
        }
        public DateTime BreakEndTime
        {
            get { return breakEndTime; }
            set { breakEndTime = value; }
        }
        public DateTime SignInTime
        {
            get { return signInTime; }
            set { signInTime = value; }
        }
        public DateTime? LeaveFromTime
        {
            get { return leaveFromTime; }
            set { leaveFromTime = value ?? DateTime.MinValue; }
        }
        public DateTime? LeaveToTime
        {
            get { return leaveToTime; }
            set { leaveToTime = value ?? DateTime.MinValue; }
        }
        public TimeSpan ShiftDuration
        {
            get { return shiftDuration; }
            set { shiftDuration = value; }
        }
        public TimeSpan LeaveDuration
        {
            get { return leaveDuration; }
            set { leaveDuration = value; }
        }
        public TimeSpan BreakDuration
        {
            get { return breakDuration; }
            set { breakDuration = value; }
        }
        public TimeSpan LateTime
        {
            get { return lateTime; }
            set
            {
                lateTime = value;
            }
        }

    }
}
