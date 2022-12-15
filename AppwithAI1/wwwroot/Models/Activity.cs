using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GanttChartDataModel
{
    public class Activity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }
        public List<int> PrecedingTasks { get; set; }
        public int Duration { get; set; }
        public string Id { get; set; }




        public struct DateTime
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
            public int Hour { get; set; }
            public int Minute { get; set; }
            public int Second { get; set; }
            public int Millisecond { get; set; }
            public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
            {
                Year = year;
                Month = month;
                Day = day;
                Hour = hour;
                Minute = minute;
                Second = second;
                Millisecond = millisecond;
            }
        }
        public override string ToString() => JsonSerializer.Serialize<Activity>(this);
        
    }
}

/*
# DateTime currentDateTime = new DateTime(2021, 5, 12, 15, 30, 0, 0);