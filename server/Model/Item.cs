using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model 
{
    public class Item 
    {   
        public Item(string sId, string sTipo)
        {
            this.sId = sId;
            this.sTipo = sTipo;
        }

        public int ID {get; set;}
        public string sId {get; set;}
        public string sTipo {get; set;}
    }    
}