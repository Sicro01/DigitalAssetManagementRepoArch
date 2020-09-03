using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class PhaseStrategy 
    {
        public int Id { get; set; }
        public int PhaseId { get; set; }
        public int StrategyId { get; set; }
        public virtual Phase Phase { get; set; }
        public virtual Strategy Strategy { get; set; }
        public IList<PSChannel> PSChannels { get; set; }
            //= new List<PSChannel>();
    }
}
