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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {

        private readonly HRLeaveManagementDbContext _db;
        public LeaveAllocationRepository(HRLeaveManagementDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _db.LeaveAllocations
                                   .Include(q => q.LeaveType)
                                   .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;

        }

        public async Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _db.LeaveAllocations
                                  .Include(q => q.LeaveType).ToListAsync();

            return leaveAllocations;
        }
    }
}
