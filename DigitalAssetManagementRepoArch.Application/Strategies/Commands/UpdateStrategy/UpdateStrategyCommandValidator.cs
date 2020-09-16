using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetAllStrategies;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Strategies.Commands.UpdateStrategy
{
    public class UpdateStrategyCommandValidator : AbstractValidator<GetStrategyByIdViewModel>
    {
        public UpdateStrategyCommandValidator(IMediator mediator)
        {
            RuleFor(p => p)
                .MustAsync(async (getStrategyByIdViewModel, ct) =>
                    await DoesStrategyNameAlreadyExist(getStrategyByIdViewModel, mediator))
                .WithMessage(x => $"Strategy Name Error: Strategy Name \"{x.DisplayStrategyDto.Name}\" already exists, please choose another name.");

            RuleFor(p => p.DisplayStrategyDto.Name)
                .Length(1, 15).WithMessage("Strategy Name Error: Strategy Name must be between 1 and 30 characters.")
                .NotNull().WithMessage("Strategy Name Error: Strategy Name must not be empty.")
                .NotEmpty().WithMessage("Strategy Name Error: Strategy Name must not be empty.");

            RuleFor(p => p.DisplayStrategyDto.EndDate)
                .GreaterThan(p => p.DisplayStrategyDto.StartDate)
                .WithMessage("Strategy End Date Error: Strategy End Date must be greater than Strategy Start Date.");
        }

        private static async Task<bool> DoesStrategyNameAlreadyExist(GetStrategyByIdViewModel getStrategyByIdViewModel, IMediator mediator)
        {
            var editStrategyDto = await mediator.Send(new GetStrategyByIdQuery() { Id = getStrategyByIdViewModel.DisplayStrategyDto.Id });
            var originalStrategyName = editStrategyDto.DisplayStrategyDto.Name;
            var updatedStrategyName = getStrategyByIdViewModel.DisplayStrategyDto.Name;

            if (originalStrategyName == updatedStrategyName)
            {
                // If user hasn't changed the strategy name go no further
                return true;
            }
            else
            {
                // If user has changed strategy name check it isn't being used by another strategy
                var allStrategies = await mediator.Send(new GetAllStrategiesQuery());
                return allStrategies.AllStrategyDtoList.All(strategy => strategy.Name != updatedStrategyName);
            }
        }
    }
}