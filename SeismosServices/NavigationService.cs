using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;

namespace SeismosServices
{
    public class NavigationService
    {

        public List<NavProjectNode> GetProjectNodes(Guid clientGuid)
        {

            List<NavProjectNode> projectNodes = new List<NavProjectNode>();

            using (var seismosContext = new seismosEntities())
            {
                var projects = seismosContext.SeismosProjects.Where(sp => sp.SeismosClientId == clientGuid).OrderBy(sp => sp.Name).ToList();
                foreach (var seismosProject in projects)
                {
                    projectNodes.Add(new NavProjectNode() {Id = seismosProject.Id, Name = seismosProject.Name});
                }
            }

            foreach (var projectNode in projectNodes)
            {
                projectNode.Wells = GetWellNodes(projectNode.Id);
            }

            return projectNodes;
        }

        public NavProjectNode GetProjectNode(Guid projectGuid)
        {
           
            NavProjectNode projectNode = null;

            using (var seismosContext = new seismosEntities())
            {
                var tempProject = seismosContext.SeismosProjects.FirstOrDefault(sp => sp.Id == projectGuid);
                if (tempProject == null) return null;
                    projectNode = new NavProjectNode() {Id = tempProject.Id, Name = tempProject.Name};
            }

            projectNode.Wells = GetWellNodes(projectNode.Id);

            return projectNode;
        }

        private List<NavWellNode> GetWellNodes(Guid projectGuid)
        {
            List<NavWellNode> wellNodes = new List<NavWellNode>();

            using (var seismosContext = new seismosEntities())
            {
                var tempWells = seismosContext.Wells.Where(w => w.SeismosProject.Id == projectGuid)
                    .OrderBy(w => w.WellName).ToList();

                foreach (var tempWell in tempWells)
                {
                    wellNodes.Add(new NavWellNode() { Id = tempWell.Id, Name = tempWell.WellName});
                }
                
            }

            foreach (var navWellNode in wellNodes)
            {
                navWellNode.Stages = GetStageNodes(navWellNode.Id, navWellNode.Name);
            }

            return wellNodes;

        }

        private List<NavStageNode> GetStageNodes(Guid wellGuid, string wellName)
        {
            List<NavStageNode> stageNodes = new List<NavStageNode>();

            using (var seismosContext = new seismosEntities())
            {
                var tempTreatments = seismosContext.Treatments.Where(tr => tr.WellId == wellGuid).ToList();
                foreach (var tempTreatment in tempTreatments)
                {
                    if (!(tempTreatment is HydraulicFracturingTreatment)) continue;
                    var hfTreatment = (HydraulicFracturingTreatment) tempTreatment;

                    var tempStages = seismosContext.Stages
                        .Where(st => st.HydraulicFracturingTreatmentId == hfTreatment.Id)
                        .OrderBy(st => st.Number)
                        .ToList();
                    foreach (var tempStage in tempStages)
                    {
                        stageNodes.Add(new NavStageNode()
                        {
                            Id = tempStage.Id,
                            Name = $"Stage {tempStage.Number}{(tempTreatments.Count > 1 ? " HFT " + tempTreatments.Count : "")}"
                        });
                    }
                }

            }

            return stageNodes;
        }

    }
}
