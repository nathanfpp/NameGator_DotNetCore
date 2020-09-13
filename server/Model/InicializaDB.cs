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

                List<Item> lstItem = new List<Item>(){
                    new Item("Air",     "prefixo"),
                    new Item("Jet",     "prefixo"),
                    new Item("Flight",  "prefixo"),
                    new Item("Hub",     "sufixo"),
                    new Item("Station", "sufixo"),
                    new Item("Mars",    "sufixo"),
                };
            
            //insert
            oContext.Itens.AddRange(lstItem);

            // commit   
            oContext.SaveChanges();
        }
    }
}