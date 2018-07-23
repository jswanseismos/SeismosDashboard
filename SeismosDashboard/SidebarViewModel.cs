using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeismosDashboard.Annotations;
using SeismosServices;

namespace SeismosDashboard
{

    public class SampleNodeRoot
    {
        public String Name { get; set; }

        public List<SampleNode1> Nodes { get; set; }
    }

    public class SampleNode1
    {
        public String Name { get; set; }

        public List<SampleNode2> Nodes { get; set; }
    }
    public class SampleNode2
    {
        public String Name { get; set; }

        public List<SampleNode3> Nodes { get; set; }
    }
    public class SampleNode3
    {
        public String Name { get; set; }

        
    }


    public class SidebarViewModel : INotifyPropertyChanged
    {
        private NavigationService navigationService;
        public SidebarViewModel()
        {
            navigationService = new NavigationService();
            NavClientNode clientNode = new NavClientNode() {Id = new Guid("1249c479-b6bd-4a23-9a17-10a87b09615e"), Name = "Client 2"};

            clientNode.Projects = navigationService.GetProjectNodes(clientNode.Id);

            clientTrees = new List<NavClientNode>(){clientNode};

            

            SampleNodeRoot sampleNodeRoot = new SampleNodeRoot();
            sampleNodeRoot.Name = "Root Node";
            sampleNodeRoot.Nodes = new List<SampleNode1>();

            SampleNode1 sampleNode1 = new SampleNode1
            {
                Name = "Node 1",
                Nodes = new List<SampleNode2>()
            };

            SampleNode1 sampleNode2 = new SampleNode1
            {
                Name = "Node 2",
                Nodes = new List<SampleNode2>()
            };

            SampleNode1 sampleNode3 = new SampleNode1
            {
                Name = "Node 3",
                Nodes = new List<SampleNode2>()
            };

            SampleNode2 sampleNode1a = new SampleNode2
            {
                Name = "Node 1a",
                Nodes = new List<SampleNode3>()
            };

            SampleNode2 sampleNode1b = new SampleNode2
            {
                Name = "Node 1b",
                Nodes = new List<SampleNode3>()
            };

            sampleNode1.Nodes.Add(sampleNode1a);
            sampleNode1.Nodes.Add(sampleNode1b);


            SampleNode2 sampleNode2a = new SampleNode2
            {
                Name = "Node 2a",
                Nodes = new List<SampleNode3>()
            };

            SampleNode2 sampleNode2b = new SampleNode2
            {
                Name = "Node 2b",
                Nodes = new List<SampleNode3>()
            };

            SampleNode2 sampleNode2c = new SampleNode2
            {
                Name = "Node 2c",
                Nodes = new List<SampleNode3>()
            };

            SampleNode3 sampleNode2ba = new SampleNode3
            {
                Name = "Node 2ba",
            };

            SampleNode3 sampleNode2bb = new SampleNode3
            {
                Name = "Node 2bb",
            };

            sampleNode2b.Nodes.Add(sampleNode2ba);
            sampleNode2b.Nodes.Add(sampleNode2bb);

            sampleNode2.Nodes.Add(sampleNode2a);
            sampleNode2.Nodes.Add(sampleNode2b);
            sampleNode2.Nodes.Add(sampleNode2c);




            SampleNode2 sampleNode3a = new SampleNode2
            {
                Name = "Node 3a",
                Nodes = new List<SampleNode3>()
            };

            SampleNode2 sampleNode3b = new SampleNode2
            {
                Name = "Node 3b",
                Nodes = new List<SampleNode3>()
            };

            SampleNode2 sampleNode3c = new SampleNode2
            {
                Name = "Node 3c",
                Nodes = new List<SampleNode3>()
            };

            SampleNode2 sampleNode3d = new SampleNode2
            {
                Name = "Node 3d",
                Nodes = new List<SampleNode3>()
            };

            SampleNode2 sampleNode3e = new SampleNode2
            {
                Name = "Node 3e",
                Nodes = new List<SampleNode3>()
            };

            sampleNode3.Nodes.Add(sampleNode3a);
            sampleNode3.Nodes.Add(sampleNode3b);
            sampleNode3.Nodes.Add(sampleNode3c);
            sampleNode3.Nodes.Add(sampleNode3d);
            sampleNode3.Nodes.Add(sampleNode3e);


            SampleNode1 sampleNode4 = new SampleNode1
            {
                Name = "Node 4",
                Nodes = new List<SampleNode2>()
            };

            sampleNodeRoot.Nodes.Add(sampleNode1);
            sampleNodeRoot.Nodes.Add(sampleNode2);
            sampleNodeRoot.Nodes.Add(sampleNode3);
            sampleNodeRoot.Nodes.Add(sampleNode4);


            sampleTrees = new List<SampleNodeRoot>(){sampleNodeRoot}; 

        }


        private List<NavClientNode> clientTrees;
        public List<NavClientNode> ClientTrees
        {
            get { return clientTrees; }
            set { clientTrees = value; }
        }

        private List<SampleNodeRoot> sampleTrees;
        public List<SampleNodeRoot> SampleTrees
        {
            get { return sampleTrees; }
            set
            {
                sampleTrees = value; 
                OnPropertyChanged(nameof(SampleTrees));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
