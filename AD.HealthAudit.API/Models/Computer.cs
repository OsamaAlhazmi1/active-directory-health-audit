namespace AD.HealthAudit.API.Models;

public class Computer
{
    public enum ComputerStatus
    {
        Enabled,
        Disabled
    }



    public int Id { get; set; }

    public string Name { get; set; } = "";

    public ComputerStatus status { get; set; }



}

