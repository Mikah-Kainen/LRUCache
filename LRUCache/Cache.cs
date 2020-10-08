using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LRUCache
{
    class Cache<TKey, TValue> : ICache<TKey, TValue>
    {
        public Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> dictionary;
        public LinkedList<KeyValuePair<TKey, TValue>> list;
        public int maxCount {get; set;}
        public Cache(int count)
        {
            dictionary = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
            list = new LinkedList<KeyValuePair<TKey, TValue>>();
            maxCount = count;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if(dictionary.ContainsKey(key))
            {
                value = dictionary[key].Value.Value;
                list.Remove(new KeyValuePair<TKey, TValue>(key, value));
                list.AddFirst(new KeyValuePair<TKey, TValue>(key, value));
                return true;
            }
            value = default;
            return false;
        }

        public void Put(TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                list.Remove(list.Find(new KeyValuePair<TKey, TValue>(key, dictionary[key].Value.Value)));
                dictionary[key].Value = new KeyValuePair<TKey, TValue>(key, value);
                list.AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            {
                list.AddFirst(new KeyValuePair<TKey, TValue>(key, value));
                dictionary.Add(key, list.First);
            }

            if(list.Count > maxCount)
            {
                dictionary.Remove(list.Last.Value.Key);
                list.Remove(list.Last);
            }

        }

    }
}
