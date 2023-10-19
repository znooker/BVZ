using BVZ.BVZ.Infrastructure.Data;

namespace BVZ.BVZ.Application.Services
{
    public class GuideServices
    {
        private readonly ZooDbContext _context;

        public GuideServices(ZooDbContext context)
        {
            _context = context;
        }

    }
}
