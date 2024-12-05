using System.Text.Json.Serialization;

namespace TibberRobot.Domain.Common;

public abstract class BaseEntity
{

    [property: JsonPropertyName("id")]
    public int Id { get; set; }

}