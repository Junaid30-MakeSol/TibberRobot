using Moq;
using TibberRobot.Application.Services;
using TibberRobot.Domain.Models;
using TibberRobot.Infrastructure.Interfaces;

namespace UnitTests;

[TestClass]
public class RobotServiceTests
{
    private readonly Mock<ITiberRobotRepository> _mockRepository;
    private readonly TibberRobotService _robotService;

    public RobotServiceTests()
    {
        _mockRepository = new Mock<ITiberRobotRepository>();
        _robotService = new TibberRobotService(_mockRepository.Object);
    }

    [TestMethod]
    public async Task CalculatePathAsync_WithValidCommands_ReturnsCorrectResult()
    {
        // Arrange
        var request = new RobotRequest(
               new Coordinates(10, 20),
               new List<Command>
               {
                    new Command("north", 1),
                    new Command("east", 2)
               }
           );

        // Act
        var result = await _robotService.CalculatePathAsync(request);

        // Assert
        Assert.AreEqual(4, result.Result);
        Assert.AreEqual(2, result.Commands);

        _mockRepository.Verify(repo => repo.Create(It.IsAny<ExecutionResult>()), Times.Once);
    }

    [TestMethod]
    public async Task CalculatePathAsync_WithNoCommands_ReturnsStartPointOnly()
    {
        // Arrange
        var request = new RobotRequest(
               new Coordinates(0, 0),
               new List<Command>()
           );

        // Act
        var result = await _robotService.CalculatePathAsync(request);

        // Assert
        Assert.AreEqual(1, result.Result); // Only start point is visited
        Assert.AreEqual(0, result.Commands); // No commands processed

        _mockRepository.Verify(repo => repo.Create(It.IsAny<ExecutionResult>()), Times.Once);
    }

    [TestMethod]
    public async Task CalculatePathAsync_WithInvalidDirection_DoesNotChangePath()
    {
        // Arrange
        var request = new RobotRequest(
               new Coordinates(0, 0),
               new List<Command>
               {
                    new Command("invalid", 5),
               }
           );
        // Act
        var result = await _robotService.CalculatePathAsync(request);

        // Assert
        Assert.AreEqual(1, result.Result); // Only start point is visited
        Assert.AreEqual(1, result.Commands); // 1 command processed

        _mockRepository.Verify(repo => repo.Create(It.IsAny<ExecutionResult>()), Times.Once);
    }
}