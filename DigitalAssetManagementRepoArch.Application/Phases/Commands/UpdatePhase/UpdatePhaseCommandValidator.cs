using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Phases.Commands.UpdatePhase
{
    public class UpdatePhaseCommandValidator : AbstractValidator<GetPhaseByIdViewModel>
    {
        public UpdatePhaseCommandValidator(IMediator mediator)
        {
            RuleFor(p => p)
                .MustAsync(async (getPhaseByIdViewModel, ct) =>
                    await DoesPhaseNameAlreadyExist(getPhaseByIdViewModel, mediator))
                .WithMessage(x => $"Phase Name Error: Phase Name \"{x.DisplayPhaseDto.Name}\" already exists, please choose another name.");

            RuleFor(p => p.DisplayPhaseDto.Name)
                .Length(1, 15).WithMessage("Phase Name Error: Phase Name must be between 1 and 30 characters.")
                .NotNull().WithMessage("Phase Name Error: Phase Name must not be empty.")
                .NotEmpty().WithMessage("Phase Name Error: Phase Name must not be empty."); 
            
            RuleFor(p => p.DisplayPhaseDto.EndDate)
                .GreaterThan(p => p.DisplayPhaseDto.StartDate)
                .WithMessage("Phase End Date Error: Phase End Date must be greater than Phase Start Date.");
        }

        private static async Task<bool> DoesPhaseNameAlreadyExist(GetPhaseByIdViewModel getPhaseByIdViewModel, IMediator mediator)
        {
            //var editPhaseDto = await phaseRepository.GetPhaseByIdRepoQuery(getPhaseByIdViewModel.DisplayPhaseDto.Id);
            var editPhaseDto = await mediator.Send(new GetPhaseByIdQuery()
                {Id = getPhaseByIdViewModel.DisplayPhaseDto.Id});
            var originalPhaseName = editPhaseDto.DisplayPhaseDto.Name;
            var updatedPhaseName = getPhaseByIdViewModel.DisplayPhaseDto.Name;

            if (originalPhaseName == updatedPhaseName)
            {
                // If user hasn't changed the phase name go no further
                return true;
            }
            else
            {
                // If user has changed phase name check it isn't being used by another phase
                var allPhases = await mediator.Send(new GetAllPhasesQuery());
                return allPhases.DisplayAllPhaseDtoList.All(phase => phase.Name != updatedPhaseName);
            }
        }
    }
}