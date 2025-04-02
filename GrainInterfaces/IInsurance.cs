namespace GrainInterfaces;

public interface IInsurance : IGrainWithIntegerKey
{
    ValueTask<string> ScanIdToVerify(string chassisId);
}