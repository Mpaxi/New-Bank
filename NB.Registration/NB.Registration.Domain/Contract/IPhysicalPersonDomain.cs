using NB.Registration.Domain.Commands;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Threading.Tasks;

namespace NB.Registration.Domain.Contract
{
    public interface IPhysicalPersonDomain
    {
        Task<TransportEntity> GetPhysicalPersonByID(Guid PhysicalPersonID);
        Task<TransportEntity> AddPhysicalPerson(AddPhysicalPersonCommand PhysicalPerson);
    }
}
