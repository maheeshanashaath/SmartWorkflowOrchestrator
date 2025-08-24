using Microsoft.EntityFrameworkCore;
using Orchestrator.API.Controllers;
using Orchestrator.Data;
using Orchestrator.Data.Models;
using Xunit;

namespace Orchestrator.Tests
{
    public class WorkflowControllerTests
    {
        private OrchestratorDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<OrchestratorDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new OrchestratorDbContext(options);
        }

        [Fact]
        public async Task CreateWorkflow_ShouldAddWorkflow()
        {
            // Arrange
            var context = GetDbContext();
            var controller = new WorkflowController(context);

            var workflow = new Workflow { Name = "Test Workflow" };

            // Act
            var result = await controller.CreateWorkflow(workflow);
            var workflows = context.Workflows.ToList();

            // Assert
            Assert.Single(workflows);
            Assert.Equal("Test Workflow", workflows[0].Name);
        }
    }
}
