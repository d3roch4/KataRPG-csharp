using KataRPG.Domain;

namespace KataRPG.WebApp.Services
{
    public class FactionsService
    {
        private List<Faction> Factions {get; set;} = new List<Faction>();

        public FactionsService()
        {
            Factions.Add(new Faction(Name: "Alpha", Id: Guid.NewGuid()));
            Factions.Add(new Faction(Name: "Beta", Id: Guid.NewGuid()));
            Factions.Add(new Faction(Name: "Omega", Id: Guid.NewGuid()));
        }

        public List<Faction> List(){
            return Factions;
        }

        public void Del(Faction faction)
        {
            Factions.Remove(faction);
        }
        public void Add(string name)
        {
            Factions.Add(new Faction(name, Guid.NewGuid()));
        }
    }
}