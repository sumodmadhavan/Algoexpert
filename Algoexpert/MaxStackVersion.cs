using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class MaxStackVersion : Stack<int>
    {
        private readonly Stack<int> maxStack;
        public int MaxVersion
        {get {return Max();} }

        public MaxStackVersion()
        {
            maxStack = new Stack<int>();
        }

        public new void Push(int integer)
        {
            if (integer >= Max())
            {
                maxStack.Push(integer);
            }
            base.Push(integer);
        }
        public int Pop(int integer)
        {
            int value = base.Pop();
            if (value == Max())
            {
                maxStack.Pop();
            }
            return value;
        }
        private int Max()
        {
            if (maxStack.Count==0)
            {
                return int.MinValue;
            }
            else
            {
                return maxStack.Peek();
            }
        }
        public int baseCount() => base.Count;
    }
}
