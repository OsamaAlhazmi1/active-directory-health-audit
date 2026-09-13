namespace AD.HealthAudit.API.DTOs;

public record DashboardDomainDTO
(
    int NumberOfDCs , 
    int NumberOfAvailableDCs,
    int NumberOfUnavailableDCs
);


    


