using AutoMapper;
using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    class GetLeaveRequestsListHandler : IRequestHandler<GetLeaveRequestsListRequest, IReadOnlyList<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestsListHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper
            )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<LeaveRequestListDto>> Handle(GetLeaveRequestsListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestWithDetails();

            return _mapper.Map<IReadOnlyList<LeaveRequestListDto>>(leaveRequests);
        }
    }
}
