using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosServices
{
    public class KeyValueEntity
    {
        public KeyValueEntity()
        {
            keyValuePairs = new List<KeyValueMutable<string, object>>();
        }

        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<KeyValueMutable<string, object>> keyValuePairs;
        public List<KeyValueMutable<string, object>> KeyValuePairs
        {
            get { return keyValuePairs; }
            set { keyValuePairs = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
