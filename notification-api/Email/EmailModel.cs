using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notification_api.Email;

public class EmailModel
{
    [Key] public int? Id { get; init; }

    [MaxLength(255)] public string? UserId { get; init; }

    [MaxLength(255)] public string? From { get; init; }

    [MaxLength(255)] public string? To { get; init; }

    [MaxLength(255)] public string? Subject { get; init; }


    public DateTime? SentAt { get; init; } = DateTime.UtcNow;

    [Column(TypeName = "TEXT")]
    public string? Body { get; init; }
}