using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Collections
{
    class MyDictionary<MyKey, TValue>
    {
        private Dictionary<MyKey, TValue> dict;
        public Func<MyKey> Keygen { get; set; }

        public MyDictionary() => dict = new Dictionary<MyKey, TValue>();

        public MyDictionary(Items<MyKey, TValue>[] items)
        {
            dict = new Dictionary<MyKey, TValue>();

            foreach(Items<MyKey, TValue> item in items)
            {
                dict.Add(item.Key, item.Value);
            }
        }

        public void Add(TValue value) => dict.Add(Keygen(), value);

        //public async void Add


        public void Edit(MyKey key, TValue value)
        {
            //if (dict.ContainsKey(key))
            //    dict[key] = value;
            //else
            //    dict.Add(key, value);
            foreach(var item in dict.Keys)
            {
                if(item == key)
                {
                    dict[key] = value;
                    return
                }
            }
        }

        public bool Remove(MyKey key)=> dict.Remove(key);

        //public void Update(MyKey key, TValue value)
        //{
        //    dict[key] = value;
        //}

        public TValue GetValue(MyKey key) => dict[key];

        public async Task<TValue> GetValueAsync(MyKey key)=> await Task.Run(() => GetValue(key));
        public IEnumerator GetEnumerator() => dict.GetEnumerator();
    }
}
