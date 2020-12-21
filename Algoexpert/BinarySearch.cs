using System;
namespace Algoexpert
{
    public class BinarySearch
    {
        //main nodes
        int[] searchArray = { 1, 4, 6, 7, 8, 9, 12, 45, 25, 33, 44, 54, 56, 67, 78 };
        int target = 33;
        public int BinRes { get; set; }
        public BinarySearch()
        {
            Array.Sort(searchArray);
            BinRes = BinarySearchHelper(searchArray, target, 0, searchArray.Length - 1);
            //BinRes = searchArray[BinRes];
        }
        public int BinarySearchHelper(int[] array,int target,int left,int right)
        {
            while (left <=right)
            {
                int midPoint = Math.Abs((left + right) / 2);
                int potentialMatch = array[midPoint];
                if (target == potentialMatch)
                {
                    return midPoint;
                }
                //1 2 3 4 5 6 7 8 //7
                else if (target < potentialMatch) right = midPoint - 1;
                else if (target > potentialMatch) left = midPoint + 1;
            }
            return -1;
        }
       
        //O(log(n) |O(1) //for search range
        public void BinarySearchHelper(int[] array, int target, int left, int right,int[] range,bool goLeft)
        {
            while (left <= right)
            {
                int midPoint = Math.Abs((left + right) / 2);
                int potentialMatch = array[midPoint];
                if (target == potentialMatch)
                {
                    if (goLeft)
                    {
                        if (midPoint == 0 || array[midPoint - 1] != target)
                        {
                            range[0] = midPoint;
                            return;
                        }
                        else
                        {
                            right = midPoint - 1;
                        }

                    }
                    else
                    {
                        if (midPoint == array.Length-1 || array[midPoint+1]!=target)
                        {
                            range[1] = midPoint;
                            return;
                        }
                        else
                        {
                            left = midPoint + 1;
                        }
                    }
                }
                //1 2 3 4 5 6 7 8 //7
                else if (target < potentialMatch)
                {
                    right = midPoint - 1;
                }
                else if (target > potentialMatch)
                {
                    left = midPoint + 1;
                }
            }
        }
        //O(log(n) | O(1)
        public int[] SearchForRange(int[] array,int target)
        {
            int[] finalTarget = { -1, -1 };
            BinarySearchHelper(array, target, 0, array.Length - 1, finalTarget, true);
            BinarySearchHelper(array, target, 0, array.Length - 1, finalTarget, false);
            return finalTarget;

        }
        public int findClosestValueBST(BST tree,int target,double closest)
        {
            BST currentNode = tree;
            while (currentNode!=null)
            {
                if (Math.Abs(target-closest) > Math.Abs(target-currentNode.value))
                {
                    closest = currentNode.value;
                }
                else if (target < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if (target> currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    break;
                }
            }
            return (int)closest;
        }
    }
}
