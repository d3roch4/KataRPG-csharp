using KataRPG.Domain;

namespace KataRPG.WebApp.Services
{
    public class CharactersService
    {
        private List<Character> Characters {get; set;} = new List<Character>();

        public CharactersService()
        {
            Characters.Add(new Character(){
                Name = "Jhony",
                Id = Guid.NewGuid(),
            });
            Characters.Add(new Character(){
                Name = "Bravo",
                Id = Guid.NewGuid(),
                Type = FighterType.Ranged,
                Health = 20
            });
            Characters.Add(new Character(){
                Name = "Samy",
                Id = Guid.NewGuid(),
                Level = 12,
            });
        }

        public Character? Find(string id) => Characters.Find(x => x.Id == Guid.Parse(id));

        public List<Character> List(){
            return Characters;
        }

        public void Del(Character faction)
        {
            Characters.Remove(faction);
        }
        public void Add(string name)
        {
            Characters.Add(new Character(){
                Name = name,
                Id = Guid.NewGuid(),
            });
        }
    }
}