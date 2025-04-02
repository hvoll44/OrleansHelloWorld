using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains;

public class InsuranceGrain : Grain, IInsurance
{
    private readonly ILogger _logger;

    public InsuranceGrain(ILogger<TripsGrain> logger) => _logger = logger;

    public ValueTask<string> ScanIdToVerify(string chassisId)
    {
        _logger.LogInformation("""
            "{message}" saving scan attempt to insurance database
            """,
            chassisId);

        return ValueTask.FromResult($"""
            SUCCESS {chassisId} Insurance Verification code: 48K03-AA.
            """);
    }
}
