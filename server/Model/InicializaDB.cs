using System.Linq;
using System.Collections.Generic;

namespace  Model
{
    public class InicializaDb
    {
        public static void Initialize(ItemContext oContext)
        {
            oContext.Database.EnsureCreated();

            if(oContext.Itens.Any())
                return;

            List<Item> lstItem = new List<Item>()
            {
                new Item().FactoryItem("Air",     "prefixo"),
                new Item().FactoryItem("Jet",     "prefixo"),
                new Item().FactoryItem("Flight",  "prefixo"),
                new Item().FactoryItem("Hub",     "sufixo"),
                new Item().FactoryItem("Station", "sufixo"),
                new Item().FactoryItem("Mars",    "sufixo"),
            };
            
            //insert
            oContext.Itens.AddRange(lstItem);

            // commit   
            oContext.SaveChanges();
        }
    }
}