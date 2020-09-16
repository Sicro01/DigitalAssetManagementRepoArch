using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Domain.Entities;
using MediatR;

namespace DigitalAssetManagementRepoArch.Application.Phases.Commands.CreatePhase
{
    public class CreatePhaseCommand : IRequest
    {
        public CreatePhaseViewModel CreatePhaseViewModel;
        public CreatePhaseCommand()
        {
        }

        public class CreatePhaseCommandHandler : IRequestHandler<CreatePhaseCommand>
        {
            private readonly IPhaseRepository _phaseRepository;

            public CreatePhaseCommandHandler(IPhaseRepository phaseRepository)
            {
                _phaseRepository= phaseRepository;
            }

            public async Task<Unit> Handle(CreatePhaseCommand request, CancellationToken cancellationToken)
            {
                var newPhase = new Phase
                {
                    Name = request.CreatePhaseViewModel.CreatePhaseDto.Name,
                    StartDate = request.CreatePhaseViewModel.CreatePhaseDto.StartDate,
                    EndDate = request.CreatePhaseViewModel.CreatePhaseDto.EndDate
                };

                await _phaseRepository.CreatePhaseRepo(newPhase, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
