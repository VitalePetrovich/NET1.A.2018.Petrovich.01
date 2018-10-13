using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortInt
{
    /// <summary>
    /// Sorts class. Contains a quick sort and merge sort methods.
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Quick sort method.
        /// </summary>
        /// <param name="arr">
        /// Source array.
        /// </param>
        /// <param name="lowIndex">
        /// Sorting starts with this array index.
        /// </param>
        /// <param name="highIndex">
        /// Sorting ends with this array index.
        /// </param>
        public static void QuickSort(int[] arr, int lowIndex, int highIndex)
        {
            if (lowIndex > highIndex)
            {
                return;
            }

            int currMinIndex = lowIndex - 1;
            int root = highIndex;
            for (int i = lowIndex; i < root; i++)
            {
                if (arr[i] < arr[root])
                {
                    Swap(ref arr[i], ref arr[++currMinIndex]);
                }
            }

            Swap(ref arr[++currMinIndex], ref arr[root]);

            QuickSort(arr, lowIndex, currMinIndex - 1);
            QuickSort(arr, currMinIndex + 1, highIndex);
        }

        /// <summary>
        /// Quick sort method.
        /// </summary>
        /// <param name="arr">
        /// Source array.
        /// </param>
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Merge sort method.
        /// </summary>
        /// <param name="arr">
        /// Source array.
        /// </param>
        /// <param name="lowIndex">
        /// Sorting starts with this array index.
        /// </param>
        /// <param name="highIndex">
        /// Sorting ends with this array index.
        /// </param>
        public static void MergeSort(int[] arr, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int middle = (lowIndex + highIndex) / 2;
                int[] leftSide = new int[middle + 1];
                int[] rightSide = new int[highIndex - middle];

                Array.Copy(arr, 0, leftSide, 0, middle + 1);
                Array.Copy(arr, middle + 1, rightSide, 0, highIndex - middle);

                MergeSort(leftSide, 0, leftSide.Length - 1);
                MergeSort(rightSide, 0, rightSide.Length - 1);

                Merger(arr, leftSide, rightSide);
            }
        }

        /// <summary>
        /// Merge sort method.
        /// </summary>
        /// <param name="arr">
        /// Source array.
        /// </param>
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void Merger(int[] targetArr, int[] leftSide, int[] rightSide)
        {
            int leftSideLen = leftSide.Length - 1;
            int rightSideLen = rightSide.Length - 1;
            int targetArrIndex = 0;
            int leftSideIndex = 0;
            int rightSideIndex = 0;

            while (leftSideIndex <= leftSideLen && rightSideIndex <= rightSideLen)
            {
                if (leftSide[leftSideIndex] < rightSide[rightSideIndex])
                {
                    targetArr[targetArrIndex++] = leftSide[leftSideIndex++];
                }
                else
                {
                    targetArr[targetArrIndex++] = rightSide[rightSideIndex++];
                }
            }

            while (leftSideIndex <= leftSideLen)
            {
                targetArr[targetArrIndex++] = leftSide[leftSideIndex++];
            }

            while (rightSideIndex <= rightSideLen)
            {
                targetArr[targetArrIndex++] = rightSide[rightSideIndex++];
            }
        }
    }
}
