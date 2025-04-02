using GrainInterfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Grains;

public class TripsGrain : Grain, ITrips
{
    private readonly ILogger _logger;

    public TripsGrain(ILogger<TripsGrain> logger) => _logger = logger;

    async ValueTask<string> ITrips.ArrivedAtPort(string message)
    {
        _logger.LogInformation("""
            "{message}" | Saving arrival event to database
            """,
            message);

        _logger.LogInformation("Scanning insurance data");
        var insuranceGrain = GrainFactory.GetGrain<IInsurance>(this.GetPrimaryKeyLong());
        string verificationResult = await insuranceGrain.ScanIdToVerify(message[..8]);

        return $"""
            Arrival event UUID is 6930-V30D-4FL8-K8J3. Insurance verification result: {verificationResult}
            """;
    }

    ValueTask<string> ITrips.LoadedOntoTrain(string message)
    {
        _logger.LogInformation("""
            "{message}" saving to train events database
            """,
            message);

        return ValueTask.FromResult($"""
            Train event UUID is 30A0-A30D-3KL8-JLI3.
            """);
    }
}