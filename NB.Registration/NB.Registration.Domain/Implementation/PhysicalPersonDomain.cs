using NB.Registration.Domain.Aggregates;
using NB.Registration.Domain.Commands;
using NB.Registration.Domain.Contract;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NB.Registration.Domain.Implementation
{
    public class PhysicalPersonDomain : IPhysicalPersonDomain
    {
        readonly IPhysicalPersonRepository PhysicalPersonRepository;
        readonly TransportEntity ObjReturn = new TransportEntity();
        public PhysicalPersonDomain(IPhysicalPersonRepository PhysicalPersonRepository)
        {
            this.PhysicalPersonRepository = PhysicalPersonRepository;
        }
        public async Task<TransportEntity> GetPhysicalPersonByID(Guid PhysicalPersonID)
        {
            try
            {
                ObjReturn.Sucess = true;
                ObjReturn.Data = await PhysicalPersonRepository.GetAsync(w => w.ID.Equals(PhysicalPersonID), true, i => i.InternetAddresses, d => d.Documents);
                return ObjReturn;
            }
            catch (Exception ex)
            {
                ObjReturn.Sucess = false;
                ObjReturn.Messages.Add(ex.Message);
                return ObjReturn;
            }

        }


        public async Task<TransportEntity> AddPhysicalPerson(AddPhysicalPersonCommand PhysicalPerson)
        {
            try
            {
                PhysicalPerson physicalPerson = new PhysicalPerson()
                {
                    Name = PhysicalPerson.Name,
                    Birthdate = PhysicalPerson.Birthday,
                    Documents = PhysicalPerson.Documents.ToList(),
                    InternetAddresses = PhysicalPerson.InternetAddresses.ToList()
                };

                ObjReturn.Sucess = true;
                ObjReturn.Data = await PhysicalPersonRepository.AddAsync(physicalPerson);
                return ObjReturn;
            }
            catch (Exception ex)
            {
                ObjReturn.Sucess = false;
                ObjReturn.Messages.Add(ex.Message);
                return ObjReturn;
            }

        }

    }
}
