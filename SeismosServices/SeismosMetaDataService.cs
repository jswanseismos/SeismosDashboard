using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeismosDataLibrary;

namespace SeismosServices
{
    public class SeismosMetaDataService
    {
        private const string ClientName = "Client Name";
        private const string ContactName = "Contact Name";
        private const string EmailAddress = "Email Address";
        private const string PhoneNumber = "Phone Number";

        private const string ProjectName = "Project Name";
        private const string Field = "Field";
        private const string Pad = "Pad";
        private const string JobNum = "Job Number";
        private const string AFENum = "AFE Number";
        private const string Formation = "Formation";
        private const string County = "County";
        private const string State = "State";
        private const string StartDate = "Start Date";
        private const string EndDate = "End Date";
        private const string LastModified = "Date Last Modified";
        private const string LastModifiedBy = "Last Modified by";


        // creates the model

        // CRUD clients
        // CRUD projects
        // CRUD wells

        public void AddSeismosClient(SeismosClient seismosClient)
        {
            seismosClient.Id = Guid.NewGuid();
            using (var seismosContext = new seismosEntities())
            {
                seismosContext.SeismosClients.Add(seismosClient);
                seismosContext.SaveChanges();
            }

        }

        public List<SeismosClient> GetSeismosClients()
        {
            List<SeismosClient> seismosClients;

            using (var seismosContext = new seismosEntities())
            {
                seismosClients = seismosContext.SeismosClients.ToList();
            }

//            List<KeyValueEntity> keyValueEntities = new List<KeyValueEntity>();

//            foreach (var seismosClient in seismosClients)
//            {
//                keyValueEntities.Add(new KeyValueEntity()
//                {
//                    Id = seismosClient.Id,
//                    Name = seismosClient.ClientName,
//                    KeyValuePairs = new List<KeyValueMutable<string, string>>()
//                    {
//                        new KeyValueMutable<string, string>("Client Name", seismosClient.ClientName),
//                        new KeyValueMutable<string, string>("Contact Name", seismosClient.Contact),
//                        new KeyValueMutable<string, string>("Email address", seismosClient.Email),
//                        new KeyValueMutable<string, string>("Phone Number", seismosClient.PhoneNumber)
//                    }
//                });
//            }


            return seismosClients;
        }


        public List<KeyValueEntity> GetSeismosClientsAlt()
        {


            List<SeismosClient> seismosClients;

            using (var seismosContext = new seismosEntities())
            {
                seismosClients = seismosContext.SeismosClients.ToList();
            }

            List<KeyValueEntity> keyValueEntities = new List<KeyValueEntity>
            {
                new KeyValueEntity()
                {
                    Id = Guid.Empty,
                    Name = String.Empty,
                    KeyValuePairs = new List<KeyValueMutable<string, string>>()
                    {
                        new KeyValueMutable<string, string>(ClientName, String.Empty),
                        new KeyValueMutable<string, string>(ContactName, String.Empty),
                        new KeyValueMutable<string, string>(EmailAddress, String.Empty),
                        new KeyValueMutable<string, string>(PhoneNumber, String.Empty)
                    }
                }
            };



            foreach (var seismosClient in seismosClients)
            {
                keyValueEntities.Add(new KeyValueEntity()
                {
                    Id = seismosClient.Id,
                    Name = seismosClient.ClientName,
                    KeyValuePairs = new List<KeyValueMutable<string, string>>()
                    {
                        new KeyValueMutable<string, string>(ClientName, seismosClient.ClientName),
                        new KeyValueMutable<string, string>(ContactName, seismosClient.Contact),
                        new KeyValueMutable<string, string>(EmailAddress, seismosClient.Email),
                        new KeyValueMutable<string, string>(PhoneNumber, seismosClient.PhoneNumber)
                    }
                });
            }

            return keyValueEntities;
        }

