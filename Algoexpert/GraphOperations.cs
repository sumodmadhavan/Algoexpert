using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class GraphOperations
    {
        public GraphOperations()
        {

        }
        //Traverse O(V+E) | O(V)
        public List<string> BreadthFirstSearch(Node tree)
        {
            List<string> returnList = new List<string>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(tree);
            while (queue.Count>0)
            {
                Node current = queue.Dequeue();
                returnList.Add(current.name);
                foreach (Node node in current.childrens)
                {
                    queue.Enqueue(node);
                }
            }
            return returnList;
        }
        //Traverse O(V+E) | O(V)
        public List<string> DepthFirstSearch(Node root,List<string> array)
        {
            Console.Write(root.name);
            array.Add(root.name);
            for (int i = 0; i < root.childrens.Count; i++)
            {
                DepthFirstSearch(root.childrens[i],array);
            }
            return array;
        }
        public List<string> DepthFirstSearchIterative(Node root, List<string> array)
        {
            Stack<Node> s = new Stack<Node>();
            HashSet<string> visited = new HashSet<string>();
            visited.Add(root.name);
            s.Push(root);
            while (s.Count > 0)
            {
                Console.WriteLine(s.Peek().name);
                Node current = s.Pop();
                array.Add(current.name);
                foreach (Node item in current.childrens)
                {
                    if (!visited.Contains(item.name))
                    {
                        visited.Add(item.name);
                        s.Push(item);
                    }
                }
            }
            return array;

        }
        public List<string> FindGraphEqual(Node T1, List<string> array)
        {
            Queue<Node> pQueue = new Queue<Node>();
            pQueue.Enqueue(T1);
            while (pQueue.Count > 0)
            {
                T1 = pQueue.Dequeue();
                array.Add(T1.name);
                foreach (var item in T1.childrens)
                {
                    pQueue.Enqueue(item);
                }
               
            }
            return array;
        }

    }
}
