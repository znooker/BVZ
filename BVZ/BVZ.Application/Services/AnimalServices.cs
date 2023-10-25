using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using BVZ.BVZ.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel;
using System.Reflection;
using System.Security.Permissions;
using static BVZ.BVZ.Domain.Models.Zoo.Animals.Animal;

namespace BVZ.BVZ.Application.Services
{
    public class AnimalServices
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly AnimalFactory _animalFactory;

        public AnimalServices(IAnimalRepository animalRepository,
            AnimalFactory animalFactory)
        {
            _animalRepository=animalRepository;
            _animalFactory = animalFactory;
        }

        public async Task<ServiceResponse<List<string>>> GetAllAnimalTypes()
        {
            ServiceResponse<List<string>> response = new ServiceResponse<List<string>>();
            var animalTypes = await _animalRepository.GetAllAnimalTypes();
            if (animalTypes == null || !animalTypes.Any())
            {
                response.IsSuccess = false;
                response.ErrorMessage = "List of animaltypes is null or empty";
                return response;
            }
            response.IsSuccess = true;
            response.Data = animalTypes;
            return response;
        }


        public async Task<ServiceResponse<List<Animal>>> GetAllAnimals()
        {
            ServiceResponse<List<Animal>> response = new ServiceResponse<List<Animal>>();

            var animals = await _animalRepository.GetAllAnimals();
            if (animals == null || !animals.Any())
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

            if (animal.GetType() == typeof(Ozelot))
            {
                var test = (Ozelot)animal;
                var ozId = test.Id;
                var speed = test.Speed;
                string ozTest = test.Ozelotmetod();

            }

            if (animal == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = $"Animal with id:{id} was not found.";
                return response;
            }

            response.IsSuccess = true;
            response.Data = animal;
            return response;
        }


        public async Task<ServiceResponse<Animal>> GetAnimalByIdTest(Guid id)
        {
            ServiceResponse<Animal> response = new ServiceResponse<Animal>();
            var animal = await _animalRepository.GetAnimalById(id);
            response.IsSuccess = true;
            response.Data = animal;
            return response;
        }
        public async Task<List<string>> DisplayAnimalPropertiesAndMethods(Animal animal)
        {
            Type animalType = animal.GetType();
            Console.WriteLine($"Animal type: {animalType.Name}");
            List<string> Animalproperties = new List<string>();
            PropertyInfo[] properties = animalType.GetProperties();
            Console.WriteLine("Properties:");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
                Animalproperties.Add(property.Name);
            }

            Console.WriteLine("Methods:");
            MethodInfo[] methods = animalType.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
                Animalproperties.Add(method.Name);
            }
            return Animalproperties;
        }

        public async Task<ServiceResponse<string>> AddAnimal(string animalType, string animalName)
        {
            ServiceResponse<string> sr = new ServiceResponse<string>();

            var animal = _animalFactory.CreateAnimal(animalType);
            if (animalName == null || animal == null)
            {
                sr.IsSuccess = false;
                sr.UserInfo = "Något gick fel, troligen är ett eller flera inmatade värden felaktiga.";
                return sr;
            }
            animal.AnimalName = animalName;

            if (!await _animalRepository.AddAnimal(animal))
            {
                sr.IsSuccess = false;
                sr.UserInfo = "Djuret kunde inte läggas till i databasen.";
                return sr;
            }
            sr.IsSuccess = true;
            sr.Data = animal.AnimalType + ": " + animal.AnimalName + " är tillagt i zoo.";
            return sr;
        }

        public async Task<ServiceResponse<string>> DeleteAnimal(Guid animalId)
        {
            ServiceResponse<string> result = new ServiceResponse<string>();

            var animal = await _animalRepository.GetAnimalById(animalId);
            if (animal == null)
            {
                result.IsSuccess = false;
                result.UserInfo = "Hittade inget djur att ta bort.";
                return result;
            }
            animal.IsArchived= true;

            if (!await _animalRepository.DeleteAnimal(animal))
            {
                result.IsSuccess = false;
                result.UserInfo = "Djuret kunde inte tas bort. Kontakta admin.";
                return result;
            }
            result.IsSuccess = true;
            result.Data = animal.AnimalType + ": " + animal.AnimalName + " är borttaget från zoo.";
            return result;
        }

        public async Task<ServiceResponse<string>> UpdateAnimal(Guid animalId, string newName)
        {
            ServiceResponse<string> result = new ServiceResponse<string>();

            var animal = await _animalRepository.GetAnimalById(animalId);
            if (animal == null || newName == null)
            {
                result.IsSuccess = false;
                result.UserInfo = "Hittade inget djur att uppdatera.";
                return result;
            }

            animal.AnimalName = newName;

            if (!await _animalRepository.UpdateAnimal(animal))
            {
                result.IsSuccess = false;
                result.UserInfo = "Djuret kunde inte uppdateras. Kontakta admin.";
                return result;
            }
            result.IsSuccess = true;
            result.Data = animal.AnimalType + ": " + animal.AnimalName + " är uppdaterat!";
            return result;
        }

        public async Task<ServiceResponse<List<Animal>>> GetUniqueAnimalListByAnimalType()
        {
            ServiceResponse<List<Animal>> result = new ServiceResponse<List<Animal>>();
            
            var animaltypes = await _animalRepository.GetAllAnimalTypes();
            if(animaltypes == null || !animaltypes.Any())
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Inga typer av djur kunde hittas!";
                return result;
            }


            var animalList = await _animalRepository.GetUniqeAnimalListByAnimalType(animaltypes);

            if (animalList == null || !animalList.Any())
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Inga djur kunde hittas!";
                return result;
            }


            result.IsSuccess = true;
            result.Data = animalList;
            return result;
        
        }
    }
}
