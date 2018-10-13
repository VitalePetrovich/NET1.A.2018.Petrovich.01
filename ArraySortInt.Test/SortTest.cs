using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ArraySortInt.Sort;

namespace ArraySortInt.Test
{
    [TestClass]
    public class SortTest
    {
        private bool CheckOrderArray(int[] arr)
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

        [TestMethod]
        public void QuickSort_MixedRandomArray50Elements_SortedArrayReturned()
        {
            const int N = 50;
            Random rnd = new Random();
            int[] sourceArray = new int[N];
            //int[] expectedArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                sourceArray[i] = rnd.Next(-100, 100);
            }

            //Array.Copy(inputArray, expectedArray, inputArray.Length);
            //Array.Sort(expectedArray);

            QuickSort(sourceArray);

            //CollectionAssert.AreEqual(expectedArray, inputArray);
            Assert.IsTrue(CheckOrderArray(sourceArray));
        }

        [TestMethod]
        public void QuickSort_MixedRandomArray50000Elements_SortedArrayReturned()
        {
            const int N = 50000;
            Random rnd = new Random();
            int[] sourceArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                sourceArray[i] = rnd.Next(-100, 100);
            }

            QuickSort(sourceArray);

            Assert.IsTrue(CheckOrderArray(sourceArray));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuickSort_TrowNullReferenceException()
            => QuickSort(null);

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void QuickSort_TrowIndexOutOfRangeException()
            => QuickSort(new int[0], -1, 0);

        [TestMethod]
        public void MergeSort_MixedRandomArray50Elements_SortedArrayReturned()
        {
            int N = 50;
            Random rnd = new Random();
            int[] sourceArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                sourceArray[i] = rnd.Next(-100, 100);
            }

            MergeSort(sourceArray);

            Assert.IsTrue(CheckOrderArray(sourceArray));
        }

        [TestMethod]
        public void MergeSort_MixedRandomArray50000_SortedArrayReturned()
        {
            int N = 50000;
            Random rnd = new Random();
            int[] sourceArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                sourceArray[i] = rnd.Next(-100, 100);
            }

            MergeSort(sourceArray);

            Assert.IsTrue(CheckOrderArray(sourceArray));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void MergeSort_TrowNullReferenceException()
            => MergeSort(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_TrowArgumentException()
            => MergeSort(new int[0], -1, 0);
    }
}
