using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;

namespace SeismosServices
{
    public class SavedStateService
    {

        public void AddState(string key, string value)
        {
            using (var seismosContext = new seismosEntities())
            {
                var state = seismosContext.SavedStates.FirstOrDefault(ss => ss.SavedKey == key);
                if (state == null)
                {
                    SavedState savedState = new SavedState() {Id = Guid.NewGuid(), SavedKey = key, SavedValue = value};
                    seismosContext.SavedStates.Add(savedState);
                }
                else
                {
                    state.SavedValue = value;
                }

                seismosContext.SaveChanges();
            }

        }

        public string GetStateValue(string key)
        {
            string result;
            using (var seismosContext = new seismosEntities())
            {
                var state = seismosContext.SavedStates.FirstOrDefault(ss => ss.SavedKey == key);
                result = state?.SavedValue;
            }
            return result;
        }

    }
}
