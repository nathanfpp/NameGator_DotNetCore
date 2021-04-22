using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model 
{
    public class Item 
    {   
        public int ID {get; set;}
        public string sId {get; set;}
        public string sTipo {get; set;}

        public Item FactoryItem(string sId, string sTipo)
        {
            Item oItem = new Item();
            oItem.sId = sId;
            oItem.sTipo = sTipo;
            return oItem;
        }
    }    
}