        public List<KeyValueEntity> GetSeismosProjectsAlt(Guid seismosClientId)
        {
            List<SeismosProject> seismosProjects;
            if (seismosClientId == Guid.Empty) return null;

            using (var seismosContext = new seismosEntities())
            {
                seismosProjects = seismosContext.SeismosProjects.Where(sp => sp.SeismosClientId == seismosClientId).ToList();
            }

            List<KeyValueEntity> keyValueEntities = new List<KeyValueEntity>
            {
                new KeyValueEntity()
                {
                    Id = Guid.Empty,
                    Name = String.Empty,
                    KeyValuePairs = new List<KeyValueMutable<string, string>>()
                    {
                        new KeyValueMutable<string, string>(ProjectName, String.Empty),
                        new KeyValueMutable<string, string>(Field, String.Empty),
                        new KeyValueMutable<string, string>(Pad, String.Empty),
                        new KeyValueMutable<string, string>(JobNum, String.Empty),
                        new KeyValueMutable<string, string>(AFENum, String.Empty),
                        new KeyValueMutable<string, string>(Formation, String.Empty),
                        new KeyValueMutable<string, string>(County, String.Empty),
                        new KeyValueMutable<string, string>(State, String.Empty),
                        new KeyValueMutable<string, string>(StartDate, String.Empty),
                        new KeyValueMutable<string, string>(EndDate, String.Empty),
                        new KeyValueMutable<string, string>(LastModified, String.Empty),
                        new KeyValueMutable<string, string>(LastModifiedBy, String.Empty)
                    }
                }
            };



            foreach (var seismosProject in seismosProjects)
            {
                keyValueEntities.Add(new KeyValueEntity()
                {
                    Id = seismosProject.Id,
                    Name = seismosProject.Name,
                    KeyValuePairs = new List<KeyValueMutable<string, string>>()
                    {
                        new KeyValueMutable<string, string>(ProjectName, seismosProject.Name),
                        new KeyValueMutable<string, string>(Field, seismosProject.Field),
                        new KeyValueMutable<string, string>(Pad, seismosProject.Pad),
                        new KeyValueMutable<string, string>(JobNum, seismosProject.JobNum),
                        new KeyValueMutable<string, string>(AFENum, seismosProject.AFENum),
                        new KeyValueMutable<string, string>(Formation, seismosProject.Formation),
                        new KeyValueMutable<string, string>(County, seismosProject.County),
                        new KeyValueMutable<string, string>(State, seismosProject.State),
                        new KeyValueMutable<string, string>(StartDate, seismosProject.StartDate.ToString("G")),
                        new KeyValueMutable<string, string>(EndDate, seismosProject.EndDate.ToString("G")),
                        new KeyValueMutable<string, string>(LastModified, seismosProject.LastModified.ToString("G")),
                        new KeyValueMutable<string, string>(LastModifiedBy, seismosProject.LastModifiedBy)
                    }
                });
            }

            return keyValueEntities;
        }

        public Guid UpdateSeismosClientAlt(KeyValueEntity seismosKeyValueEntity)
        {
            Guid retGuid;
            using (var seismosContext = new seismosEntities())
            {
                SeismosClient updateSeismosClient;
                bool bNew = false;
                if (seismosKeyValueEntity.Id == Guid.Empty)
                {
                    updateSeismosClient = new SeismosClient {Id = Guid.NewGuid()};
                    bNew = true;
                }
                else
                {
                    updateSeismosClient = seismosContext.SeismosClients.FirstOrDefault(sc => sc.Id == seismosKeyValueEntity.Id);
                }
                
                if (updateSeismosClient == null) return Guid.Empty;

                foreach (var keyValuePair in seismosKeyValueEntity.KeyValuePairs)
                {
                    switch (keyValuePair.Id)
                    {
                        case ClientName:
                            updateSeismosClient.ClientName = keyValuePair.Text;
                            break;
                        case ContactName:
                            updateSeismosClient.Contact = keyValuePair.Text;
                            break;
                        case EmailAddress:
                            updateSeismosClient.Email = keyValuePair.Text;
                            break;
                        case PhoneNumber:
                            updateSeismosClient.PhoneNumber = keyValuePair.Text;
                            break;
                    }
                }

                if (bNew)
                {
                    seismosContext.SeismosClients.Add(updateSeismosClient);
                }

                retGuid = updateSeismosClient.Id;
                seismosContext.SaveChanges();

            }

            return retGuid;
        }

