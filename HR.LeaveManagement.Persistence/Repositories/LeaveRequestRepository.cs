using HRLeaveManagement.Application.Persistance.Contracts;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveManagementDbContext _db;
        public LeaveRequestRepository(HRLeaveManagementDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _db.Entry(leaveRequest).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _db.LeaveRequests.Include(q => q.LeaveType)
                                  .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }   

        public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _db.LeaveRequests.Include(q => q.LeaveType)
                                  .ToListAsync();
            return leaveRequests;
        }
    }
}
