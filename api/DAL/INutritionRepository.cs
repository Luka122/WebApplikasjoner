using Exam.Models;

namespace Exam.DAL
{
    public interface INutritionRepository
    {
        Task<IEnumerable<NutritionEntry>?> GetAll();
        Task<NutritionEntry?> GetById(int id);
        Task<bool> Create(NutritionEntry entry);
        Task<bool> Update(NutritionEntry entry);
        Task<bool> Delete(int id);
    }
}
