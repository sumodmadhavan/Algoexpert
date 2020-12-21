using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class StringOperations
    {
        public StringOperations()
        {
            
        }
        public string ceaserEncryptor(string s,int key)
        {
            char[] newLetters = new char[s.Length];
            int newKey = key % 26;
            for (int i = 0; i < s.Length; i++)
            {
                newLetters[i] = getNewLetter(s[i], newKey);
            }
            return new string(newLetters);

        }
        public char getNewLetter(char letter,int key)
        {
            int newLetter = letter + key;
            if (newLetter <=122)
            {
                return (char)newLetter;
            }
            else
            {
                return (char)(96+newLetter%122);
            }
        }
        public bool
            IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left<right)
            {
                if (s[left] !=s[right])
                {
                    return false;
                }
                else
                {
                    left++;
                    right--;
                }
            }
            return true;
        }
        /*O(nm)+O(nm)
         * initialize with 2D array
         *       "" y a b d
         *   ""  0  1 2 3 4 
         *   a   1
         *   b   2
         *   c   3
         *   If s1[row-1] == s2[col-1] pick diagonal
         *   else
         *   pick 1+ min(3 neighbors)
         *   Fill the edit array initially for empty+ string
         */
        public void LevenshteinDistance(string s1,string s2)
        {
            int[,] edits = new int[s1.Length+1,s2.Length+1];
            for (int i = 0; i < s1.Length+1; i++)
            {
                for (int j = 0; j < s2.Length+1; j++)
                {
                    edits[i, j] = j;
                }
                edits[i,0] = i;
            }
            for (int i = 1; i < s1.Length+1; i++)
            {
                for (int j = 1; j < s2.Length+1; j++)
                {
                    if (s1[i-1] == s2[j-1])
                    {
                        edits[i, j] = edits[i - 1, j - 1]; 
                    }
                    else
                    {
                        edits[i, j] = 1 + Math.Min(edits[i - 1, j - 1], Math.Min(edits[i - 1, j], edits[i, j - 1]));
                    }
                }
            }
            Console.WriteLine(edits[s1.Length, s2.Length]);
        }
       public string longestPalindromeString(string str)
        {
            int[] currentLongest = { 0, 1 };
            for (int i = 1; i < str.Length; i++)
            {
                int[] odd = getlongestPalindrome(str, i - 1, i + 1);
                int[] even = getlongestPalindrome(str, i - 1, i);
                int[] longest = odd[1] - odd[0] > even[1] - even[0] ? odd : even;
                currentLongest = longest[1] - longest[0] > currentLongest[1] - currentLongest[0] ? longest : currentLongest;
            }
            return str.Substring(currentLongest[0], currentLongest[1]-currentLongest[0]);
        }

        private int[] getlongestPalindrome(string str, int left, int right)
        {
            while (left>=0 && right < str.Length)
            {
                if (str[left]!=str[right])
                {
                    break;
                }
                else
                {
                    left--;
                    right++;
                }
            }
            return new int[] { left + 1, right };
        }
        public string LongestSubstringwithoutDuplicates(string s)
        {
            int startIndex = 0;
            string longestString = "";
            string maxSofar = "";
            Dictionary<char, int> dupsLookup = new Dictionary<char, int>();
            for (int i = 0; i < s.Length-1; i++)
            {
                if (!dupsLookup.ContainsKey(s[i]))
                {
                    dupsLookup.Add(s[i], i);
                }
                else
                {
                    char c = s[i];
                    startIndex = Math.Max(startIndex, dupsLookup[c] + 1);
                    dupsLookup[c] = i;
                }
                maxSofar = s.Substring(startIndex, i+1-startIndex);
                if (maxSofar.Length>longestString.Length)
                {
                    longestString = maxSofar;
                }
            }
            return longestString;
        }

        public string LongestSubstringwithoutDuplicatesOptim(string s)
        {
            int startIndex = 0;
            int[] longest = { 0, 1 };
            Dictionary<char, int> lastseen = new Dictionary<char, int>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                char c = s[i];
                if (lastseen.ContainsKey(c))
                {
                    startIndex = Math.Max(startIndex, lastseen[c] + 1);
                }
                if (longest[1]-longest[0] < i+1 - startIndex)
                {
                    longest = new int[] { startIndex, i + 1 };
                }
                lastseen.Add(c, i);
            }
            return s.Substring(longest[0],longest[1]);
        }
    }
}
