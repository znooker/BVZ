using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

                //In med ILogger
            } 

            response.IsSuccess = true;
            response.Data = animals.ToList();
            return response;

        }

        public async Task<ServiceResponse<Animal>> GetAnimalById(Guid id)
        {
            ServiceResponse<Animal> response = new ServiceResponse<Animal>();
            var animal = await _animalRepository.GetAnimalById(id);

            if(animal.GetType() == typeof(Ozelot)) 
            {
                var test = (Ozelot)animal;
                var ozId = test.Id;
                var speed = test.Speed;
                string ozTest = test.Ozelotmetod();
            }
            
            if(animal == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = $"Animal with id:{id} was not found.";
                return response;
            }

            response.IsSuccess = true;
            response.Data = animal;
            return response;
        }



    }
}
