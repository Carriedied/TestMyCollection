using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Collection<TId, TName, TValue>
    {
        //Dictionary<TId, Dictionary<TName, Item>> _Id = new Dictionary<TId, Dictionary<TName, Item>>();
        //Dictionary<TName, Dictionary<TId, Item>> _Name = new Dictionary<TName, Dictionary<TId, Item>>();

        private List<Item<TId, TName, TValue>> _items = new List<Item<TId, TName, TValue>>();

        public int Count => _items.Count;

        public IReadOnlyList<TId> KeysId => (IReadOnlyList<TId>)_items.Select(i => i.KeyId).ToList();
        public IReadOnlyList<TName> KeysName => (IReadOnlyList<TName>)_items.Select(i => i.KeyName).ToList();

        public void Add(Item<TId, TName, TValue> item)
        {
            // Проверяем входные данные на корректность.
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_items.Any(i => i.KeyId.Equals(item.KeyId)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {item.KeyId}.", nameof(item));
            }

            if (_items.Any(i => i.KeyName.Equals(item.KeyName)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {item.KeyName}.", nameof(item));
            }

            // Добавляем данные в коллекцию.
            _items.Add(item);
        }

        public void Add(TId keyId, TName keyName, TValue value)
        {
            // Проверяем входные данные на корректность.
            if (keyId == null)
            {
                throw new ArgumentNullException(nameof(keyId));
            }

            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_items.Any(i => i.KeyId.Equals(keyId)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {keyId}.", nameof(keyId));
            }

            if (_items.Any(i => i.KeyName.Equals(keyName)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {keyName}.", nameof(keyName));
            }

            // Создаем новый элемент хранимых данных.
            var item = new Item<TId, TName, TValue>(keyId, keyName, value)
            {
                KeyId = keyId,
                KeyName = keyName,
                Value = value
            };

            // Добавляем данные в коллекцию.
            _items.Add(item);
        }

        public void RemoveById(TId keyId)
        {
            // Проверяем входные данные на корректность.
            if (keyId == null)
            {
                throw new ArgumentNullException(nameof(keyId));
            }

            // Получаем элемент данных из коллекции по ключу.
            var item = _items.SingleOrDefault(i => i.KeyId.Equals(keyId));

            // Если данные найдены по ключу, 
            // то удаляем их из коллекции.
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void RemoveByName(TName keyName)
        {
            // Проверяем входные данные на корректность.
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            // Получаем элемент данных из коллекции по ключу.
            var item = _items.SingleOrDefault(i => i.KeyName.Equals(keyName));

            // Если данные найдены по ключу, 
            // то удаляем их из коллекции.
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void UpdateById(TId keyId, TValue newValue)
        {
            // Проверяем входные данные на корректность.
            if (keyId == null)
            {
                throw new ArgumentNullException(nameof(keyId));
            }

            if (newValue == null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            if (!_items.Any(i => i.KeyId.Equals(keyId)))
            {
                throw new ArgumentException($"Словарь не содержит значение с ключом {keyId}.", nameof(keyId));
            }

            // Получаем элемент данных по ключу.
            var item = _items.SingleOrDefault(i => i.KeyId.Equals(keyId));

            // Если данные найдены по ключу, 
            // то изменяем хранимое значение на новое.
            if (item != null)
            {
                item.Value = newValue;
            }
        }

        public void UpdateByName(TName keyName, TValue newValue)
        {
            // Проверяем входные данные на корректность.
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            if (newValue == null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            if (!_items.Any(i => i.KeyId.Equals(keyName)))
            {
                throw new ArgumentException($"Словарь не содержит значение с ключом {keyName}.", nameof(keyName));
            }

            // Получаем элемент данных по ключу.
            var item = _items.SingleOrDefault(i => i.KeyId.Equals(keyName));

            // Если данные найдены по ключу, 
            // то изменяем хранимое значение на новое.
            if (item != null)
            {
                item.Value = newValue;
            }
        }

        public TValue GetById(TId keyId)
        {
            // Проверяем входные данные на корректность.
            if (keyId == null)
            {
                throw new ArgumentNullException(nameof(keyId));
            }

            // Получаем значение по ключу.
            var item = _items.SingleOrDefault(i => i.KeyId.Equals(keyId)) ??
                throw new ArgumentException($"Словарь не содержит значение с ключом {keyId}.", nameof(keyId));

            // Возвращаем значение хранимых данных.
            return item.Value;
        }

        public TValue GetByName(TName keyName)
        {
            // Проверяем входные данные на корректность.
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            // Получаем значение по ключу.
            var item = _items.SingleOrDefault(i => i.KeyId.Equals(keyName)) ??
                throw new ArgumentException($"Словарь не содержит значение с ключом {keyName}.", nameof(keyName));

            // Возвращаем значение хранимых данных.
            return item.Value;
        }
    }

}
