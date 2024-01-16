

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IDateTimeService
{
    public TimeOnly ConvertToTimeOnly(string timeString);
}
