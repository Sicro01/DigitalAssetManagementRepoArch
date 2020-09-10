using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Phases.Commands.UpdatePhase
{
    public class UpdatePhaseCommandValidator : AbstractValidator<GetPhaseByIdViewModel>
    {
        private readonly IPhaseRepository _phaseRepository;
        //private readonly PropertyValidatorContext _context;

        public UpdatePhaseCommandValidator(IPhaseRepository phaseRepository)
        {
            _phaseRepository = phaseRepository;
            //_context = context;

            RuleFor(p => p.DisplayPhase.EndDate)
                .GreaterThan(p => p.DisplayPhase.StartDate)
                .WithMessage("Phase End Date Error: Phase End Date must be greater than Phase Start Date.");
            RuleFor(p => p.DisplayPhase.Name)
                .Length(1, 15).WithMessage("Phase Name Error: Phase Name must be between 1 and 30 characters.")
                .NotNull().WithMessage("Phase Name Error: Phase Name must not be empty.")
                .NotEmpty().WithMessage("Phase Name Error: Phase Name must not be empty.");
            RuleFor(p => p)
                .MustAsync(async (getPhaseByIdViewModel, ct) =>
                    await DoesPhaseNameAlreadyExist(getPhaseByIdViewModel, phaseRepository))
                .WithMessage(x => $"Phase Name Error: Phase Name \"{x.DisplayPhase.Name}\" already exists, please choose another name.");
        }

        

        private static async Task<bool> DoesPhaseNameAlreadyExist(GetPhaseByIdViewModel getPhaseByIdViewModel, IPhaseRepository phaseRepository)
        {

            var editPhaseDto = await phaseRepository.GetPhaseByIdRepoQuery(getPhaseByIdViewModel.DisplayPhase.Id);
            var originalPhaseName = editPhaseDto.DisplayPhase.Name;
            var updatedPhaseName = getPhaseByIdViewModel.DisplayPhase.Name;

            
            if (originalPhaseName == updatedPhaseName)
            {
                // If user hasn't changed the phase name go no further
                return true;
            }
            else
            {
                // If user has changed phase name check it isn't being sed by another phase
                var allPhases = await phaseRepository.GetAllPhasesRepoQuery();
                return allPhases.AllPhaseDtoList.All(phase => phase.Name != updatedPhaseName);
            }
        }
    }
}