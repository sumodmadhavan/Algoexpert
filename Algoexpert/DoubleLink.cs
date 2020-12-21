using System;
namespace Algoexpert
{
    public class DoubleLink
    {
        public Node head;
        public Node tail;
        public DoubleLink()
        {
        }
        public bool ContainsNodeWithValue(int value)
        {
            Node node = head;
            while (node!=null && node.value != value)
            {
                node = node.next;
            }
            return node != null;
        }
        public void remove(Node node)
        {
            if (node == head) head = head.next;
            if (node == tail) tail = tail.prev;
            removeNodeBinding(node);
        }

        public void removeNodeBinding(Node node)
        {
            if (node.prev != null) node.prev.next = node.next;
            if (node.next != null) node.next.prev = node.prev;
            node.prev = null;
            node.next = null;
        }
        public void removeNodeWithValue(int value)
        {
            Node node = head;
            while (node!=null)
            {
                Node nodetoRemove = node;
                node = node.next;
                if (nodetoRemove.value == value)
                {
                    remove(nodetoRemove);
                }
            }
        }
        //7
        //4->5->6
        //nI.prev = node.prev and nI.next = node
        //node.next = nI
        //4->7->5->6
        public void insertBefore(Node node,Node nodetoInsert)
        {
            if (nodetoInsert == head && nodetoInsert == tail) return;
            remove(nodetoInsert);
            nodetoInsert.prev = node.prev;
            nodetoInsert.next = node;
            if (node.prev == null)
            {
                head = nodetoInsert;
            }
            else
            {
                node.prev.next = nodetoInsert;
            }
            node.prev = nodetoInsert;
        }
        //7
        //4->5->6
        //nI.prev = node and node.next = node.next
        //node.next = nI
        //4->5->7->6
        public void insertAfter(Node node, Node nodetoInsert)
        {
            if (nodetoInsert == head && nodetoInsert == tail) return;
            remove(nodetoInsert);
            nodetoInsert.prev = node;
            nodetoInsert.next = node.next;
            if (node.next == null)
            {
                tail = nodetoInsert;
            }
            else
            {
                node.next.prev = nodetoInsert;
            }
            node.next = nodetoInsert;
        }
        public void insertatPosition(int pos, Node nodeToInsert)
        {
            if (pos == 1)
            {
                setHead(nodeToInsert);
                return;
            }
            Node node = head;
            int curPos = 1;
            while (node!=null && curPos++ != pos)
            {
                node = node.next;
            }
            if (node!=null)
            {
                insertBefore(node, nodeToInsert);
            }
            else
            {
                setTail(nodeToInsert);
            }
        }

        public void setHead(Node node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }
            insertBefore(head, node);
        }
        public void setTail(Node node)
        {
            if (tail == null)
            {
                setHead(node);
                return;
            }
            insertAfter(tail, node);
        }
    }
}
