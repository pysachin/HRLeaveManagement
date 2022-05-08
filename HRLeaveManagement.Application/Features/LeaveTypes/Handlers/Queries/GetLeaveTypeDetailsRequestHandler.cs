using AutoMapper;
using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests;
using HRLeaveManagement.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailsRequestHandler : IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailsRequestHandler(
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
            )
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
