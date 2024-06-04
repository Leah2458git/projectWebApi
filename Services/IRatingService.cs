using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task addActionToDB(Rating raiting);
    }
}