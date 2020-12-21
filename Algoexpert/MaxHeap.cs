using System;
using System.Collections.Generic;
namespace Algoexpert
{
    public class MaxHeap
    {
        private List<int> maxHeap;
        public MaxHeap(int size)
        {
            maxHeap = new List<int>(size);
        }
        public MaxHeap()
        {
            maxHeap = new List<int>();
        }
        #region <<Helper Functions>>
        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < maxHeap.Count;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < maxHeap.Count;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private int GetLeftChild(int elementIndex) => maxHeap[GetLeftChildIndex(elementIndex)];
        private int GetRightChild(int elementIndex) => maxHeap[GetRightChildIndex(elementIndex)];
        private int GetParent(int elementIndex) => maxHeap[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = maxHeap[firstIndex];
            maxHeap[firstIndex] = maxHeap[secondIndex];
            maxHeap[secondIndex] = temp;
        }
        #endregion
        public void PrintHeap()
        {
            foreach (var item in maxHeap)
            {
                Console.WriteLine(item);
            }
        }
        public void Heapify(List<int> input)
        {
            if (maxHeap == null)
            {
                throw new IndexOutOfRangeException();
            }
            maxHeap = input;
            int firstParentIndex = GetParentIndex(maxHeap.Count - 1);
            for (int currentIndex = firstParentIndex; currentIndex >= 0; currentIndex--)
            {
                SiftDown(currentIndex);
            }
        }
        public List<int> HeapifyWithPush(List<int> input)
        {
            if (maxHeap == null)
            {
                throw new IndexOutOfRangeException();
            }
            foreach (var element in input)
            {
                Push(element);
            }
            return maxHeap;
            //SiftDown();
        }

        public int Pop()
        {
            if (maxHeap.Count == 0)
                throw new IndexOutOfRangeException();

            var result = maxHeap[0];
            maxHeap[0] = maxHeap[maxHeap.Count - 1];
            maxHeap.RemoveAt(maxHeap.Count - 1);
            SiftDown(0);
            return result;
        }

        public void Push(int number)
        {
            if (maxHeap!=null)
            {
                maxHeap.Add(number);
                SiftUp(maxHeap.Count-1);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }

        public int Peek()
        {
            if (maxHeap.Count == 0)
                throw new IndexOutOfRangeException();

            return maxHeap[0];
        }

        private void SiftUp(int index)
        {
            
            while (!IsRoot(index) && maxHeap[index] > GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        private void SiftDown(int index)
        {
            while (HasLeftChild(index))
            {
                var biggerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                {
                    biggerIndex = GetRightChildIndex(index);
                }

                if (maxHeap[biggerIndex] <= maxHeap[index])
                {
                    break;
                }

                Swap(biggerIndex, index);
                index = biggerIndex;
            }
        }
    }
}
