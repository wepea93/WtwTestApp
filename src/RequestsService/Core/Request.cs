using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestsService.Core;

public class Request : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Employee name is required.")]
    [StringLength(100, ErrorMessage = "Employee name cannot exceed 100 characters.")]
    public string EmployeeName { get; set; }

    [Required(ErrorMessage = "Employee ID is required.")]
    [StringLength(20, ErrorMessage = "Employee ID cannot exceed 20 characters.")]
    public string EmployeeId { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be after start date.")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Request type is required.")]
    public RequestType TypeOfRequest { get; set; }

    [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
    public string Reason { get; set; }

    [Required]
    public RequestStatus Status { get; set; }

    [Required]
    public DateTime RequestDate { get; set; } = DateTime.Now;
}

public enum RequestType
{
    Vacation,
    Sick,
    Personal,
    Maternity,
    Paternity,
    Bereavement,
    Unpaid
}

public enum RequestStatus
{
    Pending,
    Approved,
    Rejected,
    Cancelled
}
