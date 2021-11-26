namespace KataRPG.Domain
{
    public class Character : Thing
    {
        public const int HEALTH_SETP = 5;
        public const double HEALTH_MODIFY_SETP = .50;
        public const int LARGE_SETP_NIVEL = 5;
        public const int HEALTH_MAX = 1000;
        public int Level {get; set;}
        public FighterType Type {get; set;}
        public bool Alive => Health>0;
        public List<Faction> Factions { get; set; }

        public Character(int Nivel=1, FighterType Type = FighterType.Melee)
        {
            this.Id = Guid.NewGuid();
            this.Level = Nivel;
            this.Health = HEALTH_MAX;
            this.Type = Type;
            this.Factions = new List<Faction>();
        }

        public void JoinFaction(Faction faction)
        {
            if(Factions.Contains(faction))
                return;
            Factions.Add(faction);
        }

        public void LeaveFaction(Faction faction)
        {
            Factions.Remove(faction);
        }

        public bool Allies(Character other)
        {
            return other.Factions.Any(c => Factions.Contains(c));
        }

        private void Damage(Character other, double distance)
        {
            if(other.Id == this.Id)
                return;
            else if(other.Allies(this))
                return; 

            if((this.Level - other.Level) >= LARGE_SETP_NIVEL)
                other.Health -= HEALTH_SETP - (HEALTH_SETP * HEALTH_MODIFY_SETP);
            else if((other.Level - this.Level) >= LARGE_SETP_NIVEL)
                other.Health -= HEALTH_SETP + (HEALTH_SETP * HEALTH_MODIFY_SETP);
            else
                other.Health -= HEALTH_SETP;
        }

        public void Damage(Thing thing, double distance)
        {
            if(Type == FighterType.Melee && distance>2)
                return;
            else if(Type == FighterType.Ranged && distance>20)
                return;
            else if(thing is Character)
                Damage((Character)thing, distance);
            else
                thing.Health -= HEALTH_SETP;
                
            if(thing.Health < 0)
                thing.Health = 0;
        }

        public void Heal(Character other)
        {
            if(other.Id != this.Id && !other.Allies(this))
                return;
            else if(other.Destroyed)
                return;

            other.Health += HEALTH_SETP;
            if(other.Health > HEALTH_MAX)
                other.Health = HEALTH_MAX;
        }
    }
}