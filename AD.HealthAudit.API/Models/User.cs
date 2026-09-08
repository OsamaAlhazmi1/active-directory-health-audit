namespace AD.HealthAudit.API.Models;

public class User
{

    public enum UserAccountStatus
    {
        Enabled, 
        Disabled
    }

    public enum UserPasswordStatus
    {
        Active,
        Expired

    }

    public int Id {get ; set;}

    public string Name {get;set;} = ""; 

    public UserAccountStatus AccountStatus {get; set;} 

    public UserPasswordStatus PasswordStatus {get; set;}


    
    
}
