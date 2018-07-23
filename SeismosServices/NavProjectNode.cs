using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosServices
{
    public class NavProjectNode
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

        private List<NavWellNode> wells;
        public List<NavWellNode> Wells
        {
            get { return wells; }
            set { wells = value; }
        }


    }
}
