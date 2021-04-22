using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Linq;


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
        
        [HttpPost]
        [Route("v1/Item/Add")]
        public IActionResult AdicionarItem([FromBody] Item oItem)
        {
            oContext.Database.EnsureCreated();
            //insert
            oContext.Itens.Add(oItem.FactoryItem(oItem.sId, oItem.sTipo));
            // commit   
            oContext.SaveChanges();

            return Ok(oItem.sId);
        }
        
        [HttpDelete]
        [Route("v1/Item/Delete")]
        public IActionResult DeletarItem([FromBody] Item oItem)
        {       
            oContext.Database.EnsureCreated();
            if(!oContext.Itens.Any()) 
                return NotFound();
        
            try
            {
                Item oItemRemovido = oContext.Itens.First(x => x.sTipo == oItem.sTipo && x.sId == oItem.sId);
                oContext.Itens.Remove(oItemRemovido);
                oContext.SaveChanges();
                return Ok($"Item {oItem.sTipo}: {oItem.sId} deletado com sucesso");
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }    
    }
}