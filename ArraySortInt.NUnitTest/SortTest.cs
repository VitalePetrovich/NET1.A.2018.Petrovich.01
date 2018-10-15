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
        [TestCase(50)]
        [TestCase(500000)]
        public void QuickSort_MixedRandomArray_SortedArrayReturned(int numberOfElements)
        {
            int[] sourceArray = CreateRandomArray(numberOfElements);

            QuickSort(sourceArray);

            Assert.IsTrue(IsOrdered(sourceArray));
        }

        [Test]
        public void QuickSort_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => QuickSort(null));

        [Test]
        public void QuickSort_ThrowArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => QuickSort(new int[0], 0, 10));

        [TestCase(50)]
        [TestCase(500000)]
        public void MergeSort_MixedRandomArray_SortedArrayReturned(int numberOfElements)
        {
            int[] sourceArray = CreateRandomArray(numberOfElements);

            MergeSort(sourceArray);

            Assert.IsTrue(IsOrdered(sourceArray));
        }

        [Test]
        public void MergeSort_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => MergeSort(null));

        [Test]
        public void MergeSort_ThrowArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => MergeSort(new int[0], -1, 0));

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
