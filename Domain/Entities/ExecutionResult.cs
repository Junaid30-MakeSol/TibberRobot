using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TibberRobot.Domain.Common;

namespace TibberRobot.Domain.Models;

public class ExecutionResult : BaseAuditableEntity
{
    [Required]
    [property: JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }

    [Required]
    [property: JsonPropertyName("commands")]
    public int Commands { get; set; }

    [Required]
    [property: JsonPropertyName("result")]
    public int Result { get; set; }

    [Required]
    [property: JsonPropertyName("duration")]
    public double Duration { get; set; }
}