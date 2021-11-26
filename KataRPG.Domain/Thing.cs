namespace KataRPG.Domain
{
    public class Thing
    {
        public double Health {get; set;}
        public bool Destroyed => Health<=0;
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
    }
}