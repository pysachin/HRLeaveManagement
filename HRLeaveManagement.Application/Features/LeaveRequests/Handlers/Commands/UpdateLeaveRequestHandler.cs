using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestCommand,Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestHandler(
            ILeaveRequestRepository leaveAllocationRepository,
            IMapper mapper
            )
        {
            _leaveRequestRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.leaveRequestDto != null)
            {            
                _mapper.Map(request.leaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.changeLeaveRequestApproval != null)
            {                
               await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.changeLeaveRequestApproval.Approved);  

            }
            

            return Unit.Value;  
        }

    }
}
