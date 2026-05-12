

namespace Animals
{
    public class Dog : Animal
    {
        public Dog() : base("", "", 0, "")
        {

            Types = AnimalTypes.Cat;
        }
        public Dog(string name) : base(name, "", 0, "")
        {
            Types = AnimalTypes.Cat;
        }
        public Dog(string name, string owner, string livesat, int age = 2) : base(name, livesat, age, owner)
        {
            Types = AnimalTypes.Cat;
        }
        public override string Status()
        {
            string status = base.Status();
            return status + "And they like to Barq.";
        }

        public override string Speak()
        {
            return "Barq!";
        }
    }
}
