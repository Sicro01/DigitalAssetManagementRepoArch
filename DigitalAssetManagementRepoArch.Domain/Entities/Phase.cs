using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class Phase 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual IList<PhaseStrategy> PhaseStrategies { get; private set; } = new List<PhaseStrategy>();
    }
}
