using DigitalAssetManagementRepoArch.Application.Phases.Commands.CreatePhase;
using DigitalAssetManagementRepoArch.Application.Phases.Commands.DeletePhase;
using DigitalAssetManagementRepoArch.Application.Phases.Commands.UpdatePhase;
using DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase;
using DigitalAssetManagementRepoArch.Application.PhaseStrategies.Queries.GetPhaseStrategies;
using DigitalAssetManagementRepoArch.Application.Strategies.Commands.CreateStrategy;
using DigitalAssetManagementRepoArch.Application.Strategies.Commands.DeleteStrategy;
using DigitalAssetManagementRepoArch.Application.Strategies.Commands.UpdateStrategy;
using DigitalAssetManagementRepoArch.Application.Strategies.Queries.GetStrategy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.WebUI.Controllers
{
    public class PhaseStrategyController : Controller
    {
        private readonly IMediator _mediator;

        public PhaseStrategyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Phase Strategies
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllPhaseStrategiesQuery()));
        }

        //Phase
        [HttpGet]
        public async Task<IActionResult> EditPhase(int id)
        {
            return View(await _mediator.Send(new GetPhaseByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> EditPhase(GetPhaseByIdViewModel updatePhaseViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(updatePhaseViewModel);
            }
            else
            {
                await _mediator.Send(new UpdatePhaseCommand() { UpdatePhaseViewModel = updatePhaseViewModel });
                return Redirect("Index");
            }
        }

        [HttpGet]
        public IActionResult CreatePhase()
        {
            return View("CreatePhase");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhase(CreatePhaseViewModel createPhaseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createPhaseViewModel);
            }
            else
            {
                await _mediator.Send(new CreatePhaseCommand() { CreatePhaseViewModel = createPhaseViewModel });
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeletePhase(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                await _mediator.Send(new DeletePhaseCommand() { DeletePhaseId = id });
                return Json(new { result = "Redirect", url = Url.Action("Index", "PhaseStrategy") });
            }
        }

        // Strategy
        [HttpGet]
        public async Task<IActionResult> EditStrategy(int id)
        {
            return View(await _mediator.Send( new GetStrategyByIdQuery() {Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> EditStrategy(GetStrategyByIdViewModel updateStrategyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateStrategyViewModel);
            }
            else
            {
                await _mediator.Send(new UpdateStrategyCommand() { UpdateStrategyViewModel = updateStrategyViewModel });
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult CreateStrategy()
        {
            return View("CreateStrategy");
        }

        [HttpPost]
        public async Task<IActionResult> CreateStrategy(CreateStrategyViewModel createStrategyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createStrategyViewModel);
            }
            else
            {
                await _mediator.Send(new CreateStrategyCommand() {CreateStrategyViewModel = createStrategyViewModel});
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStrategy(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                await _mediator.Send(new DeleteStrategyCommand() { DeleteStrategyId= id });
                return Json(new { result = "Redirect", url = Url.Action("Index", "PhaseStrategy") });
            }
        }

        public ActionResult Cancel()
        {
            return View("Index");
        }
    }
}
