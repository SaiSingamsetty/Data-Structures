﻿using System;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    // Challenge 15: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3330/
    // Given a circular array C of integers represented by A, find the maximum possible sum of a non-empty sub array of C.
    // Here, a circular array means the end of the array connects to the beginning of the array.  (Formally, C[i] = A[i] when 0 <= i < A.length, and C[i+A.length] = C[i] when i >= 0.)
    // Also, a sub array may only include each element of the fixed buffer A at most once.  (Formally, for a sub array C[i], C[i+1], ..., C[j], there does not exist i <= k1, k2 <= j with k1 % A.length = k2 % A.length.)
    // Example 1:
    // Input: [1,-2,3,-2]
    // Output: 3
    // Explanation: Sub array [3] has maximum sum 3
    // Example 2:
    // Input: [5,-3,5]
    // Output: 10
    // Explanation: Sub array [5,5] has maximum sum 5 + 5 = 10
    // Example 3:
    // Input: [3,-1,2,-1]
    // Output: 4
    // Explanation: Sub array [2,-1,3] has maximum sum 2 + (-1) + 3 = 4
    // Example 4:
    // Input: [3,-2,2,-3]
    // Output: 3
    // Explanation: Sub array [3] and [3,-2,2] both have maximum sum 3
    // Example 5:
    // Input: [-2,-3,-1]
    // Output: -1
    // Explanation: Sub array [-1] has maximum sum -1
    // NOTE:
    // -30000 <= A[i] <= 30000
    // 1 <= A.length <= 30000

    public class CircularSubArray
    {
        public static void Init()
        {
            var res1 = MaxSubArraySumCircular(new[] {1, -2, 3, -2}); //3
            var res2 = MaxSubArraySumCircular(new[] {5, -3, 5}); //10
            var res3 = MaxSubArraySumCircular(new[] {3, -1, 2, -1}); //4
            var res4 = MaxSubArraySumCircular(new[] {3, -2, 2, -3}); //3
            var res5 = MaxSubArraySumCircular(new[] {-2, -3, -1}); //-1
        }

        //Ref: https://www.youtube.com/watch?v=kssIQAIg9c8

        private static int MaxSubArraySumCircular(int[] A)
        {
            var maxSumUsingKadanesForFixedArray = FindSubArrayMaxSumUsingKadanesAlgo(A);

            var totalSum = A.Sum();
            var invertedArray = A.Select(x => -x).ToArray();
            var kadanesMaxSumForInvertedArray = FindSubArrayMaxSumUsingKadanesAlgo(invertedArray);
            var maxSumForCircularArray = totalSum + kadanesMaxSumForInvertedArray;

            if (maxSumForCircularArray > maxSumUsingKadanesForFixedArray && maxSumForCircularArray != 0)
                return maxSumForCircularArray;

            return maxSumUsingKadanesForFixedArray;
        }

        private static int FindSubArrayMaxSumUsingKadanesAlgo(int[] nums)
        {
            var maxSoFar = nums[0];
            var curMax = nums[0];
            var size = nums.Length;

            for (var i = 1; i < size; i++)
            {
                curMax = Math.Max(nums[i], curMax + nums[i]);
                maxSoFar = Math.Max(maxSoFar, curMax);
            }

            return maxSoFar;
        }
    }
}