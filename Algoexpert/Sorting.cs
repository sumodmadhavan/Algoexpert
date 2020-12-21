using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class Sorting
    {
        public Sorting()
        {


        }
        public void BubbleSort(int[] uList)
        {
            bool isSorted = false;
            int counter = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < uList.Length - 1 - counter; i++)
                {
                    if (uList[i] > uList[i + 1])
                    {
                        swap(i, i + 1, uList);
                        isSorted = false;
                    }
                }
                counter++;
            }
            foreach (var item in uList)
            {
                Console.WriteLine(item);
            }
        }
        public void InsertionSort(int[] uList)
        {
            for (int i = 1; i < uList.Length; i++)
            {
                int j = i;
                while (j > 0 && uList[j] < uList[j - 1])
                {
                    swap(j, j - 1, uList);
                    j--;
                }
            }


            foreach (var item in uList)
            {
                Console.WriteLine(item);
            }
        }
        public void SelectionSort(int[] uList)
        {
            int startIndex = 0;
            while (startIndex < uList.Length - 1)
            {
                int smallIndex = startIndex;
                for (int i = startIndex; i < uList.Length; i++)
                {
                    if (uList[smallIndex] > uList[i])
                    {
                        smallIndex = i;
                    }
                }
                swap(startIndex, smallIndex, uList);
                startIndex++;
            }


            foreach (var item in uList)
            {
                Console.WriteLine(item);
            }
        }

        private int[] swap(int i, int j, int[] uList)
        {
            int temp = uList[j];
            uList[j] = uList[i];
            uList[i] = temp;

            return uList;
        }
        //O(n)|O(1)
        public int[] SubArraySort(int[] array)
        {

            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i];
                if (IsOutOfOrder(i, num, array))
                {
                    min = Math.Min(min, num);
                    max = Math.Max(max, num);
                }
            }
            if (min == int.MaxValue)
            {
                return new int[] { -1, -1 };
            }
            int subLeftIndex = 0;
            while (min >= array[subLeftIndex])
            {
                subLeftIndex++;
            }
            int subRightIndex = array.Length - 1;
            while (max <= array[subRightIndex])
            {
                subRightIndex--;
            }
            return new int[] { subLeftIndex, subRightIndex };
        }

        private bool IsOutOfOrder(int i, int num, int[] array)
        {
            if (i == 0)
            {
                return num > array[i + 1];
            }
            if (i == array.Length - 1)
            {
                return num < array.Length - 1;
            }
            return num > array[i + 1] || num < array[i - 1];

        }
        public int[] QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
            return array;
        }
        //O(n log(n)) | O(log(n))
        private void QuickSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            int pivotIndex = startIndex;
            int leftIndex = startIndex + 1;
            int rightIndex = endIndex;
            while (leftIndex <= rightIndex)
            {
                int left = array[leftIndex];
                int right = array[rightIndex];
                int pivot = array[pivotIndex];
                if (left > pivot && right < pivot)
                {
                    swap(leftIndex, rightIndex, array);
                }
                if (left < pivot)
                {
                    leftIndex++;
                }
                if (right > pivot)
                {
                    rightIndex--;
                }
            }
            swap(pivotIndex, rightIndex, array);
            //Note: These lines are not required but it still divide by left and right.
            //bool isLeftSubarraySmaller = (rightIndex - 1 - startIndex) < endIndex - (rightIndex + 1);
            //if (isLeftSubarraySmaller)
            //{
            //    QuickSort(array, startIndex, rightIndex - 1);
            //    QuickSort(array, rightIndex + 1, endIndex);
            //}
            //else
            //{
            //    QuickSort(array, rightIndex + 1, endIndex);
            //    QuickSort(array, startIndex, rightIndex - 1);
            //}
            QuickSort(array, startIndex, rightIndex - 1);
            QuickSort(array, rightIndex + 1, endIndex);
        }
        //private static void _QuickSort<T>(T[] array, int startIndex, int endIndex, IComparer<T> comparer)
        //{
        //    if (startIndex >= endIndex)
        //        return;

        //    int middleIndex = Partition(array, startIndex, endIndex, comparer);
        //    _QuickSort(array, startIndex, middleIndex - 1, comparer);
        //    _QuickSort(array, middleIndex + 1, endIndex, comparer);
        //}

        //private static int Partition<T>(T[] array, int startIndex, int endIndex, IComparer<T> comparer)
        //{
        //    int middle = startIndex;
        //    for (int u = startIndex; u <= endIndex - 1; u++)
        //    {
        //        if (comparer.Compare(array[u], array[endIndex]) <= 0)
        //        {

        //            array.Swap(u, middle);
        //            middle++;
        //        }
        //    }

        //    array.Swap(middle, endIndex);

        //    return middle;
        //}

        public int QuickSelect(int[] array, int K)
        {
            int position = K - 1;
            return QuickSelect(array, 0, array.Length - 1, position);

        }

        private int QuickSelect(int[] array, int startIndex, int endIndex, int position)
        {
            while (true)
            {
                if (startIndex > endIndex)
                {
                    throw new Exception("Out of Order");
                }
                int pivotIndex = startIndex;
                int leftIndex = startIndex + 1;
                int rightIndex = endIndex;
                while (leftIndex <= rightIndex)
                {
                    int left = array[leftIndex];
                    int right = array[rightIndex];
                    int pivot = array[pivotIndex];
                    if (left > pivot && right < pivot)
                    {
                        swap(leftIndex, rightIndex, array);
                    }
                    if (left < pivot)
                    {
                        leftIndex++;
                    }
                    if (right > pivot)
                    {
                        rightIndex--;
                    }
                }
                swap(pivotIndex, rightIndex, array);
                if (rightIndex == position)
                {
                    return array[rightIndex];
                }
                if (rightIndex < position)
                {
                    startIndex = rightIndex + 1;
                }
                else
                {
                    endIndex = rightIndex - 1;
                }
            }
        }
    }
}
