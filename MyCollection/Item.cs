using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Item<TId, TName, TValue>
    {
        public TId KeyId { get; set; }
        public TName KeyName { get; set; }
        public TValue Value { get; set; }

        public Item(TId keyId, TName keyName, TValue value)
        {
            if (keyId == null)
                throw new ArgumentNullException(nameof(keyId));

            if (keyName == null)
                throw new ArgumentNullException(nameof(keyName));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            KeyId = keyId;
            KeyName = keyName;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
