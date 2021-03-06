﻿using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // Challenge 8 : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3323/
    // You are given an array coordinates, coordinates[i] = [x, y], where [x, y] represents the coordinate of a point. Check if these points make a straight line in the XY plane.
    // Input: coordinates = [[1,2],[2,3],[3,4],[4,5],[5,6],[6,7]]
    // Output: true
    // Input: coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
    // Output: false

    public class StraightLine
    {
        public static void Init()
        {
            var coordinates = new int[5][]
            {
                new[] {1, 1},
                new[] {2, 2},
                new[] {3, 4},
                new[] {4, 5},
                new[] {5, 6}
            };
            var res = CheckStraightLine(coordinates);
            Console.WriteLine(res);
        }

        #region Approach 1: Slopes (Comparison of various coordinates with first point)

        private static bool AreStraight(int[][] coordinates)
        {
            var coordinatesCount = coordinates.Length;

            if (coordinatesCount == 2)
                return true;

            var prevXy = coordinates[0];
            decimal slope = int.MinValue;

            //Compare slopes of various points with first point only
            for (var i = 1; i < coordinatesCount; i++)
            {
                var tempXy = coordinates[i];
                var tempSlope = (decimal) (tempXy[0] - prevXy[0]) != 0
                    ? (tempXy[1] - prevXy[1]) / (decimal) (tempXy[0] - prevXy[0])
                    : int.MaxValue; //handling divide by 0 case (Max slope Infinite -> int.MaxValue)

                if (slope == int.MinValue)
                    slope = tempSlope; //Assigning value only for initial case

                if (slope != tempSlope)
                    return false;
            }

            return true;
        }

        #endregion

        #region Approach 2: Slopes (Comparing of Slopes : any point with first point should be equal to slope between first two point)

        private static bool CheckStraightLine(int[][] coordinates)
        {
            //Slope between any point with first point should be equal to slope between first two point
            // (yi - y0)/(xi - x0) = (y1 - y0)/(x1 - x0)
            // => (yi - y0) * (x1 - x0) = (y1 - y0) * (xi - x0) 

            for (var i = 2; i < coordinates.Length; i++)
                if ((coordinates[i][1] - coordinates[0][1]) * (coordinates[1][0] - coordinates[0][0]) !=
                    (coordinates[i][0] - coordinates[0][0]) * (coordinates[1][1] - coordinates[0][1]))
                    return false;

            return true;
        }

        #endregion
    }
}