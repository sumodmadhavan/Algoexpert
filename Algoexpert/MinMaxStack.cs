using System;
using System.Collections;
namespace Algoexpert
{
    public class StackNode
    {
        public int value;
        public StackNode next;
        public StackNode oldMax;
        internal StackNode oldMin;
    }
    public class MinMaxStack
    {
        StackNode Stack;
        private StackNode maxNode;
        private StackNode minNode;
        public MinMaxStack()
        {
            
        }
        public void Push(int number)
        {
            StackNode newNode = new StackNode();
            newNode.value = number;
            if (Stack == null)
            {
                
                Stack = newNode;
            }
            else
            {
                newNode.next = Stack;
                Stack = newNode;
            }
            if (maxNode == null || newNode.value > maxNode.value)
            {
                newNode.oldMax = maxNode;
                maxNode = newNode;
            }
            if (minNode == null || newNode.value < minNode.value)
            {
                newNode.oldMin = minNode;
                minNode = newNode;
            }
            
        }
        public int Pop()
        {
            if (Stack == null)
            {
                throw new NullReferenceException();
            }
            if (Stack!=null)
            {
                StackNode n = Stack;
                Stack = n.next;
                if (n.oldMax !=null )
                {
                    maxNode = n.oldMax;
                }
                if (n.oldMin != null)
                {
                    minNode = n.oldMin;
                }
                return n.value;
            }
            return 0;
        }
        public int peek()
        {
            return Stack.value;
        }
        public int getMin()
        {
            return minNode.value;
        }
        public int getMax()
        {
            return maxNode.value;
        }
    }
}
