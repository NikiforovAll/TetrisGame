using System;
using System.Collections.Generic;

namespace TetrisForm
{
    [Serializable]
    public class LadderBoard : List<KeyValuePair<string, int>>
    {
        private static int _playerCup = 3;
        private List<KeyValuePair<string, int>> _board = new List<KeyValuePair<string, int>>();

        private static int Compare(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return -a.Value.CompareTo(b.Value);
        }

        public void AddValid(KeyValuePair<string, int> pair)
        {
            if (Count < _playerCup)
            {
                this.Add(pair);

            }
            else if (this[Count - 1].Value < pair.Value)
            {
                this.RemoveAt(Count - 1);
                this.Add(pair);

            }
            this.Sort(Compare);
        }



    }
}
