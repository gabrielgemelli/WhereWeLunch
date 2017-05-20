using System.Collections.Generic;
using System.Linq;
using WhereWeLunch.Models;

namespace WhereWeLunch.DAO
{
    public class RestaurantDAO
    {
        public IList<Restaurant> Get()
        {
            using (var context = new EntitiesContext())
            {
                return context.Restaurants.ToList();
            }
        }

        public Restaurant Get(int id)
        {
            using (var context = new EntitiesContext())
            {
                return context.Restaurants.FirstOrDefault(a => a.ID == id);
            }
        }

        public void Post(Restaurant restaurant)
        {
            using (var context = new EntitiesContext())
            {
                context.Restaurants.Add(restaurant);
                context.SaveChanges();
            }
        }

        public void Update(Restaurant restaurant)
        {
            using (var contexto = new EntitiesContext())
            {
                contexto.Entry(restaurant).State = Microsoft.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);

            using (var context = new EntitiesContext())
            {
                context.Restaurants.Remove(restaurant);
                context.SaveChanges();
            }
        }

        public void InitializeData()
        {
            if (!Get().Any())
            {
                var restaurants = new List<Restaurant>();

                restaurants.Add(new Restaurant("Bar 3 Restaurante"));
                restaurants.Add(new Restaurant("Bar 12"));
                restaurants.Add(new Restaurant("Bar da Famecos"));
                restaurants.Add(new Restaurant("Bar do 5"));
                restaurants.Add(new Restaurant("Bar do 8"));
                restaurants.Add(new Restaurant("Bar Trinta"));
                restaurants.Add(new Restaurant("Espaço 32"));
                restaurants.Add(new Restaurant("Garten Bistrô"));
                restaurants.Add(new Restaurant("Intervalo 50"));
                restaurants.Add(new Restaurant("Restaurante Central (15)"));
                restaurants.Add(new Restaurant("Restaurante Universitário (RU)"));
                restaurants.Add(new Restaurant("Palatus"));
                restaurants.Add(new Restaurant("Panorama Gastronômico"));
                restaurants.Add(new Restaurant("Panorama 40 Lanchonete"));
                restaurants.Add(new Restaurant("Ponto Onze"));
                restaurants.Add(new Restaurant("Sabor Família"));
                restaurants.Add(new Restaurant("Subway"));
                restaurants.Add(new Restaurant("Vila Olímpica Restaurante"));
                restaurants.Add(new Restaurant("Buffet Vitória"));
                restaurants.Add(new Restaurant("Novo Sabor Buffet"));
                restaurants.Add(new Restaurant("Silva Lanches"));
                restaurants.Add(new Restaurant("Bar Maza"));

                restaurants.ForEach(rst => Post(rst));
            }
        }
    }
}