using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static ArraySortInt.Sort;

namespace ArraySortInt.NUnitTest
{
    [TestFixture]
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

        [TestCase(50)]
        [TestCase(50000)]
        public void QuickSort_MixedRandomArray_SortedArrayReturned(int numberOfElements)
        {
            Random rnd = new Random();
            int[] sourceArray = new int[numberOfElements];
            for (int i = 0; i < numberOfElements; i++)
            {
                sourceArray[i] = rnd.Next(-100, 100);
            }

            QuickSort(sourceArray);

            Assert.IsTrue(CheckOrderArray(sourceArray));
        }

        [Test]
        public void QuickSort_ThrowNullArgumentException()
            => Assert.Throws<NullReferenceException>(() => QuickSort(null));

        [Test]
        public void QuickSort_ThrowIndexOutOfRangeException()
            => Assert.Throws<IndexOutOfRangeException>(() => QuickSort(new int[0], 0, 10));

        [TestCase(50)]
        [TestCase(50000)]
        public void MergeSort_MixedRandomArray_SortedArrayReturned(int numberOfElements)
        {
            Random rnd = new Random();
            int[] sourceArray = new int[numberOfElements];
            for (int i = 0; i < numberOfElements; i++)
            {
                sourceArray[i] = rnd.Next(-100, 100);
            }

            MergeSort(sourceArray);

            Assert.IsTrue(CheckOrderArray(sourceArray));
        }

        [Test]
        public void MergeSort_ThrowNullArgumentException()
            => Assert.Throws<NullReferenceException>(() => MergeSort(null));

        [Test]
        public void MergeSort_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => MergeSort(new int[0], -1, 0));
    }
}
