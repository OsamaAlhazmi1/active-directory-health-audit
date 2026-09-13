namespace AD.HealthAudit.API.Models;

public class Domain
{


    public enum DomainLDAPStatus
    {
        Available,
        Unavailable

    }

    public int Id { get; set; }

    public string Name { get; set; } = "";

    public DomainLDAPStatus Status { get; set; }

    public ICollection<DomainController> DomainControllers { get; set; } = [];

}