        public Guid UpdateSeismosProjectAlt(KeyValueEntity seismosKeyValueEntity)
        {
            Guid retGuid;
            using (var seismosContext = new seismosEntities())
            {
                SeismosProject updateSeismoProject;
                bool bNew = false;
                if (seismosKeyValueEntity.Id == Guid.Empty)
                {
                    updateSeismoProject = new SeismosProject { Id = Guid.NewGuid() };
                    bNew = true;
                }
                else
                {
                    updateSeismoProject = seismosContext.SeismosProjects.FirstOrDefault(sc => sc.Id == seismosKeyValueEntity.Id);
                }

                if (updateSeismoProject == null) return Guid.Empty;

                foreach (var keyValuePair in seismosKeyValueEntity.KeyValuePairs)
                {
                    switch (keyValuePair.Id)
                    {
                        case ProjectName:
                            updateSeismoProject.Name = keyValuePair.Text;
                            break;
                        case Field:
                            updateSeismoProject.Field = keyValuePair.Text;
                            break;
                        case Pad:
                            updateSeismoProject.Pad = keyValuePair.Text;
                            break;
                        case JobNum:
                            updateSeismoProject.JobNum = keyValuePair.Text;
                            break;
                        case AFENum:
                            updateSeismoProject.AFENum = keyValuePair.Text;
                            break;
                        case Formation:
                            updateSeismoProject.Formation = keyValuePair.Text;
                            break;
                        case County:
                            updateSeismoProject.County = keyValuePair.Text;
                            break;
                        case State:
                            updateSeismoProject.State = keyValuePair.Text;
                            break;
                        case StartDate:
                            updateSeismoProject.StartDate = DateTime.Parse( keyValuePair.Text);
                            break;
                        case EndDate:
                            updateSeismoProject.EndDate = DateTime.Parse(keyValuePair.Text);
                            break;
                        case LastModified:
                            updateSeismoProject.LastModified = DateTime.Parse(keyValuePair.Text);
                            break;
                        case LastModifiedBy:
                            updateSeismoProject.LastModifiedBy = keyValuePair.Text;
                            break;
                    }
                }

                if (bNew)
                {
                    seismosContext.SeismosProjects.Add(updateSeismoProject);
                }

                retGuid = updateSeismoProject.Id;
                seismosContext.SaveChanges();

            }

            return retGuid;
        }

        public void UpdateSeismosClient(SeismosClient seismosClient)
        {
            using (var seismosContext = new seismosEntities())
            {
                var updateSeismosClient = seismosContext.SeismosClients.FirstOrDefault(sc => sc.Id == seismosClient.Id);
                if (updateSeismosClient == null) return;

                updateSeismosClient.ClientName = seismosClient.ClientName;
                updateSeismosClient.Contact = seismosClient.Contact;
                updateSeismosClient.PhoneNumber = seismosClient.PhoneNumber;
                updateSeismosClient.Email = seismosClient.Email;

                seismosContext.SaveChanges();
            }

        }


        public void AddSeismosProject(SeismosProject seismosProject)
        {
            seismosProject.Id = Guid.NewGuid();
            using (var seismosContext = new seismosEntities())
            {
                seismosContext.SeismosProjects.Add(seismosProject);
                seismosContext.SaveChanges();
            }

        }

        public List<SeismosProject> GetSeismosProjects(Guid seismosClientId)
        {
            List<SeismosProject> seismosProjects;

            if (seismosClientId == Guid.Empty) return null;

            using (var seismosContext = new seismosEntities())
            {
                seismosProjects = seismosContext.SeismosProjects.Where(sp => sp.SeismosClientId == seismosClientId).ToList();
            }

            return seismosProjects;
        }

        public void UpdateSeismosProject(SeismosProject seismosProject)
        {
            using (var seismosContext = new seismosEntities())
            {
                var updateSeismosProject = seismosContext.SeismosProjects.FirstOrDefault(sc => sc.Id == seismosProject.Id);
                if (updateSeismosProject == null) return;

                updateSeismosProject.Name = seismosProject.Name;
                updateSeismosProject.Field = seismosProject.Field;
                updateSeismosProject.Pad = seismosProject.Pad;
                updateSeismosProject.JobNum = seismosProject.JobNum;
                updateSeismosProject.AFENum = seismosProject.AFENum;
                updateSeismosProject.Formation = seismosProject.Formation;
                updateSeismosProject.County = seismosProject.County;
                updateSeismosProject.State = seismosProject.State;
                updateSeismosProject.StartDate = seismosProject.StartDate;
                updateSeismosProject.EndDate = seismosProject.EndDate;
                updateSeismosProject.LastModified = seismosProject.LastModified;
                updateSeismosProject.LastModifiedBy = seismosProject.LastModifiedBy;
                updateSeismosProject.SeismosClientId = seismosProject.SeismosClientId;

                seismosContext.SaveChanges();
            }

        }

    }
}
