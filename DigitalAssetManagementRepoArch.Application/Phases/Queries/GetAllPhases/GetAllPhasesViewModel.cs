using System;
using System.Collections.Generic;
using System.Text;
using DigitalAssetManagementRepoArch.Application.Phases.Dtos;

namespace DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases
{
    public class GetAllPhasesViewModel
    {
        public IList<PhaseDto> DisplayAllPhaseDtoList { get; set; }
    }
}
