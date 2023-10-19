using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Air;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Domain.Models.Zoo.Animals.ValueTypes;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Data;
using BVZ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;

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
