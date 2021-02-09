using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AutocompleteSystem
{
    private class TrieNode
    {
        public int Times = 0;
        public readonly Dictionary<char, TrieNode> Next = new Dictionary<char, TrieNode>();
    }

    private void AddValue(TrieNode node, ref string val, int idx, int times)
    {
        if (idx == val.Length)
        {
            node.Times += times;
            return;
        }

        char c = val[idx];
        TrieNode nextNode = null;

        if (node.Next.ContainsKey(c))
        {
            nextNode = node.Next[c];
        }
        else
        {
            nextNode = new TrieNode();
            node.Next[c] = nextNode;
        }

        AddValue(nextNode, ref val, idx + 1, times);
    }

    private void AddValue(string val, int times)
    {
        AddValue(_root, ref val, 0, times);
    }

    private bool _idle;
    private readonly TrieNode _root;
    private TrieNode _node;
    private StringBuilder _prefix;
    private readonly SortedSet<(int times, string sentence)> _set;

    private class SentenceComparer : IComparer<(int times, string sentence)>
    {
        public int Compare((int times, string sentence) x, (int times, string sentence) y)
        {
            var timesCmp = y.times.CompareTo(x.times);
            if (timesCmp != 0)
            {
                return timesCmp;
            }

            return string.Compare(x.sentence, y.sentence, StringComparison.Ordinal);
        }
    }

    public AutocompleteSystem(string[] sentences, int[] times)
    {
        _prefix = new StringBuilder();
        _root = new TrieNode();
        _node = _root;
        _set = new SortedSet<(int times, string sentence)>(new SentenceComparer());

        for (int i = 0; i < sentences.Length; i++)
        {
            AddValue(sentences[i], times[i]);
        }
    }

    private void Search(TrieNode node, char c)
    {
        _prefix.Append(c);

        if (node.Times > 0)
        {
            (int times, string sentence) data = (node.Times, _prefix.ToString());
            _set.Add(data);

            if (_set.Count > 3)
            {
                _set.Remove(_set.Last());
            }
        }

        foreach (var next in node.Next)
        {
            Search(next.Value, next.Key);
        }

        _prefix.Remove(_prefix.Length - 1, 1);
    }

    public IList<string> Input(char c)
    {
        if (c == '#')
        {
            AddValue(_prefix.ToString(), 1);

            _idle = false;
            _node = _root;
            _prefix.Clear();
            return new List<string>();
        }

        if (_idle)
        {
            _prefix.Append(c);
            return new List<string>();
        }

        _set.Clear();

        if (!_node.Next.ContainsKey(c))
        {
            _idle = true;
            _prefix.Append(c);
            return new List<string>();
        }

        _node = _node.Next[c];
        Search(_node, c);

        IList<string> res = new List<string>();
        foreach (var data in _set)
        {
            res.Add(data.sentence);
        }

        _prefix.Append(c);
        return res;
    }
}