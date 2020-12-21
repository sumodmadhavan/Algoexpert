using System;
using System.Collections.Generic;
namespace Algoexpert
{
    public class MinHeapOptim
    {
        private List<int> minHeap;
        public MinHeapOptim(int size)
        {
            minHeap = new List<int>(size);
        }
        public MinHeapOptim()
        {
            minHeap = new List<int>();
        }
        #region <<Helper Functions>>
        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < minHeap.Count;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < minHeap.Count;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private int GetLeftChild(int elementIndex) => minHeap[GetLeftChildIndex(elementIndex)];
        private int GetRightChild(int elementIndex) => minHeap[GetRightChildIndex(elementIndex)];
        private int GetParent(int elementIndex) => minHeap[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = minHeap[firstIndex];
            minHeap[firstIndex] = minHeap[secondIndex];
            minHeap[secondIndex] = temp;
        }
        #endregion
        public void PrintHeap()
        {
            foreach (var item in minHeap)
            {
                Console.WriteLine(item);
            }
        }
        public List<int> Heapify(List<int> input)
        {
            if (minHeap == null)
            {
                throw new IndexOutOfRangeException();
            }
            minHeap = input;
            int firstParentIndex = GetParentIndex(minHeap.Count - 1);
            for (int currentIndex = firstParentIndex; currentIndex >= 0; currentIndex--)
            {
                SiftDown(currentIndex);
            }
            return minHeap;
            //SiftDown();
        }
        public List<int> HeapifyWithPush(List<int> input)
        {
            if (minHeap == null)
            {
                throw new IndexOutOfRangeException();
            }
            foreach (var element in input)
            {
                Push(element);
            }
            return minHeap;
            //SiftDown();
        }

        public int Pop()
        {
            if (minHeap.Count == 0)
                throw new IndexOutOfRangeException();

            var result = minHeap[0];
            minHeap[0] = minHeap[minHeap.Count - 1];
            minHeap.RemoveAt(minHeap.Count - 1);
            SiftDown(0);
            return result;
        }

        public void Push(int number)
        {
            if (minHeap!=null)
            {
                minHeap.Add(number);
                SiftUp(minHeap.Count-1);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }

        public int Peek()
        {
            if (minHeap.Count == 0)
                throw new IndexOutOfRangeException();

            return minHeap[0];
        }

        private void SiftUp(int index)
        {
            while (!IsRoot(index) && minHeap[index] < GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
        //O(log(n)|O(1)
        private void SiftDown(int index)
        {
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (minHeap[smallerIndex] >= minHeap[index])
                {
                    break;
                }
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
    }
}
