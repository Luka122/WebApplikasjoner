using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.DAL
{
    public class NutritionRepository : INutritionRepository
    {
        private readonly NutritionEntryDbContext? _db;
        private readonly ILogger<NutritionRepository> _logger;

        public NutritionRepository(NutritionEntryDbContext? db, ILogger<NutritionRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IEnumerable<NutritionEntry>?> GetAll()
        {
            try
            {
                return await _db!.Entries.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("[NutritionRepository] Entries.ToListAsync() failed when GetAll(), error message: {e}", e.Message);
                return null;
            }
        }

        public async Task<NutritionEntry?> GetById(int id)
        {
            try
            {
                return await _db!.Entries.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError("[NutritionRepository] Entries.FindAsync() failed when GetById() for NutritionId {id}, error message: {e}", id, e.Message);
                return null;
            }
        }

        public async Task<bool> Create(NutritionEntry entry)
        {
            try
            {
                _db!.Entries.Add(entry);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[NutritionRepository] Failed to create entry {@entry}, error message: {e}", entry, e.Message);
                return false;
            }
        }

        public async Task<bool> Update(NutritionEntry entry)
        {
            try
            {
                _db!.Entries.Update(entry);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e) 
            {
                _logger.LogError("[NutritionRepository] Failed to create entry {@entry}, error message: {e}", entry, e.Message);
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entry = await _db!.Entries.FindAsync(id);

                if (entry == null)
                {
                    _logger.LogError("[NutritionRepository] Entry not found in Delete() for NutritionId: {id}", id);
                    return false;
                }

                _db.Entries.Remove(entry);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[NutritionRepository] Delete failed for NutritionId {id}, error message: {e}", id, e.Message);
                return false;
            }
        }
    }
}
