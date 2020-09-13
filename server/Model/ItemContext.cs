using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model 
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }

        public DbSet<Item> Itens {get; set;}
    }

}