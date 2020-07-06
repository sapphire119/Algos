namespace p02.Processor_Scheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;

    public class Program
    {
        public static void Main()
        {
            var inputTasks = int.Parse(Console.ReadLine().Split(' ')[1]);
            var tasks = new List<Task>();
            for (int i = 0; i < inputTasks; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var inputValue = ParseToInt(tokens[0]);
                var inputDeadline = ParseToInt(tokens[tokens.Length - 1]);

                tasks.Add(new Task(inputValue, inputDeadline, i + 1));
            }

            tasks = tasks.OrderByDescending(x => x.ValueDeadlineCoeff).ThenByDescending(x => x.Value).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, tasks));
            ;
        }

        public class Task
        {
            public Task(int value, int deadLine, int currentTask)
            {
                this.Value = value;
                this.DeadLine = deadLine;
                this.CurrentTask = currentTask;
            }

            public int Value { get; set; }
            public int DeadLine { get; set; }
            public int CurrentTask { get; }

            public double ValueDeadlineCoeff => this.Value / (double)this.DeadLine;

            public override string ToString()
            {
                return $"Row: {this.CurrentTask} -> {this.Value} -> {this.DeadLine}";
            }
        }

        private static int ParseToInt(string input)
        {
            return int.Parse(input);
        }
    }
}