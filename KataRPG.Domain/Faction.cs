namespace KataRPG.Domain
{
    public class Faction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Faction(){}
        public Faction(string Name, Guid Id)
        {
            this.Name = Name;
            this.Id = Id;
        }

        public static bool operator == (Faction x, Faction y)
        {
            return x.Id == y.Id;
        }
        public static bool operator != (Faction x, Faction y)
        {
            return !(x.Id == y.Id);
        }

        public override bool Equals(Object obj)
        {
            return obj is Faction && this == (Faction)obj;
        }
    }
}