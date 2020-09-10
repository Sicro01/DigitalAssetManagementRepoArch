using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using DigitalAssetManagementRepoArch.Application.Phases.Commands.CreatePhase;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using DigitalAssetManagementRepoArch.Application.Phases.Commands.UpdatePhase;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;
using DigitalAssetManagementRepoArch.Application.Strategies.Commands.UpdateStrategy;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DigitalAssetManagementRepoArch.WebUI.Controllers
{
    public class PhaseStrategyController : Controller
    {
        private readonly IPhaseRepository _phaseRepo;
        private readonly IStrategyRepository _strategyRepo;
        private readonly IMediator _mediator;

        public PhaseStrategyController(IPhaseRepository phaseRepo, IStrategyRepository strategyRepo, IMediator mediator)
        {
            _phaseRepo = phaseRepo;
            _strategyRepo= strategyRepo;
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllPhaseStrategiesQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> EditPhase(int id)
        {
            return View(await _mediator.Send(new GetPhaseByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> EditPhase(GetPhaseByIdViewModel updatedPhaseViewModel)
        {
            //var v = new UpdatePhaseCommandValidator();
            //var r = await v.ValidateAsync(updatedPhaseViewModel);

            if (!ModelState.IsValid)
            {
                return View(updatedPhaseViewModel);
            }
            else
            {
                await _mediator.Send(new UpdatePhaseCommand() { UpdatedPhaseViewModel = updatedPhaseViewModel });
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditStrategy(int id)
        {
            return View(await _strategyRepo.GetStrategyById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditStrategy(GetStrategyByIdViewModel strategyByIdViewModel)
        {
            await _mediator.Send(new UpdateStrategyCommand() {UpdatedStrategyDto = strategyByIdViewModel.DisplayStrategy});
            //await _strategyRepo.UpdateStrategy(strategyByIdViewModel, cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpGet]
        //public async Task<IActionResult> CreatePhase(CreatePhaseViewModel createPhaseViewModel)
        //{
        //    //return View("CreatePhase");
        //}
        [HttpPost]
        public async Task<IActionResult> CreatePhase(CreatePhaseViewModel createPhaseViewModel, CancellationToken cancellationToken)
        {
            await _phaseRepo.CreatePhase(createPhaseViewModel, cancellationToken);
            return RedirectToAction("Index");
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
