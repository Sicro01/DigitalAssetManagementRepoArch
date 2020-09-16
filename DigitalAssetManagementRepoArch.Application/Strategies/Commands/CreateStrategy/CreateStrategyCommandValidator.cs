using System.Linq;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetAllStrategies;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy;
using FluentValidation;
using MediatR;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Commands.CreateStrategy
{
    public class CreateStrategyCommandValidator : AbstractValidator<CreateStrategyViewModel>
    {
        public CreateStrategyCommandValidator(IMediator mediator)
        {
            RuleFor(p => p)
                .MustAsync(async (createStrategyViewModel, ct) =>
                    await DoesStrategyNameAlreadyExist(createStrategyViewModel, mediator))
                .WithMessage(x => $"Strategy Name Error: Strategy Name \"{x.CreateStrategyDto.Name}\" already exists, please choose another name.");

            RuleFor(p => p.CreateStrategyDto.Name)
                .Length(1, 15).WithMessage("Strategy Name Error: Strategy Name must be between 1 and 30 characters.")
                .NotNull().WithMessage("Strategy Name Error: Strategy Name must not be empty.")
                .NotEmpty().WithMessage("Strategy Name Error: Strategy Name must not be empty.");

            RuleFor(p => p.CreateStrategyDto.EndDate)
                .GreaterThan(p => p.CreateStrategyDto.StartDate)
                .WithMessage("Strategy End Date Error: Strategy End Date must be greater than Strategy Start Date.");
        }

        private static async Task<bool> DoesStrategyNameAlreadyExist(CreateStrategyViewModel createStrategyViewModel, IMediator mediator)
        {
            // If user has changed strategy name check it isn't being used by another strategy
            var allStrategies = await mediator.Send(new GetAllStrategiesQuery());
            return allStrategies.AllStrategyDtoList.All(strategy => strategy.Name != createStrategyViewModel.CreateStrategyDto.Name);
        }
    }
}