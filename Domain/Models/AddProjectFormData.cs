namespace Domain.Models;
//Här skulle man kunna använda sig av dataannotations för att validera datan som skickas in
public class AddProjectFormData
{
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public string ClientId { get; set; } = null!;
    public int StatusId { get; set; }
    public string UserId { get; set; } = null!;
}
