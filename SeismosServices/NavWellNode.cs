using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosServices
{
    public class NavWellNode
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

        private List<NavStageNode> stages;
        public List<NavStageNode> Stages
        {
            get { return stages; }
            set { stages = value; }
        }


    }
}
