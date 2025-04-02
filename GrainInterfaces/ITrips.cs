namespace GrainInterfaces;

public interface ITrips : IGrainWithIntegerKey
{
    ValueTask<string> ArrivedAtPort(string message);
    ValueTask<string> LoadedOntoTrain(string message);
}