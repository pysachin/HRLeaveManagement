using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistance.Contracts;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationsDetailsCommandHandler : IRequestHandler<CreateLeaveAllocationsDetailsCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationsDetailsCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper
            )
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationsDetailsCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.leaveAllocation);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
