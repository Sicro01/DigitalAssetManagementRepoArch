using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;

namespace DigitalAssetManagementRepoArch.Application.Phases.Dtos
{
    public class PhaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public virtual IList<PhaseStrategyDto> PhaseStrategyDtoList { get; private set; } = new List<PhaseStrategyDto>();
    }
}
