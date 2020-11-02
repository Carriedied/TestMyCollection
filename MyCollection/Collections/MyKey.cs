using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Collections
{
    class MyKey<TId, TName> where TId : IComparable<TId> where TName : class
    {
        public TId Id { get; set; }
        public TName Name { get; set; }

        public MyKey() { }
        public MyKey(TId id)=> this.Id = id;

        public MyKey(TId id, TName name)
        {
            Id = id;
            Name = name;
        }

        public static bool operator ==(MyKey<TId, TName> key1, MyKey<TId, TName> key2) => key1.Id.CompareTo(key2.Id) == 0 && key2?.Name == key1?.Name;
        public static bool operator !=(MyKey<TId, TName> key1, MyKey<TId, TName> key2) => key1.Id.CompareTo(key2.Id) != 0 || key2?.Name != key1?.Name;

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is MyKey<TId, TName>)
                return this == (MyKey<TId, TName>)obj;
            return false;
        }
    } 


    class MyKey : MyKey<int, string> 
    {
        public MyKey(int id) : base(id) { }
        public MyKey(int id, string name) : base(id, name) { }
        public static bool operator ==(MyKey key1, MyKey key2) => key1.Id == key2.Id && key2?.Name == key1?.Name;
        public static bool operator !=(MyKey key1, MyKey key2) => key1.Id != key2.Id || key2?.Name != key1?.Name;

        public override bool Equals(object obj)
        {
            if (obj is MyKey)
                return this == (MyKey)obj;
            return false;
        }
        public static MyKey Set(int id, string name) => new MyKey(id, name);
        public static MyKey Set(int id) => new MyKey(id, String.Empty);

        public override int GetHashCode()
        {
            return Id ^ Name.GetHashCode();
        }
    }
}
