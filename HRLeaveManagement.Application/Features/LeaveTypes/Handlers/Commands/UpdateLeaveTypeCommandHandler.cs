using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Persistance.Contracts;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
            )
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            var leaveType = await _leaveTypeRepository.Get(request.leaveTypeDto.Id);

            _mapper.Map(request.leaveTypeDto, leaveType);

            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
