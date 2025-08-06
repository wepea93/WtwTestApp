using Microsoft.EntityFrameworkCore;
using RequestsService.Core;

namespace RequestsService.Infrastructure;

public class RequestDbContext : DbContext
{
    public RequestDbContext(DbContextOptions<RequestDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestsService.Core.Request>().HasData(
            new RequestsService.Core.Request {
                Id = -1,
                EmployeeName = "Alice Johnson",
                EmployeeId = "EMP001",
                StartDate = new DateTime(2025, 8, 12),
                EndDate = new DateTime(2025, 8, 16),
                TypeOfRequest = RequestType.Vacation,
                Reason = "Family vacation to the coast",
                Status = RequestStatus.Pending,
                RequestDate = new DateTime(2025, 8, 1) // evita usar DateTime.Now en seeding
            },
            new RequestsService.Core.Request {
                Id = -2,
                EmployeeName = "Michael Smith",
                EmployeeId = "EMP002",
                StartDate = new DateTime(2025, 8, 20),
                EndDate = new DateTime(2025, 8, 22),
                TypeOfRequest = RequestType.Sick,
                Reason = "Flu symptoms and medical rest",
                Status = RequestStatus.Approved,
                RequestDate = new DateTime(2025, 8, 2)
            },
            new RequestsService.Core.Request {
                Id = -3,
                EmployeeName = "Sofia Martinez",
                EmployeeId = "EMP003",
                StartDate = new DateTime(2025, 9, 1),
                EndDate = new DateTime(2025, 9, 3),
                TypeOfRequest = RequestType.Personal,
                Reason = "Personal errands and family matters",
                Status = RequestStatus.Pending,
                RequestDate = new DateTime(2025, 8, 3)
            }
        );
    }
}
