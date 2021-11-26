using KataRPG.Domain;

namespace KataRPG.WebApp.Services
{
    public class ThingsService
    {
        private List<Thing> Things {get; set;} = new List<Thing>();

        public ThingsService()
        {
            Things.Add(new Thing(){
                Name = "tree",
                Health = 2000,
            });
            Things.Add(new Thing(){
                Name = "rock 1",
                Health = 2345,
            });
            Things.Add(new Thing(){
                Name = "car 2",
                Health = 5,
            });
        }

        public Thing? Find(string id) => Things.Find(x => x.Id == Guid.Parse(id));

        public List<Thing> List(){
            return Things;
        }

        public void Del(Thing faction)
        {
            Things.Remove(faction);
        }
        public void Add(string name)
        {
            Things.Add(new Thing(){
                Name = name
            });
        }
    }
}