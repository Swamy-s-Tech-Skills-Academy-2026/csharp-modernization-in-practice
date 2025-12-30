using Modern.Domain.Models;

namespace Modern.Domain.Policies;

/// <summary>
/// Execution policy using C# 14 switch expressions.
/// Centralized policy logic as a declarative decision table.
/// </summary>
public static class ExecutionPolicy
{
    public static TimeSpan GetTimeout(OperationCommand command) =>
        command.CommandName switch
        {
            "RunReport" => TimeSpan.FromSeconds(30),
            "RunSync" => TimeSpan.FromMinutes(2),
            _ => TimeSpan.FromSeconds(10)
        };
}

