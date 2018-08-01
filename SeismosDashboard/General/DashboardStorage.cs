using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    // add storage keys as needed
    internal enum DashboardEventsEnum
    {
        CurrentSeismosClientId,
        CurrentSeismosClientName,
        CurrentSeismosProjectId,
        CurrentSeismosProjectName,
        CurrentWellsChanged,
        NavProjectSelected,
        NavWellSelected,
        NavStageSelected

    }



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

        internal void RegisterAction(DashboardEventsEnum key, Action action)
        {
            RegisterAction(Enum.GetName(typeof(DashboardEventsEnum), key), action);
        }
        internal void RegisterAction(string key, Action action)
        {
            if (!registry.ContainsKey(key))
            {
                registry.Add(key, action);
                return;
            }

            registry[key] += action;

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

        internal bool AddOrUpdate<T>(DashboardEventsEnum key, T value) where T : class
        {
            return AddOrUpdate(Enum.GetName(typeof(DashboardEventsEnum), key), value);
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


        internal T GetValue<T>(DashboardEventsEnum key) where T : class
        {
            return GetValue<T>(Enum.GetName(typeof(DashboardEventsEnum), key));
        }

        internal Guid GetValueId(DashboardEventsEnum key)
        {
            string strId = GetValue<String>(Enum.GetName(typeof(DashboardEventsEnum), key));
            if (!Guid.TryParse(strId, out var tempId)) tempId = Guid.Empty;
            return tempId;
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
            registry.Clear();
        }

        internal void DisposeStorage()
        {
            registry = null;
            storage = null;
            Instance = null;

        }

    }
}
