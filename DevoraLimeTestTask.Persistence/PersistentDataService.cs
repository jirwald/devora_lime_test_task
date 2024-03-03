using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Persistence
{
    public class PersistentDataService : IPersistentDataService
    {
        private readonly Dictionary<string, int> _dataStore = new Dictionary<string, int>();
        private readonly Dictionary<Guid, List<Fighter>> arenas = new Dictionary<Guid, List<Fighter>>();

        public void CreateArena(Guid arenaId, List<Fighter> fighters)
        {
            arenas.Add(arenaId, fighters);
        }

        public List<Fighter> GetFightersByArena(Guid id)
        {
            if (arenas.TryGetValue(id, out List<Fighter>? data))
            {
                return data;
            }

            throw new IndexOutOfRangeException();
        }

        public int ArenaCount {  get { return arenas.Count; } }

    }
}
