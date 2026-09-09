namespace AD.HealthAudit.API.DTOs;

public record DashboardMainDTO
(
    int NumberOfUsers,
    int NumberEnabledUsers,
    int NumberDisabledUsers,
    int ExpiredPasswords,
    int NumberOfComputers,
    int NumberEnabledComputers,
    int NumberDisabledComputers,
    int NumberOfGroups
);


    


