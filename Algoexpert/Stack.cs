using System;
using System.Collections;
using System.Collections.Generic;

namespace Algoexpert
{
    public class MinMaxDTO
    {
        public int min;
        public int max;
    }
    public class Stack
    {
        //Min Max Construction
        private  ArrayList stack = new ArrayList();
        private List<Dictionary<string, int>> minmaxStack = new List<Dictionary<string, int>>();
        private List<MinMaxDTO> minmaxStackClass = new List<MinMaxDTO>();
        public Stack()
        {
           
        }
        public object peek()
        {
            int length = stack.Count - 1;
            return stack[length];
        }
        public void pop()
        {
            int length = stack.Count - 1;
            int minMaxLength = minmaxStack.Count - 1;
            minmaxStack.RemoveAt(minMaxLength);
            stack.RemoveAt(length);
        }
        public void popDTO()
        {
            int length = stack.Count - 1;
            int minMaxLength = minmaxStackClass.Count - 1;
            minmaxStackClass.RemoveAt(minMaxLength);
            stack.RemoveAt(length);
        }
        public void push(int number)
        {
            Dictionary<string, int> newValue = new Dictionary<string, int>();
            newValue.Add("min", number);
            newValue.Add("max", number);
            if (minmaxStack.Count>0)
            {

                Dictionary<string, int> lastValue = new Dictionary<string, int>(minmaxStack[minmaxStack.Count - 1]);
                newValue["min"] = Math.Min(lastValue["min"], number);
                newValue["max"] = Math.Max(lastValue["max"], number);
            }
            stack.Add(number);
            minmaxStack.Add(newValue);
        }
        public void pushDTO(int number)
        {
            MinMaxDTO newValue = new MinMaxDTO();
            newValue.min = number;
            newValue.max = number;
            if (minmaxStackClass.Count > 0)
            {

                MinMaxDTO lastValue = minmaxStackClass[minmaxStackClass.Count - 1];
                lastValue.min = Math.Min(lastValue.min, number);
                lastValue.max = Math.Max(lastValue.max, number);
            }
            stack.Add(number);
            minmaxStackClass.Add(newValue);
        }
        public int getMin()
        {
            return minmaxStack[minmaxStack.Count - 1]["min"];
        }
        public int getMax()
        {
            return minmaxStack[minmaxStack.Count - 1]["max"];
        }
        public int getMinDTO()
        {
            return minmaxStackClass[minmaxStackClass.Count - 1].min;
        }
        public int getMaxDTO()
        {
            return minmaxStackClass[minmaxStackClass.Count - 1].max;
        }
        public bool BalanceBrackets(string expressions)
        {
            string openParanthesis = "{([";
            string closeParanthesis = "})]";
            Dictionary<char, char> matchBrackets = new Dictionary<char, char>();
            matchBrackets.Add(')', '(');
            matchBrackets.Add(']', '[');
            matchBrackets.Add('}', '{');
            foreach (char character in expressions)
            {
                if (openParanthesis.IndexOf(character)!=-1)
                {
                    stack.Add(character);
                }
                if (closeParanthesis.IndexOf(character)!=-1)
                {
                    if (stack.Count>0)
                    {
                        char result = (char)stack[stack.Count - 1];
                        if (result == matchBrackets[character])
                        {
                            stack.RemoveAt(stack.Count - 1);
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
        public bool BalanceBracketsClean(string expressions)
        {
            System.Collections.Generic.Stack<char> stackGeneric = new Stack<char>();
            string openParanthesis = "{([";
            string closeParanthesis = "})]";
            Dictionary<char, char> matchBrackets = new Dictionary<char, char>();
            matchBrackets.Add(')', '(');
            matchBrackets.Add(']', '[');
            matchBrackets.Add('}', '{');
            foreach (char character in expressions)
            {
                if (openParanthesis.IndexOf(character) != -1)
                {
                    stackGeneric.Push(character);
                }
                if (closeParanthesis.IndexOf(character) != -1)
                {
                    if (stackGeneric.Count > 0)
                    {
                        
                        if (stackGeneric.Pop() == matchBrackets[character])
                        {
                            continue;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
        //https://github.com/rachitiitr/DataStructures-Algorithms/blob/master/Famous-Coding-Interview-Problems/TheRecusriveStackProblem.cpp
        
        public int CountBalancedBracket(string stringExp)
        {
            Stack<int> indexStack = new Stack<int>();
            List<int> et = new List<int>();
            int n = stringExp.Length;
            for (int i = 0; i < n; i++)
            {
                et.Add(0);
                if (stringExp[i] == ')')
                {
                    int t = indexStack.Peek();
                    et[t] = i;
                    indexStack.Pop();
                }
                else
                {
                    indexStack.Push(i);
                }
            }
            return alternateIteration(et,stringExp);
            //return go(0, stringExp.Length - 1,et);
        }

        private int alternateIteration(List<int> et,string str)
        {
            bool isHigh = false;
            int counter = 0;
            for (int i = 0; i < et.Count; i++)
            {  
                if (et[i]>0)
                {
                    isHigh |= et[0] == str.Length - 1;
                    counter++;
                }
            }
            return isHigh == true ? 2 * (counter - 1) : counter;
        }

        public int go(int lo,int hi, List<int> et)
        {
            if (lo+1==hi)
            {
                return 1;
            }
            int mid = et[lo];
            if (mid == hi)
            {
                return 2 * go(lo + 1, hi - 1,et);
            }
            return go(lo, mid,et) + go(mid + 1, hi,et);
        }
    }
}
