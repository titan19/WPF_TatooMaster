using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TatooMaster
{
    public class Register
    {
        public static Register Instance { get; } = new Register();

        private Dictionary<Type, object> _collections = new Dictionary<Type, object>();
        private JsonSerializerSettings _settings;

        private Register()
        {
            _settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }

        public void Set<T>(ObservableCollection<T> collection)
        {
            _collections[typeof(T)] = collection;
        }

        public ObservableCollection<T> Get<T>(bool orCreate = true)
        {
            if (!_collections.ContainsKey(typeof(T)))
                return New<T>();
            return _collections[typeof(T)] as ObservableCollection<T>;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_collections, _settings);
        }

        public void Deserialize(string serialized)
        {
            _collections = JsonConvert.DeserializeObject<Dictionary<Type, object>>(serialized, _settings);
        }

        private ObservableCollection<T> New<T>()
        {
            var instance = new ObservableCollection<T>();
            _collections[typeof(T)] = instance;
            return instance;
        }
    }
}