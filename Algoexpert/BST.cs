using System;
using System.Collections.Generic;

namespace Algoexpert
{
    //need revision.

    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
        }
        public BST InsertforBST(int value)
        {
            BST currentNode = this;
            while (true)
            {
                if (value < currentNode.value)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new BST(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = new BST(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.right;
                    }
                }
            }
            return this;
        }
        public BST InsertforBT(int value)
        {
            BST currentNode = this;
            while (true)
            {
                if (currentNode.left == null)
                {
                    currentNode.left = new BST(value);
                    break;
                }
                else
                {
                    currentNode = currentNode.left;
                }
                if (currentNode.right == null)
                {
                    currentNode.right = new BST(value);
                    break;
                }
                else
                {
                    currentNode = currentNode.right;
                }
            }
            return this;
        }
        public bool Contains(int value)
        {
            BST currentNode = this;
            while (currentNode!=null)
            {
                if (value < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if(value > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public BST remove(int value)
        {
            remove(value, null);
            return this;
        }

        private void remove(int value, BST parentNode)
        {

            BST currentNode = this;
            while (currentNode !=null)
            {
                if (value < currentNode.value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.left;
                }
                else if(value > currentNode.value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.right;
                }
                else
                {
                    //main removal method
                    //edge case 1 , we found the value, if it has left and right. 
                    if (currentNode.left!=null && currentNode.right!=null)
                    {
                        currentNode.value = currentNode.right.getMinValue();
                        currentNode.right.remove(currentNode.value, currentNode);
                    }
                    //edge case 2 if Parent is null
                    else if (parentNode == null)
                    {
                        if (currentNode.left != null)
                        {
                            currentNode.value = currentNode.left.value;
                            currentNode.right = currentNode.left.right;
                            currentNode.left = currentNode.left.left;
                        }
                        else if (currentNode.right != null)
                        {
                            currentNode.value = currentNode.right.value;
                            currentNode.left = currentNode.right.left;
                            currentNode.right = currentNode.right.right;

                        }
                        else
                        {
                            currentNode.value = 0;
                        }
                    }
                    //edge case 2. if parent.left = current and parent.right = current
                    //edge case 2
                    else if(parentNode.left == currentNode)
                    {
                        parentNode.left = currentNode.left != null ? currentNode.left : currentNode.right;
                    }
                    else if (parentNode.right == currentNode)
                    {
                        parentNode.right = currentNode.left != null ? currentNode.left : currentNode.right;
                    }
                   
                    break;
                }
            }
        }

        private int getMinValue()
        {
            if (left == null)
            {
                return this.value;
            }
            else
            {
                return left.getMinValue();
            }
        }
        public bool ValidBST(BST tree,int min,int max)
        {
            if (tree.value < min  || tree.value >= max)
            {
                return false;
            }
            if (tree.left!=null && !ValidBST(tree.left,min,tree.value))
            {
                return false;
            }
            if (tree.right != null && !ValidBST(tree.right, tree.value, max)) 
            {
                return false;
            }
            return true;
        }
        public void InOrder(BST tree)
        {
            if (tree.left!=null)
            {
                InOrder(tree.left);
            }
            Console.WriteLine(tree.value);
            if (tree.right != null)
            {
                InOrder(tree.right);
            }
        }
        public void PreOrder(BST tree)
        {
            Console.WriteLine(tree.value);
            if (tree.left != null)
            {
                PreOrder(tree.left);
            }
            if (tree.right != null)
            {
                PreOrder(tree.right);
            }
        }
        public void PostOrder(BST tree)
        {
            if (tree.left != null)
            {
                InOrder(tree.left);
            }
            if (tree.right != null)
            {
                InOrder(tree.right);
            }
            Console.WriteLine(tree.value);
        }
        public void InOrderIterative(BST tree)
        {
            Stack<BST> s = new Stack<BST>();
            BST curr = tree;

            // traverse the tree  
            while (curr != null || s.Count > 0)
            {

                /* Reach the left most Node of the  
                curr Node */
                while (curr != null)
                {
                    /* place pointer to a tree node on  
                       the stack before traversing  
                      the node's left subtree */
                    s.Push(curr);
                    curr = curr.left;
                }

                /* Current must be NULL at this point */
                curr = s.Pop();

                Console.WriteLine(curr.value + " ");

                /* we have visited the node and its  
                   left subtree.  Now, it's right  
                   subtree's turn */
                curr = curr.right;
            }
        }
        public void InvertBinaryTree(BST tree)
        {
            if (tree ==null)
            {
                return;
            }
            swapNodes(tree);
            InvertBinaryTree(tree.left);
            InvertBinaryTree(tree.right);
        }

        private void swapNodes(BST tree)
        {
            BST tempLeft = tree.left;
            tree.left = tree.right;
            tree.right = tempLeft;

        }
        public int MaxPathSum(BST tree)
        {
            List<int> maxSumArray = findMaxSum(tree);
            return maxSumArray[1];
        }

        private List<int> findMaxSum(BST tree)
        {
            if (tree == null)
            {
                return new List<int> { 0, 0 };

            }
            List<int> leftMaxSubArray = findMaxSum(tree.left);
            int lsb = leftMaxSubArray[0];
            int ls = leftMaxSubArray[1];

            List<int> rightMaxSubArray = findMaxSum(tree.right);
            int rsb = rightMaxSubArray[0];
            int rs = rightMaxSubArray[1];

            int mcbs = Math.Max(lsb, rsb);
            int msb = Math.Max(mcbs + tree.value, tree.value);
            int mst = Math.Max(msb, lsb + value + rsb);
            int rmps = Math.Max(ls, Math.Max(rs, mst));
            return new List<int> { msb, rmps };
        }
    }
}
