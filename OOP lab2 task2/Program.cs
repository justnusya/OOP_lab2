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
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Write the number of hours, minutes and seconds separated by a space");
            string[] data = Console.ReadLine().Trim().Split();
            int hour = int.Parse(data[0]);
            int min = int.Parse(data[1]);
            int sec = int.Parse(data[2]);

            MyTime currentTime = new MyTime(hour, min, sec);
            Console.WriteLine($"Current Time: {currentTime}");

            Console.WriteLine($"1 sec later: {currentTime.AddOneSecond()}");
            Console.WriteLine($"1 min later: {currentTime.AddOneMinute()}");
            Console.WriteLine($"1h later: {currentTime.AddOneHour()}");

            Console.WriteLine("Write a number of seconds to add");
            int sec2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Adding seconds: {currentTime.AddSeconds(sec2)}");

            Console.WriteLine("Another time to compare with: write the number of hours, minutes and seconds separated by a space");
            string[] data2 = Console.ReadLine().Trim().Split();
            int hour0 = int.Parse(data2[0]);
            int min0 = int.Parse(data2[1]);
            int sec0 = int.Parse(data2[2]);
            MyTime anotherTime = new MyTime(hour0, min0, sec0);

            Console.WriteLine($"Difference between {currentTime} and {anotherTime}: {MyTime.Difference(currentTime, anotherTime)} seconds");

            MyTime start = new MyTime(23, 59, 59);
            MyTime finish = new MyTime(1, 1, 1);
            Console.WriteLine($"Is {currentTime} in range {start} to {finish}? {MyTime.IsInRange(start, finish, currentTime)}");

            Console.WriteLine($"Lesson at {currentTime}: {MyTime.WhatLesson(currentTime)}");
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
            return Math.Abs(time1.ToSecSinceMidnight() - time2.ToSecSinceMidnight());
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
        public static string WhatLesson(MyTime currentTime)
        {
            MyTime[] lessonStartTimes = {
            new MyTime(8, 0, 0), //1
            new MyTime(9, 40, 0), //2
            new MyTime(11, 20, 0), //3
            new MyTime(13, 0, 0), //4
            new MyTime(14, 40, 0), //5
            new MyTime(16, 20, 0) //6
        };

            MyTime[] lessonEndTimes = {
            new MyTime(9, 20, 0), //1
            new MyTime(11, 0, 0), //2
            new MyTime(12, 40, 0), //3
            new MyTime(14, 20, 0), //4
            new MyTime(16, 0, 0), //5
            new MyTime(17, 40, 0) //6
        };

            if (currentTime.ToSecSinceMidnight() < lessonStartTimes[0].ToSecSinceMidnight())
            {
                return "пари ще не почалися";
            }

            if (currentTime.ToSecSinceMidnight() > lessonEndTimes[5].ToSecSinceMidnight())
            {
                return "пари вже скінчилися";
            }

            for (int i = 0; i < lessonStartTimes.Length; i++)
            {
                if (IsInRange(lessonStartTimes[i], lessonEndTimes[i], currentTime))
                {
                    return $"{i + 1}-а пара";
                }

                int nextIndex = (i + 1) % lessonEndTimes.Length;
                if (IsInRange(lessonEndTimes[i], lessonStartTimes[nextIndex], currentTime))
                {
                    return $"перерва між {i + 1}-ю та {nextIndex + 1}-ю парами";
                }
            }
            return null;
        }
    }
}
