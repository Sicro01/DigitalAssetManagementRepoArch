using System.Linq;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetAllPhases;
using FluentValidation;
using MediatR;

namespace DigitalAssetManagementRepoArch.Application.Phases.Commands.CreatePhase
{
    public class CreatePhaseCommandValidator : AbstractValidator<CreatePhaseViewModel>
    {
        public CreatePhaseCommandValidator(IMediator mediator)
        {
            RuleFor(p => p)
                .MustAsync(async (createPhaseViewModel, ct) =>
                    await DoesPhaseNameAlreadyExist(createPhaseViewModel, mediator))
                .WithMessage(x => $"Phase Name Error: Phase Name \"{x.CreatePhaseDto.Name}\" already exists, please choose another name.");

            RuleFor(p => p.CreatePhaseDto.Name)
                .Length(1, 15).WithMessage("Phase Name Error: Phase Name must be between 1 and 30 characters.")
                .NotNull().WithMessage("Phase Name Error: Phase Name must not be empty.")
                .NotEmpty().WithMessage("Phase Name Error: Phase Name must not be empty.");

            RuleFor(p => p.CreatePhaseDto.EndDate)
                .GreaterThan(p => p.CreatePhaseDto.StartDate)
                .WithMessage("Phase End Date Error: Phase End Date must be greater than Phase Start Date.");
        }

        private static async Task<bool> DoesPhaseNameAlreadyExist(CreatePhaseViewModel createPhaseViewModel, IMediator mediator)
        {
            var allPhases = await mediator.Send(new GetAllPhasesQuery());
            return allPhases.DisplayAllPhaseDtoList.All(phase => phase.Name != createPhaseViewModel.CreatePhaseDto.Name);
        }
    }
}