using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Item<TId, TName, TValue> : IEnumerable<TId, TName, TValue>
    {
        [Key]
        public TId Id { get; set; }
        [Key]
        public TName Name { get; set; }
        public TValue Value { get; set; }

        public Item(TId id, TName name, TValue value)
        {
            if (Id == null && Name == null)
                throw new ArgumentNullException(nameof(Id));

            this.Id = id;
            this.Name = name;
            this.Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
