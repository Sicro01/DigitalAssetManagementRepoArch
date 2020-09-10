using System;
using System.Collections.Generic;

namespace DigitalAssetManagementRepoArch.Domain.Entities
{
    public class Strategy 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual IList<PhaseStrategy> PhaseStrategyList { get; private set; } = new List<PhaseStrategy>();
    }
}
