namespace Animals
{
    public class Cat : Animal
    {
        public Cat() : base("", "", 0, "")
        {
        
            Types = AnimalTypes.Cat;
        }
        public Cat(string name) : base(name, "", 0, "")
        {
            Types = AnimalTypes.Cat;
        }
        public Cat(string name, string owner, string livesat, int age = 2) : base(name, livesat, age, owner)
        {
            Types = AnimalTypes.Cat;
        }
        public override string Status()
        {
            string status = base.Status();
            return status + "And they like to Meow.";
        }

        public override string Speak()
        {
            return "Meow!";
        }
    }
}
