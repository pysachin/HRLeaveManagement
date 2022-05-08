using AutoMapper;
using HRLeaveManagement.Application.DTOs;
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
    public class GetLeaveRequestsDetailsHandler : IRequestHandler<GetLeaveRequestsDetailsRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestsDetailsHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper
            )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestsDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);

            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
