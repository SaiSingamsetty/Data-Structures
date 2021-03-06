﻿namespace DataStructures.ProblemSolving.LeetCode.Contest.May16
{
    public class BusyStudent
    {
        public static void Init()
        {
            var res1 = Execute(new[] {1, 2, 3}, new[] {3, 2, 7}, 4);
        }

        private static int Execute(int[] startTime, int[] endTime, int queryTime)
        {
            var studentCounter = 0;

            for (var i = 0; i < startTime.Length; i++)
                if (startTime[i] <= queryTime && queryTime <= endTime[i])
                    studentCounter++;

            return studentCounter;
        }
    }
}