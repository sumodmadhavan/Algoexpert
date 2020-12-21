using System;
namespace Algoexpert
{
    public class FindThreeLargeNum
    {
        public FindThreeLargeNum()
        {
            int[] array = { 434, 0, -1, -2, -4, 9, 8, 45, 99, 234 };
            var r = FindThreeLarge(array);
            Console.Write(r[2]+"-"+r[1]+"-"+r[0]);
        }
        private int[] FindThreeLarge(int[] array)
        {
            int[] maxThree = { int.MinValue, int.MinValue, int.MinValue };
            foreach (var num in array)
            {
                if (num > maxThree[2])
                {
                    ShiftUpdate(maxThree, num,2);
                    //maxThree[1] = maxThree[2];
                    //maxThree[2] = num;
                }
                else if(num > maxThree[1])
                {
                    ShiftUpdate(maxThree, num, 1);
                    /*
                    maxThree[0] = maxThree[1];
                    maxThree[1] = num;*/
                }
                else
                {
                    if (num > maxThree[0])
                    {
                        ShiftUpdate(maxThree, num, 0);
                        //maxThree[0] = num;
                    }
                    
                }
            }
            return maxThree;
        }

        private static void ShiftUpdate(int[] maxThree, int num,int idx)
        {
            for (int i = 0; i <= idx; i++)
            {
                if (i == idx)
                {
                    maxThree[i] = num;
                }
                else
                {
                    maxThree[i] = maxThree[i + 1];
                }
            }
        }
    }
}
