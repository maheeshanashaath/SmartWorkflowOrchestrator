using Xunit;

public class WorkflowTests
{
    [Fact]
    public void Workflow_Should_Default_To_Pending()
    {
        var wf = new Orchestrator.Data.Models.Workflow();
        Assert.Equal("Pending", wf.Status);
    }
}
