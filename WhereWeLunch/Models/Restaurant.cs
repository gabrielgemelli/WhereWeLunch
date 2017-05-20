namespace WhereWeLunch.Models
{
    public class Restaurant
    {
        public Restaurant() { }

        public Restaurant(string name)
        {
            this.Name = name;
        }

        public Restaurant(int id, string name) : this(name)
        {
            this.ID = id;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
    }
}