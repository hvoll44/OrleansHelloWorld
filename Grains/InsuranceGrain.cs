using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains;

public class InsuranceGrain : Grain, IInsurance
{
    private readonly ILogger _logger;

    public InsuranceGrain(ILogger<TripsGrain> logger) => _logger = logger;

    public ValueTask<string> VerificationFailed(string message)
    {
        _logger.LogInformation("""
            "{message}" saving to failure to database
            """,
            message);

        return ValueTask.FromResult($"""

            Insurance scan FAILURE.
            """);
    }

    public ValueTask<string> VerificationSuccess(string message)
    {
        _logger.LogInformation("""
            "{message}" saving to insurance database
            """,
            message);

        return ValueTask.FromResult($"""

            Insurance scan SUCCESS.
            """);
    }
}
