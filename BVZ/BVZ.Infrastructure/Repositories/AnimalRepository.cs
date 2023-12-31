﻿using BVZ.BVZ.Application.Interfaces;

using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BVZ.BVZ.Infrastructure.Repositories
{
    public class AnimalRepository : BaseRepository, IAnimalRepository
    {
        
        private readonly ZooDbContext _context;
        public AnimalRepository(ZooDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<bool> AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            return await Save();
        }

        public async Task<bool> DeleteAnimal(Animal animal)
        {
            _context.Animals.Update(animal);
            return await Save();
        }

        public Task<bool> DeleteAnimalById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Animal>> GetAllAnimals()
        {
            var result = await _context.Animals.Where(a => a.IsArchived == false || a.IsArchived == null).ToListAsync();
           
            return result;
        }

        public async Task<Animal> GetAnimalById(Guid id)
        {
            return await _context.Animals.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> UpdateAnimal(Animal animal)
        {
            _context.Animals.Update(animal);
            return await Save();
        }

        public async Task<List<Guid>> GetAnimalsByGuideId(Guid id)
        {
            var animalIds = await _context.AnimalCompetences
                            .Where(ac => ac.GuideId == id)
                            .Select(ac => ac.AnimalId)
                            .ToListAsync();
            return animalIds;
        }

        public async Task<int> GetAnimalVisitsByDateAndAnimal(Guid id, DateTime dateOfVisit)
        {
            int NrOfVisit = await _context.AnimalVisits
                                    .Where(av => av.VisitDate == dateOfVisit.Date
                                    && av.AnimalId == id)
                                    .CountAsync();
            return NrOfVisit;
        }
        public async Task<bool> AddAnimalVisit(AnimalVisit animalVisit)
        {
            _context.AnimalVisits.Add(animalVisit);
            return await Task.FromResult(_context.SaveChanges() > 0);
        }

        public async Task<List<string>> GetAllAnimalTypes()
        {
            return await _context.Animals.Select(a => a.AnimalType).Distinct().ToListAsync();
        }

        public async Task<List<Animal>> GetUniqeAnimalListByAnimalType(List<string> types)
        {
            var uniqueAnimals = await _context.Animals
                .Where(animal => types.Contains(animal.AnimalType))
                .GroupBy(animal => animal.AnimalType)
                .Select(group => group.First())
                .ToListAsync();

            return uniqueAnimals;
        }

        public async Task<List<Animal>> GetListOfAnimalByAnimalIDs(List<Guid> animalIDs)
        {
            var listOfAnimals = await _context.Animals.Where(animal => animalIDs.Contains(animal.Id)).ToListAsync();
            return listOfAnimals;
        }
    }
}
