using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationsDetailsCommandHandler : IRequestHandler<UpdateLeaveAllocationsDetailsCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationsDetailsCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper
            )
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationsDetailsCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocation.Id);

            _mapper.Map(request.UpdateLeaveAllocation, leaveAllocation);

            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
