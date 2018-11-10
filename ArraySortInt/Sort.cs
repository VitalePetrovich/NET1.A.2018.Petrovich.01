using System;
using System.Collections.Generic;
using System.Data;
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
        public static void QuickSort<T>(T[] sortingArray, int lowIndex, int highIndex) where T : IComparable
        {
            void QuickSortAlgorithm(T[] sortingArrayAlg, int lowIndexAlg, int highIndexAlg) 
            {
                if (lowIndexAlg > highIndexAlg)
                {
                    return;
                }

                int currMinIndex = lowIndexAlg - 1;
                int root = highIndexAlg;
                for (int i = lowIndexAlg; i < root; i++)
                {
                    if (sortingArrayAlg[i].CompareTo(sortingArrayAlg[root]) < 0)
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
        /// <exception cref="ArgumentNullException">
        /// Throws when the sorting array is not initialized.
        /// </exception>>
        public static void QuickSort<T>(T[] sortingArray) where T : IComparable
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
        public static void MergeSort<T>(T[] sortingArray, int lowIndex, int highIndex) where T : IComparable
        {
            void MergeSortAlgorithm(T[] sortingArrayAlg, int lowIndexAlg, int highIndexAlg)
            {
                if (lowIndexAlg >= highIndexAlg)
                {
                    return;
                }

                int middle = (lowIndexAlg + highIndexAlg) / 2;
                T[] leftSide = new T[middle + 1];
                T[] rightSide = new T[highIndexAlg - middle];

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
        /// <exception cref="ArgumentNullException">
        /// Throws when the sorting array is not initialized.
        /// </exception>>
        public static void MergeSort<T>(T[] sortingArray) where T : IComparable
        {
            if (sortingArray == null)
            {
                throw new ArgumentNullException(nameof(sortingArray));
            }

            MergeSort(sortingArray, 0, sortingArray.Length - 1);
        }

        private static void Merger<T>(T[] targetArr, T[] leftSide, T[] rightSide) where T : IComparable
        {
            int leftSideLen = leftSide.Length - 1;
            int rightSideLen = rightSide.Length - 1;
            int targetArrIndex = 0;
            int leftSideIndex = 0;
            int rightSideIndex = 0;

            while (leftSideIndex <= leftSideLen && rightSideIndex <= rightSideLen)
            {
                if (leftSide[leftSideIndex].CompareTo(rightSide[rightSideIndex]) < 0)
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

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Binary search of key value in source array.
        /// Source array must be sorted by ascendancy.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="sourceArray">Array of elements.</param>
        /// <param name="keyValue">Key value.</param>
        /// <param name="lowIndex">Low index of searching.</param>
        /// <param name="highIndex">High index of searching.</param>
        /// <exception cref="ArgumentNullException">Throws if source array or key value has null reference.</exception>
        /// <exception cref="ArgumentException">Throws if entered invalid low or high index, or source array is not sorted.</exception>
        /// <returns>
        /// Index of first entry key value in source array.
        /// -1 if key value doesn't exist in source array.
        /// </returns>
        public static int BinarySearch<T>(T[] sourceArray, T keyValue, int lowIndex, int highIndex) where T : IComparable
        {
            if (ReferenceEquals(sourceArray, null)) 
                throw new ArgumentNullException(nameof(sourceArray));

            if (ReferenceEquals(keyValue, null))
                throw new ArgumentNullException(nameof(keyValue));

            if (lowIndex < 0)
                throw new ArgumentException($"Value of {nameof(lowIndex)} is less than 0!");

            if (highIndex < 0)
                throw new ArgumentException($"Value of {nameof(highIndex)} is less than 0!");

            if (lowIndex > highIndex)
                throw new ArgumentException($"Value of {nameof(lowIndex)} must be less than value of {nameof(highIndex)}!");

            if (!IsOrdered(sourceArray))
                throw new ArgumentException($"{nameof(sourceArray)} not sorted by ascending!");

            int leftEdge = lowIndex;
            int rightEdge = highIndex;

            while (leftEdge < rightEdge)
            {
                int middle = (leftEdge + rightEdge) / 2;
                if (sourceArray[middle].CompareTo(keyValue) == 0)
                {
                    while (middle > 0 && sourceArray[middle - 1].CompareTo(keyValue) == 0)
                    {
                        middle--;
                    }

                    return middle;
                }

                if (sourceArray[middle].CompareTo(keyValue) > 0)
                {
                    rightEdge = middle - 1;
                }

                if (sourceArray[middle].CompareTo(keyValue) < 0)
                {
                    leftEdge = middle + 1;
                }
            }
           
            return -1;
        }

        /// <summary>
        /// Binary search of key value in source array.
        /// Source array must be ordered by ascendancy.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="sourceArray">Array of elements.</param>
        /// <param name="keyValue">Key value.</param>
        /// <exception cref="ArgumentNullException">Throws if source array or key value has null reference.</exception>
        /// <exception cref="ArgumentException">Throws if source array is not sorted.</exception>
        /// <returns>
        /// Index of first entry key value in source array.
        /// -1 if key value doesn't exist in source array.
        /// </returns>
        public static int BinarySearch<T>(T[] sourceArray, T keyValue) where T : IComparable
        {
            if (ReferenceEquals(sourceArray, null))
                throw new ArgumentNullException(nameof(sourceArray));

            return BinarySearch(sourceArray, keyValue, 0, sourceArray.Length - 1);
        }

        private static bool IsOrdered<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 2; i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0)
                    return false;
            }

            return true;
        }
    }
}
