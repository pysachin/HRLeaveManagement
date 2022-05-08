using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest,bool? approvalStatus);        
    }
}
