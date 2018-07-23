using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosServices
{
    public class NavClientNode
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<NavProjectNode> projects;
        public List<NavProjectNode> Projects
        {
            get { return projects; }
            set { projects = value; }
        }


    }
}
