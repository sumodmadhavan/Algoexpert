using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class Node
    {
        public Node next;
        public Node prev;
        public int value;
        public string name;
        public List<Node> childrens = new List<Node>();
        public Node(int value)
        {
            this.value = value;
        }
        //for graph properties
        public Node(string name)
        {
            this.name = name;
        }
        public Node AddChild(string name)
        {
            Node pointer = new Node(name);
            childrens.Add(pointer);
            return this;
        }
       

        
    }
}
