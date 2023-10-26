using BVZ.BVZ.Domain.Models.Zoo.Guides;

namespace BVZ.BVZ.Application.Interfaces
{
    public interface IAnimalCompetencesRepository
    {
        Task<bool> AddCompetences(List<AnimalCompetence> competences);
    }
}
