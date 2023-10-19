using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BVZ.BVZ.Application.Services
{
    public class AnimalServices
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalServices(IAnimalRepository animalRepository)
        {
            _animalRepository=animalRepository;
        }


        public async Task<ServiceResponse<List<Animal>>> GetAllAnimals()
        {
            ServiceResponse<List<Animal>> response = new ServiceResponse<List<Animal>>();

            var animals = await _animalRepository.GetAllAnimals();
            if(animals == null || !animals.Any())
            {
                response.IsSuccess = false;
                response.ErrorMessage = "List of animals is null or empty.";
                return response;
            } 

            response.IsSuccess = true;
            response.Data = animals.ToList();
            return response;

        }



    }
}
