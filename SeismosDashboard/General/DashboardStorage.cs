using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    // TODO create enum for variable storage

    internal class DashboardStorage
    {
        private static DashboardStorage instance = new DashboardStorage();

        internal static DashboardStorage Instance
        {
            get => instance;
            set => instance = value;
        }

        private DashboardStorage()
        {
            storage = new Dictionary<string, object>();
            registry = new Dictionary<string, Action>();
        }

        private Dictionary<string, object> storage;
        private Dictionary<string, Action> registry;

        internal void RegisterAction(string key, Action action)
        {
            if (!registry.ContainsKey(key))
            {
                registry.Add(key, action);
                return;
            }

            registry[key] += action;
            registry.Remove(key);

        }

//        internal void UnregisterAction(string key, Action action)
//        {
//            if (!registry.ContainsKey(key))
//            {
//                return;
//            }
//
//            registry[key] -= action;
//            registry.Remove(key);
//
//        }
//
//


        internal bool Add<T>(string key, T value) where T : class
        {
            if (storage.ContainsKey(key)) return false;

            storage.Add(key, value);
            return true;
        }

        internal bool Update<T>(string key, T value) where T : class
        {
            if (!storage.ContainsKey(key)) return false;
            storage.Remove(key);
            storage.Add(key, value);
            return true;

        }

        internal bool AddOrUpdate<T>(string key, T value) where T : class
        {
            if (storage.ContainsKey(key))
            {
                storage.Remove(key);
            }

            storage.Add(key, value);
            RunActions(key);
            return true;
        }

        internal void RunActions(string key)
        {
            if (registry.ContainsKey(key))
            {
                registry[key]();
            }
        }

        internal T GetValue<T>(string key) where T : class
        {
            if (!storage.ContainsKey(key)) return null;

            return storage[key] as T;

        }

        internal bool Remove(string key)
        {
            return storage.ContainsKey(key) && storage.Remove(key);
        }

        internal void ClearStorage()
        {
            storage.Clear();
        }

        internal void DisposeStorage()
        {
            storage = null;
            Instance = null;
        }

    }
}
