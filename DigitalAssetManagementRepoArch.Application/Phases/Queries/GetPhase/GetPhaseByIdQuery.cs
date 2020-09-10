using DigitalAssetManagementRepoArch.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalAssetManagementRepoArch.Application.Phases.Queries.GetPhase
{
    public class GetPhaseByIdQuery : IRequest<GetPhaseByIdViewModel>
    {
        public int Id { get; set; }
        public GetPhaseByIdQuery()
        {
        }

        public class GetPhaseByIdQueryHandler : IRequestHandler<GetPhaseByIdQuery, GetPhaseByIdViewModel>
        {
            private readonly IPhaseRepository _phaseRepository;

            public GetPhaseByIdQueryHandler(IPhaseRepository phaseRepository)
            {
                _phaseRepository = phaseRepository;
            }

            public async Task<GetPhaseByIdViewModel> Handle(GetPhaseByIdQuery request,
                CancellationToken cancellationToken)
            {
                return await _phaseRepository.GetPhaseByIdRepoQuery(request.Id);
            }
        }
    }
}
