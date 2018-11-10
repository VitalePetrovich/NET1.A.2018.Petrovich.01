using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ArraySortInt.Sort;

namespace ArraySortInt.Test
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void QuickSort_MixedRandomArray50Elements_SortedArrayReturned()
        {
            const int N = 50;
            int[] sourceArray = CreateRandomArray(N);
           
            QuickSort(sourceArray);

            Assert.IsTrue(IsOrdered(sourceArray));
        }

        [TestMethod]
        public void QuickSort_MixedRandomArray50000Elements_SortedArrayReturned()
        {
            const int N = 500000;
            int[] sourceArray = CreateRandomArray(N);

            QuickSort(sourceArray);

            Assert.IsTrue(IsOrdered(sourceArray));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_TrowArgumentNullException()
            => QuickSort<int>(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuickSort_TrowArgumentOutOfRangeException()
            => QuickSort(new int[0], -1, 0);

        [TestMethod]
        public void MergeSort_MixedRandomArray50Elements_SortedArrayReturned()
        {
            int N = 50;
            int[] sourceArray = CreateRandomArray(N);

            MergeSort(sourceArray);

            Assert.IsTrue(IsOrdered(sourceArray));
        }

        [TestMethod]
        public void MergeSort_MixedRandomArray50000_SortedArrayReturned()
        {
            int N = 500000;
            int[] sourceArray = CreateRandomArray(N);

            MergeSort(sourceArray);

            Assert.IsTrue(IsOrdered(sourceArray));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_TrowArgumentNullException()
            => MergeSort<int>(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MergeSort_TrowArgumentOutOfRangeException()
            => MergeSort(new int[0], -1, 0);

        private int[] CreateRandomArray(int numberOfElements)
        {
            Random rnd = new Random();
            int[] randomArray = new int[numberOfElements];
            for (int i = 0; i < numberOfElements; i++)
            {
                randomArray[i] = rnd.Next(-100, 100);
            }

            return randomArray;
        }

        private bool IsOrdered(int[] arr)
        {
            int arrLength = arr.Length;
            bool isOrdered = true;
            for (int i = 0; i < arrLength - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    isOrdered = false;
                }
            }

            return isOrdered;
        }
    }
}
