

using System.Windows.Navigation;

namespace Animals
{
    public abstract class Animal
    {
        private readonly string name;
        //private const string name2 = "constVar";

        /*private string x2;
        private string X2
        {
            get { return x2; }
            set { x2 = value;  }
        }*/
        public string LivesAt { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }
        /*
        protected internal string X5 { get; set; }
        private protected string X6 { get; set; }*/
        protected AnimalTypes Types { get; set; }
        public Animal(string name, string livesat, int age, string owner)
        {
            this.name = name;
            this.LivesAt = livesat;
            this.Age = age;
            this.Owner = owner;
        }

        public virtual string Status()
        {
            return $"The {Types} name is {name} It's {Age} years old and lives at {LivesAt} and their owner is {Owner}";
        }

        public abstract string Speak();
        
    }

}
