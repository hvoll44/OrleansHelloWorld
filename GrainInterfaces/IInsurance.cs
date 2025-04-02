namespace GrainInterfaces;

public interface IInsurance : IGrainWithIntegerKey
{
    ValueTask<string> VerificationSuccess(string message);
    ValueTask<string> VerificationFailed(string message);
}