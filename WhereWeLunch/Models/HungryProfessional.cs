namespace WhereWeLunch.Models
{
    public class HungryProfessional
    {
        public HungryProfessional() { }

        public HungryProfessional(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public HungryProfessional(int id, string email, string password) : this(email, password)
        {
            ID = id;
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}