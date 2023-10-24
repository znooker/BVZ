using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.BVZ.Domain.Models.Zoo;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Animals.Species.Land;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel;
using System.Reflection;
using System.Security.Permissions;

namespace BVZ.BVZ.Application.Services
{
    public class AnimalServices
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalServices(IAnimalRepository animalRepository)
        {
            _animalRepository=animalRepository;
        }

        public async Task<ServiceResponse<List<string>>> GetAllAnimalTypes()
        {
            ServiceResponse<List<string>> response = new ServiceResponse<List<string>>();
            var animalTypes = await _animalRepository.GetAllAnimalTypes();
            if(animalTypes == null || !animalTypes.Any())
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


        public async Task<ServiceResponse<Animal>> GetAnimalByIdTest(Guid id)
        {
            ServiceResponse<Animal> response = new ServiceResponse<Animal>();
            var animal = await _animalRepository.GetAnimalById(id);

            //if (animal != null)
            //{
            //    var animalType = animal.GetType();
            //    var idProperty = animalType.GetProperty("Id");
            //    var landProperty = animalType.GetProperty("Speed");
            //    var airProperty = animalType.GetProperty("MaxAltitude");
                
            //    var airLandMethod = animalType.GetProperty("Move");
            //    var habitatMethod = animalType.GetProperty("MakeSound");


            //    var ozelotMethod = animalType.GetMethod("Ozelotmetod");
            //}
            //else
            //{
            //    response.IsSuccess = false;
            //    response.ErrorMessage = $"Animal with id:{id} was not found.";
            //    return response;
            //}

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


    }
}
