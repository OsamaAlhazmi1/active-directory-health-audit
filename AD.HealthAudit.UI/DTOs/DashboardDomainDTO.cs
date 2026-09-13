namespace AD.HealthAudit.UI.DTOs;

public record DashboardMainDTO
(
    int NumberOfUsers,
    int EnabledUsers,
    int DisabledUsers,
    int ExpiredPasswords,
    int NumberOfComputers,
    int EnabledComputers,
    int DisabledComputers,
    int NumberOfGroups
);


    


