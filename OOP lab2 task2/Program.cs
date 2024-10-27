using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTime time = new MyTime(13,45,55);
            Console.WriteLine(time.Hour);
            Console.WriteLine(time.ToSecSinceMidnight());
            MyTime time2 = MyTime.FromSecSinceMidnight(3600);
            Console.WriteLine(time2);
            MyTime time3 = time2.AddOneMinute().AddSeconds(3539).AddOneSecond();
            Console.WriteLine(time3);


            Console.ReadLine();
        }
    }
    public class MyTime
    {
        protected int hour, minute, second;
        public MyTime(MyTime copy)
        {
            hour = copy.hour;
            minute = copy.minute;
            second = copy.second;
        }
        public MyTime(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        public int Minute
        {
            get { return minute; }
            set { minute = value; }
        }
        public int Second
        {
            get { return second; }
            set { second = value; }
        }
        public override string ToString()
        {
            return $"{hour}:{minute:D2}:{second:D2}";
        }
        public int ToSecSinceMidnight()
        {
            return hour * 3600 + minute * 60 + second;
        }
        public static MyTime FromSecSinceMidnight(int seconds)
        {
            int secPerDay = 86400;
            seconds %= secPerDay;
            if (seconds < 0)
                seconds += secPerDay;

            int hour = seconds / 3600;
            int minute = (seconds / 60) % 60;
            int second = seconds % 60;
            MyTime time = new MyTime(hour, minute, second);
            return time;
        }
        public MyTime AddSeconds(int seconds)
        {
            int totalSeconds = ToSecSinceMidnight() + seconds;
            return FromSecSinceMidnight(totalSeconds);
        }
        public MyTime AddOneSecond()
        {
            return AddSeconds(1);
        }

        public MyTime AddOneMinute()
        {
            return AddSeconds(60);
        }

        public MyTime AddOneHour()
        {
            return AddSeconds(3600);
        }
        public static int Difference(MyTime time1, MyTime time2)
        {
            return time1.ToSecSinceMidnight() - time2.ToSecSinceMidnight();
        }
        public static bool IsInRange(MyTime start, MyTime finish, MyTime time)
        {
            int startSec = start.ToSecSinceMidnight();
            int finishSec = finish.ToSecSinceMidnight();
            int timeSec = time.ToSecSinceMidnight();

            if (startSec < finishSec)
            {
                return timeSec >= startSec && timeSec <= finishSec;
            }
            else
            {
                return timeSec >= startSec || timeSec <= finishSec;
            }
        }
    }
}
