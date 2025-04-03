using System.ComponentModel.DataAnnotations;

namespace Data.Enitties;

public class MemberEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
