using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TibberRobot.Domain.Models;

public record RobotRequest
(
  [Required(ErrorMessage = "Start position must be provided.")]
  [property: JsonPropertyName("start")]
  Coordinates Start,

  [Required(ErrorMessage = "Commands list must not be empty.")]
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

