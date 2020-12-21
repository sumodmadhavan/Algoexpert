using System;
using System.Collections.Generic;
namespace Algoexpert
{
    public class TrieNode
    {
        public  Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    }
    public class SuffixTrie
    {
        TrieNode root = new TrieNode();
        char endSymbol = '*';
        public SuffixTrie(string str)
        {
            PopeulateSuffixTrie(str);
        }

        public void PopeulateSuffixTrie(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                InsertSubstring(i, str);
            }
        }

        private void InsertSubstring(int i, string str)
        {
            TrieNode node = root;
            for (int j = i; j < str.Length; j++)
            {
                char letter = str[j];
                if (!node.children.ContainsKey(letter))
                {
                    TrieNode newNode = new TrieNode();
                    node.children.Add(letter, newNode);
                }
                node = node.children[letter];
            }
            node.children.Add(endSymbol, null);
        }
        public bool searchTrie(string str)
        {
            TrieNode node = root;
            foreach (char letter in str)
            {
                if (!node.children.ContainsKey(letter))
                {
                    return false;
                }
                else
                {
                    node = node.children[letter];
                }
            }
            return node.children.ContainsKey(endSymbol) ? true : false;
        }

    }
}
