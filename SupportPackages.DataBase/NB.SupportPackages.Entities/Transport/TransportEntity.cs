using System.Collections.Generic;

namespace NB.SupportPackages.Entities.Transport
{
    public class TransportEntity
    {
        public bool Sucess { get; set; }
        public ICollection<string> Messages { get; set; } = new List<string>();
        public object Data { get; set; }

    }
}
