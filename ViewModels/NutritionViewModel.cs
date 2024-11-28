using Exam.Models;

namespace Exam.ViewModels
{
    public class NutritionViewModel
    {
        public NutritionViewModel(IEnumerable<NutritionEntry> entries, NutritionEntry newEntry)
        {
            Entries = entries;
            NewEntry = newEntry;
        }

        public required IEnumerable<NutritionEntry> Entries { get; set; }
        public required NutritionEntry NewEntry { get; set; }
    }
}
