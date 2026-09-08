namespace AD.HealthAudit.API.Models;

public class Domian
{

    public enum DomainLDAPStatus
    {
        Available, 
        Unavailable 

    }

    public int Id { get; set; }

    public string Name { get; set; } = "";

    public DomainLDAPStatus Status{get; set;} 
    

}
