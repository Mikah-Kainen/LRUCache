using System;
using System.Collections.Generic;
using System.Text;

namespace LRUCache
{
    class Cache<TKey, TValue> : ICache<TKey, TValue>
    {
        public Dictionary<TKey, LinkedListNode<(TValue Value, TKey Key)>> dictionary;
        public LinkedList<(TValue Value, TKey Key)> list;
        public int maxCount {get; set;}
        public Cache()
        {
            dictionary = new Dictionary<TKey, LinkedListNode<(TValue Value, TKey Key)>>();
            list = new LinkedList<(TValue Value, TKey Key)>();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if(dictionary.ContainsKey(key))
            {
                value = dictionary[key].Value;
                list.Remove((value, key));
                list.AddFirst((value, key));
                return true;
            }
            value = default;
            return false;
        }

        public void Put(TKey key, TValue value)
        {
            if(dictionary.ContainsKey(key))
            {
                dictionary[key].Value = value;
            }
            list.AddFirst((value, key));
            dictionary.Add(key, list.First);
            
            if(list.Count > maxCount)
            {
                dictionary.Remove();
                list.RemoveLast();
            }
        }

    }
}
