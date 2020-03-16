using Ad4You;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad4You
{
    public static class CatalogData
    {
        public static void InitData(Ad4YouContext context)
        {
            if (!context.city.Any())
            {
                context.city.Add(new Models.City() { name = "Kyiv" });
                context.city.Add(new Models.City() { name = "Kharkiv" });
                context.city.Add(new Models.City() { name = "Lviv" });
                context.city.Add(new Models.City() { name = "Odessa" });
                context.SaveChanges();
            }

            if (!context.rubric.Any())
            {
                context.rubric.Add(new Models.Rubric() { name = "Animals" });
                context.rubric.Add(new Models.Rubric() { name = "Clothes" });
                context.rubric.Add(new Models.Rubric() { name = "Property" });
                context.rubric.Add(new Models.Rubric() { name = "Transport" });
                context.SaveChanges();
            }

            if (!context.currency.Any())
            {
                context.currency.Add(new Models.Currency() { sign = "₴" });
                context.currency.Add(new Models.Currency() { sign = "$" });
                context.currency.Add(new Models.Currency() { sign = "€" });
                context.SaveChanges();
            }
        }
    }
}