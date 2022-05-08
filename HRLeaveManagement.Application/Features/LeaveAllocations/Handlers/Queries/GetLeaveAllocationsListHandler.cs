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
    class GetLeaveAllocationsListHandler : IRequestHandler<GetLeaveAllocationsListRequest, IReadOnlyList<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationsListHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper
            )
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<LeaveAllocationDto>> Handle(GetLeaveAllocationsListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();

            return _mapper.Map<IReadOnlyList<LeaveAllocationDto>>(leaveAllocation);
        }
    }
}
