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
            MyTime time = new MyTime(3,4,5);
            Console.WriteLine(time.Hour);
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
    }
}
