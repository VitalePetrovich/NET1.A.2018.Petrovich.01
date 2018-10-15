using System;
using System.Collections.Generic;
using System.Data;
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
        /// <param name="sortingArray">
        /// Source array.
        /// </param>
        /// <param name="lowIndex">
        /// Sorting starts with this array index.
        /// </param>
        /// <param name="highIndex">
        /// Sorting ends with this array index.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when at least one of the indexes is outside the array.
        /// </exception>>
        /// <exception cref="ArgumentNullException">
        /// Throws when the sorting array is not initialized.
        /// </exception>>
        public static void QuickSort(int[] sortingArray, int lowIndex, int highIndex)
        {
            void QuickSortAlgorithm(int[] sortingArrayAlg, int lowIndexAlg, int highIndexAlg)
            {
                if (lowIndexAlg > highIndexAlg)
                {
                    return;
                }

                int currMinIndex = lowIndexAlg - 1;
                int root = highIndexAlg;
                for (int i = lowIndexAlg; i < root; i++)
                {
                    if (sortingArrayAlg[i] < sortingArrayAlg[root])
                    {
                        Swap(ref sortingArrayAlg[i], ref sortingArrayAlg[++currMinIndex]);
                    }
                }

                Swap(ref sortingArrayAlg[++currMinIndex], ref sortingArrayAlg[root]);

                QuickSortAlgorithm(sortingArrayAlg, lowIndexAlg, currMinIndex - 1);
                QuickSortAlgorithm(sortingArrayAlg, currMinIndex + 1, highIndexAlg);
            }

            if (sortingArray == null)
            {
                throw new ArgumentNullException(nameof(sortingArray));
            }

            if (lowIndex < 0 || highIndex >= sortingArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (lowIndex > highIndex)
            {
                Swap(ref lowIndex, ref highIndex);
            }

            QuickSortAlgorithm(sortingArray, lowIndex, highIndex);
        }

        /// <summary>
        /// Quick sort method.
        /// </summary>
        /// <param name="sortingArray">
        /// Source array.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when at least one of the indexes is outside the array.
        /// </exception>>
        /// <exception cref="ArgumentNullException">
        /// Throws when the sorting array is not initialized.
        /// </exception>>
        public static void QuickSort(int[] sortingArray)
        {
            if (sortingArray == null)
            {
                throw new ArgumentNullException(nameof(sortingArray));
            }

            QuickSort(sortingArray, 0, sortingArray.Length - 1);
        }


        /// <summary>
        /// Merge sort method.
        /// </summary>
        /// <param name="sortingArray">
        /// Source array.
        /// </param>
        /// <param name="lowIndex">
        /// Sorting starts with this array index.
        /// </param>
        /// <param name="highIndex">
        /// Sorting ends with this array index.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when at least one of the indexes is outside the array.
        /// </exception>>
        /// <exception cref="ArgumentNullException">
        /// Throws when the sorting array is not initialized.
        /// </exception>>
        public static void MergeSort(int[] sortingArray, int lowIndex, int highIndex)
        {
            void MergeSortAlgorithm(int[] sortingArrayAlg, int lowIndexAlg, int highIndexAlg)
            {
                if (lowIndexAlg >= highIndexAlg)
                {
                    return;
                }

                int middle = (lowIndexAlg + highIndexAlg) / 2;
                int[] leftSide = new int[middle + 1];
                int[] rightSide = new int[highIndexAlg - middle];

                Array.Copy(sortingArrayAlg, 0, leftSide, 0, middle + 1);
                Array.Copy(sortingArrayAlg, middle + 1, rightSide, 0, highIndexAlg - middle);

                MergeSortAlgorithm(leftSide, 0, leftSide.Length - 1);
                MergeSortAlgorithm(rightSide, 0, rightSide.Length - 1);
                
                Merger(sortingArrayAlg, leftSide, rightSide); 
            }

            if (sortingArray == null)
            {
                throw new ArgumentNullException(nameof(sortingArray));
            }

            if (lowIndex < 0 || highIndex >= sortingArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (lowIndex > highIndex)
            {
                Swap(ref lowIndex, ref highIndex);
            }

            MergeSortAlgorithm(sortingArray, lowIndex, highIndex);
        }

        /// <summary>
        /// Merge sort method.
        /// </summary>
        /// <param name="sortingArray">
        /// Source array.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when at least one of the indexes is outside the array.
        /// </exception>>
        /// <exception cref="ArgumentNullException">
        /// Throws when the sorting array is not initialized.
        /// </exception>>
        public static void MergeSort(int[] sortingArray)
        {
            if (sortingArray == null)
            {
                throw new ArgumentNullException(nameof(sortingArray));
            }

            MergeSort(sortingArray, 0, sortingArray.Length - 1);
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

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
