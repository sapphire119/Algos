namespace p04.Best_Lecture_s_Schedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class Program
    {
        public static void Main()
        {
            var lectures = new List<Lecture>();
            var inputLecturesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (int i = 0; i < inputLecturesCount; i++)
            {
                var inputLecture = Console.ReadLine();
                var tokens = inputLecture.Split(':');
                var lectureName = tokens[0];

                var timeTokens = tokens[1].Trim().Split('-').Select(x => x.Trim()).Select(int.Parse).ToArray();
                var startTime = timeTokens[0];
                var endTime = timeTokens[1];
                
                lectures.Add(new Lecture(lectureName, startTime, endTime));
            }

            var currentLecture = lectures.OrderBy(x => x.EndTime).FirstOrDefault();

            var result = new List<Lecture> { currentLecture };
            foreach (var lecture in lectures.OrderBy(x => x.EndTime))
            {
                if(currentLecture.EndTime <= lecture.StartTime)
                {
                    result.Add(lecture);
                    currentLecture = lecture;
                }
            }

            Console.WriteLine($"Lectures ({result.Count}):");
            Console.WriteLine($"{string.Join(Environment.NewLine, result)}");
        }
    }

    public class Lecture
    {
        public Lecture(string name, int startTime, int endTime)
        {
            this.Name = name;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public string Name { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public override string ToString()
        {
            //1-7 -> Java
            return $"{this.StartTime}-{this.EndTime} -> {this.Name}";
        }
    }
}
