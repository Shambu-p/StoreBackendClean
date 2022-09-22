using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreBackendClean.Domain.Entity;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace StoreBackendClean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ApiController {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> all(){
            ItemService service = new ItemService(context);
            return await service.getAll();
        }

        [HttpGet("{item_id}")]
        public async Task<ActionResult<Item>> getItem(uint item_id) {
            
            ItemService service = new ItemService(context);
            var item = await service.getItemById(item_id);
            
            if(item == null){
                return NotFound("Item not found!");
            }

            return item;

        }

        [HttpPost]
        public async Task<ActionResult<Item>> addItem([FromForm] string name, [FromForm] double price){
            ItemService service = new ItemService(context);
            return await service.addItem(name, price);
        }

        [HttpPut]
        public async Task<ActionResult<Item>> changeItem([FromForm] uint id, [FromForm] string name, [FromForm] double price){
            
            ItemService service = new ItemService(context);
            Item new_item = new Item();
            new_item.Id = id;
            new_item.Name = name;
            new_item.Price = price;
            Item item = await service.changeItem(new_item);

            if(item == null){
                return NotFound("item not found!");
            }

            return item;

        }

    }

}