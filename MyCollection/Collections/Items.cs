using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Collections
{
    class Items<MyKey, TValue>
    {
        public MyKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
