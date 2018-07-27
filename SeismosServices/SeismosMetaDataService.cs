using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
                    KeyValuePairs = new List<KeyValueMutable<string, object>>()
                    {
                        new KeyValueMutable<string, object>(ClientName, String.Empty),
                        new KeyValueMutable<string, object>(ContactName, String.Empty),
                        new KeyValueMutable<string, object>(EmailAddress, String.Empty),
                        new KeyValueMutable<string, object>(PhoneNumber, String.Empty)
                    }
                }
            };



            foreach (var seismosClient in seismosClients)
            {
                keyValueEntities.Add(new KeyValueEntity()
                {
                    Id = seismosClient.Id,
                    Name = seismosClient.ClientName,
                    KeyValuePairs = new List<KeyValueMutable<string, object>>()
                    {
                        new KeyValueMutable<string, object>(ClientName, seismosClient.ClientName),
                        new KeyValueMutable<string, object>(ContactName, seismosClient.Contact),
                        new KeyValueMutable<string, object>(EmailAddress, seismosClient.Email),
                        new KeyValueMutable<string, object>(PhoneNumber, seismosClient.PhoneNumber)
                    }
                });
            }

            return keyValueEntities;
        }

        public List<KeyValueEntity> GetSeismosProjectsAlt(Guid seismosClientId)
        {

            List<KeyValueEntity> keyValueEntities = new List<KeyValueEntity>
            {
                new KeyValueEntity()
                {
                    Id = Guid.Empty,
                    Name = String.Empty,
                    KeyValuePairs = new List<KeyValueMutable<string, object>>()
                    {
                        new KeyValueMutable<string, object>(ProjectName, String.Empty),
                        new KeyValueMutable<string, object>(Field, String.Empty),
                        new KeyValueMutable<string, object>(Pad, String.Empty),
                        new KeyValueMutable<string, object>(JobNum, String.Empty),
                        new KeyValueMutable<string, object>(AFENum, String.Empty),
                        new KeyValueMutable<string, object>(Formation, String.Empty),
                        new KeyValueMutable<string, object>(County, String.Empty),
                        new KeyValueMutable<string, object>(State, String.Empty),
                        new KeyValueMutable<string, object>(StartDate, String.Empty),
                        new KeyValueMutable<string, object>(EndDate, String.Empty),
                        new KeyValueMutable<string, object>(LastModified, String.Empty),
                        new KeyValueMutable<string, object>(LastModifiedBy, String.Empty)
                    }
                }
            };

            List<SeismosProject> seismosProjects;
            if (seismosClientId == Guid.Empty)
                return keyValueEntities;

            using (var seismosContext = new seismosEntities())
            {
                seismosProjects = seismosContext.SeismosProjects.Where(sp => sp.SeismosClientId == seismosClientId).ToList();
            }

            foreach (var seismosProject in seismosProjects)
            {
                keyValueEntities.Add(new KeyValueEntity()
                {
                    Id = seismosProject.Id,
                    Name = seismosProject.Name,
                    KeyValuePairs = new List<KeyValueMutable<string, object>>()
                    {
                        new KeyValueMutable<string, object>(ProjectName, seismosProject.Name ?? String.Empty),
                        new KeyValueMutable<string, object>(Field, seismosProject.Field ?? String.Empty),
                        new KeyValueMutable<string, object>(Pad, seismosProject.Pad ?? String.Empty),
                        new KeyValueMutable<string, object>(JobNum, seismosProject.JobNum ?? String.Empty),
                        new KeyValueMutable<string, object>(AFENum, seismosProject.AFENum ?? String.Empty),
                        new KeyValueMutable<string, object>(Formation, seismosProject.Formation ?? String.Empty),
                        new KeyValueMutable<string, object>(County, seismosProject.County ?? String.Empty),
                        new KeyValueMutable<string, object>(State, seismosProject.State ?? String.Empty),
                        new KeyValueMutable<string, object>(StartDate, seismosProject.StartDate),
                        new KeyValueMutable<string, object>(EndDate, seismosProject.EndDate),
                        new KeyValueMutable<string, object>(LastModified, seismosProject.LastModified),
                        new KeyValueMutable<string, object>(LastModifiedBy, seismosProject.LastModifiedBy ?? String.Empty)
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
                            updateSeismosClient.ClientName = keyValuePair.Text.ToString();
                            break;
                        case ContactName:
                            updateSeismosClient.Contact = keyValuePair.ToString();
                            break;
                        case EmailAddress:
                            updateSeismosClient.Email = keyValuePair.Text.ToString();
                            break;
                        case PhoneNumber:
                            updateSeismosClient.PhoneNumber = keyValuePair.Text.ToString();
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

        public Guid UpdateSeismosProjectAlt(KeyValueEntity seismosKeyValueEntity, Guid seismosClientId)
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
                updateSeismoProject.SeismosClientId = seismosClientId;

                foreach (var keyValuePair in seismosKeyValueEntity.KeyValuePairs)
                {
                    switch (keyValuePair.Id)
                    {
                        case ProjectName:
                            updateSeismoProject.Name = keyValuePair.Text.ToString();
                            break;
                        case Field:
                            updateSeismoProject.Field = keyValuePair.Text.ToString();
                            break;
                        case Pad:
                            updateSeismoProject.Pad = keyValuePair.Text.ToString();
                            break;
                        case JobNum:
                            updateSeismoProject.JobNum = keyValuePair.Text.ToString();
                            break;
                        case AFENum:
                            updateSeismoProject.AFENum = keyValuePair.Text.ToString();
                            break;
                        case Formation:
                            updateSeismoProject.Formation = keyValuePair.Text.ToString();
                            break;
                        case County:
                            updateSeismoProject.County = keyValuePair.Text.ToString();
                            break;
                        case State:
                            updateSeismoProject.State = keyValuePair.Text.ToString();
                            break;
                        case StartDate:
                            updateSeismoProject.StartDate = (DateTime) keyValuePair.Text;
                            break;
                        case EndDate:
                            updateSeismoProject.EndDate = (DateTime)keyValuePair.Text;
                            break;
                        case LastModified:
                            updateSeismoProject.LastModified = (DateTime)keyValuePair.Text;
                            break;
                        case LastModifiedBy:
                            updateSeismoProject.LastModifiedBy = keyValuePair.Text.ToString();
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
