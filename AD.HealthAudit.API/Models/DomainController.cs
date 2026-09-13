namespace AD.HealthAudit.API.Models;

public class DomainController
{


    public enum DC_ConnectivityStatus
    {
        Available,
        Unavailable

    }

    public int Id { get; set; }

    public string Name { get; set; } = "";

    public int DomainID { get; set; }

    public Domain Domain { get; set; } = null!;

    public DC_ConnectivityStatus ConnectivityStatus { get; set; }

}
