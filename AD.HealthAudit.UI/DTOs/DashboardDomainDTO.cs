namespace AD.HealthAudit.UI.DTOs;

public record DashboardDomainDTO(
    int NumberOfDCs,
    int AvailableDCs,
    int UnavailableDCs
);

