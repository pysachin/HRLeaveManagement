using AutoMapper;
using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    class GetLeaveAllocationsDetailsHandler : IRequestHandler<GetLeaveAllocationsDetailsRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationsDetailsHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper
            )
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationsDetailsRequest request, 
            CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}
