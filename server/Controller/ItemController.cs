using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace ctrl 
{
    public class ItemController : Controller
    {

        private readonly ItemContext oContext;
        public ItemController(ItemContext context)
        {
            this.oContext = context;
        }

        [HttpGet("v1/Item")]
        public IActionResult ListarItens()
        {        
            return Ok(oContext.Itens);
        }
    }
}