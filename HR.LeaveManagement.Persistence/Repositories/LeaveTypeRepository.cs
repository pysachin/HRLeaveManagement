using HRLeaveManagement.Application.Persistance.Contracts;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType> , ILeaveTypeRepository
    {
        private readonly HRLeaveManagementDbContext _db;
        public LeaveTypeRepository(HRLeaveManagementDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
