using System;
//MAX STACK
namespace Algoexpert
{
    public class MangoNode
    {
        public int value;
        public MangoNode next;
        public MangoNode oldMax;
    }
    public class MagoStack
    {
        MangoNode mStack;
        MangoNode max;
        public MagoStack()
        {

        }
        public void Push(int n)
        {
            MangoNode newNode = new MangoNode();
            newNode.value = n;
            if (mStack == null)
            {
                mStack = newNode;
            }
            else
            {
                newNode.next = mStack;
                mStack = newNode;
            }
            if (max == null || newNode.value > max.value)
            {
                newNode.oldMax = max;
                max = newNode;
            }
        }
        public int pop()
        {
            if (mStack == null)
            {
                return 0;
            }
            MangoNode mangoNode = mStack;
            mStack = mangoNode.next;
            if (mangoNode.oldMax!=null)
            {
                max = mangoNode.oldMax;
            }
            return mangoNode.value;
        }
        public int getMax()
        {
            return max.value;
        }
    }
}
