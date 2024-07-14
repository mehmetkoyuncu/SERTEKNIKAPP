

namespace SERTEKNIKAPP.DATA.Utilities.Results
{
    //For voids
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
