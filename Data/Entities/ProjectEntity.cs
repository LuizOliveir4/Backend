﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Enitties;

public class ProjectEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "Date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "Date")]
    public DateTime EndDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Budget { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

    [ForeignKey(nameof(Client))]
    public string ClientId { get; set; } = null!;
    public ClientEntity Client { get; set; } = null!;

    [ForeignKey(nameof(Status))]
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public MemberEntity User { get; set; } = null!;
}
