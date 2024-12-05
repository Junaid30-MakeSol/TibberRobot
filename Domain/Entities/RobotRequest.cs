using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TibberRobot.Domain.Models;

public record RobotRequest
(
  [Required]
  [property: JsonPropertyName("start")]
  Coordinates Start,

  [Required]
  [property: JsonPropertyName("commands")]
  List<Command> Commands
);

public record Coordinates
(
  [Required]
  [property: JsonPropertyName("x")]
  int X,

  [Required]
  [property: JsonPropertyName("y")]
  int Y
);

public record Command
(
  [Required]
  [property: JsonPropertyName("direction")]
  string Direction,

  [Required]
  [property: JsonPropertyName("steps")]
  int Steps
);

