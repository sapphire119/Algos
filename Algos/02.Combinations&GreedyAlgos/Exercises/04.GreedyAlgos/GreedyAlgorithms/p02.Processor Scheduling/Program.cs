namespace p02.Processor_Scheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputTasks = int.Parse(Console.ReadLine().Split(' ')[1]);
            var tasks = new List<Task>();
            var maxDeadline = -1;
            
            for (int i = 0; i < inputTasks; i++)
            {
                var tokens = Console.ReadLine().Split('-');
                var inputValue = ParseToInt(tokens[0].Trim());
                var inputDeadline = ParseToInt(tokens[tokens.Length - 1].Trim());

                if (inputDeadline > maxDeadline) maxDeadline = inputDeadline;

                tasks.Add(new Task(inputValue, inputDeadline, i + 1));
            }

            var temp = tasks.OrderByDescending(x => x.Value).ThenBy(x => x.DeadLine).ToList();

            SortByDeadline(temp, inputTasks);

            var step = 1;
            var result = new List<Task>();
            while (step <= inputTasks)
            {
                var currentEle = temp[step - 1];
                if (currentEle.DeadLine >= step)
                {
                    result.Add(temp[step - 1]); 
                }
                step++;
            }

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", result.Select(x => x.CurrentTask))}");
            Console.WriteLine($"Total value: {result.Sum(x => x.Value)}");
        }

        private static void SortByDeadline(List<Task> temp, int totalTasks)
        {
            var currentStep = 1;
            var currentIndex = 0;
            while (currentStep <= totalTasks && currentIndex < temp.Count - 1)
            {
                var currentEle = temp[currentIndex];

                var tempCurrentIndex = currentIndex;
                var tempNextIndex = currentIndex + 1;
                var tempNextEle = temp[tempNextIndex];
                if (currentEle.DeadLine > currentStep && currentEle.DeadLine > tempNextEle.DeadLine)
                {
                    var totalMoveStepsRemaining = currentEle.DeadLine - currentStep;
                    if (totalMoveStepsRemaining <= 0) { currentStep++; continue; }
                    
                    while (currentEle.DeadLine > tempNextEle.DeadLine && totalMoveStepsRemaining > 0)
                    {
                        Switch(temp, tempCurrentIndex, tempNextIndex);
                        tempCurrentIndex = tempNextIndex;
                        tempNextIndex++;
                        totalMoveStepsRemaining--;
                        if (tempNextIndex >= temp.Count) break;
                        tempNextEle = temp[tempNextIndex];
                    }
                }
                else
                {
                    currentIndex++;
                    currentStep++;
                }
            }
        }

        private static void Switch(List<Task> list, int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
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

            public override string ToString()
            {
                return $"Row {this.CurrentTask}: {this.Value} -> {this.DeadLine}";
            }
        }

        private static int ParseToInt(string input)
        {
            return int.Parse(input);
        }
    }
}