using Microsoft.VisualBasic;

namespace AD.HealthAudit.API.DTOs;

public record GroupDTO
(
    int Id, 
    string Groupname,
    string [] Users, 
    string [] Computers

);


    


