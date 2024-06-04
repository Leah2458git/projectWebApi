using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingService : IRatingService
    {
        private IRaitingRepository _raitingRepository;

        public RatingService(IRaitingRepository raitingRepository)
        {
            _raitingRepository = raitingRepository;
        }

        public async Task addActionToDB(Rating raiting)
        {
            await _raitingRepository.addActionToDB(raiting);

        }
    }
}
