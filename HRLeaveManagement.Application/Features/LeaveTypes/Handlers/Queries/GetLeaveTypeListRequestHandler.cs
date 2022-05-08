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
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, IReadOnlyList<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
            )
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

       

        public async Task<IReadOnlyList<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<IReadOnlyList<LeaveTypeDto>>(leaveTypes);
        }
    }
}
