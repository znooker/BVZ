using BVZ.BVZ.Domain.Models.Zoo.Guides;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface IAnimalCompetencesRepository
    {
        Task<bool> AddCompetences(List<AnimalCompetence> competences);

        Task<bool> DeleteCompetences(List<AnimalCompetence> competences);
        //Task DeleteCompetences(List<AnimalCompetence> competences);

        Task<List<AnimalCompetence>> GetCompetencesByGuideId(Guid GuideId);
    }
}
