using System.Text.Json.Serialization;

namespace TibberRobot.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    [property: JsonPropertyName("created")]
    public DateTimeOffset Created { get; set; }

    [property: JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [property: JsonPropertyName("lastModified")]
    public DateTimeOffset LastModified { get; set; }

    [property: JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }
}
