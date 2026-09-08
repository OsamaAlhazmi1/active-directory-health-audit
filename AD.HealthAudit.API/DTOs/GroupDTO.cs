using Microsoft.VisualBasic;

namespace AD.HealthAudit.API.DTOs;

public record GroupDTO
(
    int Id, 
    string Groupname,
    int Users, 
    int [] Computers

);


    


