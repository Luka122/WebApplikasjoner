using Exam.Models;

namespace Exam.DAL
{
    public interface INutritionRepository
    {
        Task<IEnumerable<NutritionEntry>> GetAll();
        Task<NutritionEntry?> GetById(int id);
        Task Create(NutritionEntry entry);
        Task Update(NutritionEntry entry);
        Task<bool> Delete(int id);
    }
}
