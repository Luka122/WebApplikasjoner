using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.DAL
{
    public class NutritionRepository : INutritionRepository
    {
        private readonly NutritionEntryDbContext? _db;

        public NutritionRepository(NutritionEntryDbContext? db)
        {
            _db = db;
        }

        public async Task<IEnumerable<NutritionEntry>> GetAll()
        {
            return await _db.Entries.ToListAsync();
        }

        public async Task<NutritionEntry?> GetById(int id)
        {
            return await _db.Entries.FindAsync(id);
        }

        public async Task Create(NutritionEntry entry)
        {
            _db.Entries.Add(entry);
            await _db.SaveChangesAsync();
        }

        public async Task Update(NutritionEntry entry)
        {
            _db.Entries.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entry = await _db.Entries.FindAsync(id);

            if (entry == null) return false;

            _db.Entries.Remove(entry);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
