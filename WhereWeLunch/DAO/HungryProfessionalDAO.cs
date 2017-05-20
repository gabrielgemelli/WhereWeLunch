using System.Collections.Generic;
using System.Linq;
using WhereWeLunch.Models;

namespace WhereWeLunch.DAO
{
    public class HungryProfessionalDAO
    {
        public IList<HungryProfessional> Get()
        {
            using (var context = new EntitiesContext())
            {
                return context.HungryProfessionals.ToList();
            }
        }

        public HungryProfessional Get(string email)
        {
            using (var context = new EntitiesContext())
            {
                return context.HungryProfessionals.FirstOrDefault(u => u.Email == email);
            }
        }

        public void Post(HungryProfessional hungryProfessional)
        {
            using (var context = new EntitiesContext())
            {
                context.HungryProfessionals.Add(hungryProfessional);
                context.SaveChanges();
            }
        }

        public void Update(HungryProfessional hungryProfessional)
        {
            using (var contexto = new EntitiesContext())
            {
                contexto.Entry(hungryProfessional).State = Microsoft.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void InitializeData()
        {
            if (!Get().Any())
            {
                var hungryProfessionals = new List<HungryProfessional>();

                hungryProfessionals.Add(new HungryProfessional("john.doe@dbserver.com.br", "teste123"));
                hungryProfessionals.Add(new HungryProfessional("jane.doe@dbserver.com.br", "teste123"));
                hungryProfessionals.Add(new HungryProfessional("joao.silva@dbserver.com.br", "teste123"));
                hungryProfessionals.Add(new HungryProfessional("maria.silva@dbserver.com.br", "teste123"));
                hungryProfessionals.Add(new HungryProfessional("paulo.silva@dbserver.com.br", "teste123"));

                hungryProfessionals.ForEach(usr => Post(usr));
            }
        }
    }
}