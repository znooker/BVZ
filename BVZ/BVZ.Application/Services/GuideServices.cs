using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Domain.Models.Zoo.Animals;
using BVZ.BVZ.Domain.Models.Zoo.Guides;
using BVZ.BVZ.Infrastructure.Data;
using BVZ.BVZ.Infrastructure.Repositories;
using BVZ.Models.Admin.Guide;
using Microsoft.IdentityModel.Tokens;

namespace BVZ.BVZ.Application.Services
{
    public class GuideServices
    {
        private readonly ILogger<GuideServices> _logger;
        private readonly IGuideRepository _guideRepository;
        private readonly ITransaction _baseRepository;
        private readonly IAnimalCompetencesRepository _animalCompetencesRepository;
        private readonly IAnimalRepository _animalRepository;

        public GuideServices(
            ILogger<GuideServices> logger,
            IGuideRepository guideRepository,
            ITransaction baseRepository,
            IAnimalCompetencesRepository animalCompetencesRepository,
            IAnimalRepository animalRepository)
        {
            _logger = logger;
            _guideRepository = guideRepository;
            _baseRepository = baseRepository;
            _animalCompetencesRepository = animalCompetencesRepository;
            _animalRepository = animalRepository;
        }

        public async Task<ServiceResponse<List<Guide>>> GetAllGuides()
        {
            ServiceResponse<List<Guide>> response = new ServiceResponse<List<Guide>>();
            var list = await _guideRepository.GetAllGuides();
            if(list == null || list.Count == 0)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Kan inte hitta några guider";
                return response;
            }

            response.IsSuccess = true;
            response.Data=list;
            return response;

        }

        public async Task<ServiceResponse<Guide>> GetGuideById(Guid id)
        {
            ServiceResponse<Guide> response = new ServiceResponse<Guide>();
            var guide = await _guideRepository.GetGuideById(id);
            if (guide == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Kan inte hitta guide med det angivna id't";
                return response;
            }

            response.IsSuccess = true;
            response.Data = guide;
            return response;
        }

        public async Task<ServiceResponse<string>> SoftDeleteGuide(Guid guideId)
        {
            ServiceResponse<string> result = new ServiceResponse<string>();

            var guide = await _guideRepository.GetGuideById(guideId);
            if (guide == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Hittade ingen guide att ta bort.";
                return result;
            }
            guide.IsArchived = true;

            if (!await _guideRepository.SoftDeleteGuide(guide))
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Gick inte att ta bort den valda guiden. Kontakta admin.";
                return result;
            }
            result.IsSuccess = true;
            result.Data = $"{guide.Name} är avskedad.";
            return result;
        }


        
        public async Task<ServiceResponse<string>> CreateGuide(GuideViewModel data)
        {
            ServiceResponse<string> result = new ServiceResponse<string>();
            var transaction = _baseRepository.BeginTransaction();

            try
            {
                //Create new Guide, add to DB
                Guide newGuide = new Guide(data.GuideName);
               
                if (!await _guideRepository.AddGuide(newGuide))
                {
                    await transaction.RollbackAsync();
                    result.IsSuccess = false;
                    result.ErrorMessage = "En ny guide kunde inte läggas till. Kontakta admin";
                    return result;
                }

                //Get List of animals to link with the guide from DB
                var animals = await _animalRepository.GetListOfAnimalByAnimalIDs(data.AnimalIDs);
                if (animals.IsNullOrEmpty())
                {
                    await transaction.RollbackAsync();
                    result.IsSuccess = false;
                    result.ErrorMessage = "Kunde inte hitta ett eller flera djur från listan.";
                    return result;
                }

                //Create a list to of competences
                List<AnimalCompetence> competences = new List<AnimalCompetence>();
                foreach (var animal in animals)
                {
                    AnimalCompetence animalCompetence = new AnimalCompetence(animal, newGuide);
                    competences.Add(animalCompetence);
                }


                //Add the competences to the DB

                if (!await _animalCompetencesRepository.AddCompetences(competences))
                {
                    await transaction.RollbackAsync();
                    result.IsSuccess = false;
                    result.ErrorMessage = "Kunde inte lägga till kompetenserna. Kontakta admin";
                    return result;
                }

                //Happy Path yay!!
                await transaction.CommitAsync();
                result.IsSuccess = true;
                result.UserInfo = $"En ny guide med namn {newGuide.Name} har anställts.";
                return result;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync();
                }
                result.IsSuccess = false;
                result.ErrorMessage = "An error occurred. Please try again later.";
                _logger.LogInformation(ex.Message);
                return result;
            }
            

        }

        public async Task<ServiceResponse<Guide>> UpdateGuide(GuideViewModel guide)
        {
            ServiceResponse<Guide> result = new ServiceResponse<Guide>();
            var foundGuide = await _guideRepository.GetGuideById(guide.GuideID);
            if(foundGuide == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Guide med valt id kunde inte hittas";
                return result;
            }

            foundGuide.Name = guide.GuideName;
            if(!await _guideRepository.UpdateGuide(foundGuide))
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Guide kunde inte uppdateras. Kontakta admin.";
                return result;
            }

            result.IsSuccess = true;
            result.UserInfo = $"{foundGuide} har uppdaterats med ny information.";
            result.Data = foundGuide;
            return result;
        }
        
        //REFACTOR TO A TRANSACTION
        public async Task<ServiceResponse<string>> UpdateGuideCompetence(Guide guide, List<Animal> animals)
        {
            ServiceResponse<string> result = new ServiceResponse<string>();

            List<AnimalCompetence> competences = new List<AnimalCompetence>();
            foreach (var animal in animals)
            {
                AnimalCompetence animalCompetence = new AnimalCompetence(animal, guide);
                competences.Add(animalCompetence);
            }

            var oldAnimalCompetences = guide.AnimalCompetences.Select(x => x.Animal).ToList();
            if (oldAnimalCompetences.Any())
            {

                List<AnimalCompetence> oldCompetences = new List<AnimalCompetence>();
                foreach (var animal in oldAnimalCompetences)
                {
                    AnimalCompetence animalCompetence_1 = new AnimalCompetence(animal, guide);
                    oldCompetences.Add(animalCompetence_1);
                }
               

                //Fick inte detta att funka så som vi hade det uppsatt...
                await _animalCompetencesRepository.DeleteCompetences(oldCompetences);
                
                //if (!) 
                //{
                //    result.IsSuccess = false;
                //    result.ErrorMessage = "Kunde inte radera guidens kompetenser. Kontakta admin";
                //    return result;
                //}
            }

            if (!await _animalCompetencesRepository.AddCompetences(competences))
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Kunde inte uppdatera guidens kompetenser. Kontakta admin";
                return result;
            }

            result.IsSuccess = true;
            result.UserInfo = $"{guide.Name} har uppdaterat sina kompetenser.";
            return result;
        }
    }
}
