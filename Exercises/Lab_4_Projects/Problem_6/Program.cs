using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Problem_6
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int[] input1 = { 1, 2, 3, 4, 5, 6 };
            int[] input2 = { 7, 8, 9, 10, 11, 12, 13 };

            for (int i = 0; i < input2.Length+input1.Length-1; i++)
            {
                Console.WriteLine(Merge(input1, input2)[i]);

            }
        }
        static public int[] Merge(int[] array1, int[] array2)
        {
            int arr1Len = array1.Length;
            int arr2Len = array2.Length;

            int[] mergedArray = new int[arr1Len + arr2Len];

            int left1 = 0;
            int left2 = 0;
            int i = 0;

            for (; left1 < array1.Length && left2 < array2.Length; i++)
            {
                if (array1[left1] <= array2[left2])
                {
                    mergedArray[i] = array1[left1++];
                }
                else
                {
                    mergedArray[i] = array2[left2++];
                }
            }

            while (left1 < arr1Len)
            {
                mergedArray[i++] = array1[left1++];
            }
            while (left2 < arr1Len)
            {
                mergedArray[i++] = array2[left2++];
            }

            return mergedArray;
        }


    }


}
