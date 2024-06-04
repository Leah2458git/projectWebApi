using Entities;

namespace Repositories
{
    public interface IRaitingRepository
    {
        Task addActionToDB(Rating raiting);
    }
}