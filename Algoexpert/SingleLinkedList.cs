using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class SingleLinkedList 
    {
        public LinkedList head = null;
        
        public SingleLinkedList()
        {
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var current = AddMany(values);
            List<int> final = new List<int>();
            while (current != null)
            {
                final.Add(current.value);
                current = current.next;
            }
        }
        public void removeKthNode(LinkedList head, int n)
        {
            int counter = 1;
            LinkedList first = head;
            LinkedList second = head;
            LinkedList current = head;
            while (counter<=n)
            {
                second = second.next;
                counter++; 
            }
            if (second == null)
            {
                head.value = head.next.value;
                head.next = head.next.next;
            }
            else
            {
                while (second.next!=null)
                {
                    second = second.next;
                    first = first.next;
                }
                first.next = first.next.next;
            }
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }
        //O(n)|O(1)
        public LinkedList FindLoop(LinkedList head)
        {
            LinkedList first = head.next;
            LinkedList second = head.next.next;
            while (first != second)
            {
                first = first.next;
                second = second.next.next;
            }
            first = head;
            while (first != second)
            {
                first = first.next;
                second = second.next;
            }
            return first;

        }
        public LinkedList ReverseLinkedList(LinkedList head)
        {
            LinkedList p1 = null;
            LinkedList p2 = head;
            while (p2!=null)
            {
                LinkedList p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }
            return p1;
        }
        public LinkedList getNNode(int n,LinkedList head)
        {
            int counter = 1;
            LinkedList current = head;
            while (counter<n)
            {
                current = current.next;
                counter++;
            }
            return current;
        }
        public LinkedList AddMany(int[] array)
        {
            LinkedList current = new LinkedList(0);
            
            while (current.next != null)
            {
                current = current.next;
            }
            head = current;
            foreach (var item in array)
            {

                current.next = new LinkedList(item);
                current = current.next;
            }
            current = head;
            return current;
        }
    }
    public class LinkedList
    {
        public int value;
        public LinkedList next = null;
        public LinkedList head;
        public LinkedList(int value)
        {
            this.value = value;
        }

    }
}
