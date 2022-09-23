using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StoreBackendClean.Domain.Entity;
using StoreBackendClean.Application.BoxModule.command;
using StoreBackendClean.Application.BoxModule.Query;
using StoreBackendClean.Application.BoxItemModule.Query;
using StoreBackendClean.Application.BoxItemModule.command;

namespace StoreBackendClean.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class BoxController : ApiController {

        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> getBox(uint id) {

            try{
                return Ok(await mediator.Send(new GetBoxQuery(id)));
            }catch(Exception ex){
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Box>> saveBox(uint store_id, uint user_id){

            try{
                return Ok(await mediator.Send(new CreateBox(store_id, user_id)));
            }catch(Exception ex){
                return NotFound(ex.Message);
            }

        }

        [HttpGet("items/{box_id}/{item_id}")]
        public async Task<ActionResult<BoxItem>> boxItem(uint box_id, uint item_id){
            
            try{
                return Ok(await mediator.Send(new GetBoxItemQuery(box_id, item_id)));
            }catch(Exception ex){
                return NotFound(ex.Message);
            }

        }

        [HttpGet("items/{box_id}")]
        public async Task<ActionResult<IEnumerable<BoxItem>>> getByBox(uint box_id){
            
            try{
                return Ok(await mediator.Send(new GetBoxItemsQuery(box_id)));
            }catch(Exception ex){
                return NotFound(ex.Message);
            }

        }

        [HttpPost("items")]
        public async Task<ActionResult<BoxItem>> createBoxItem(uint box_id, uint item_id, int amount) {

            try{
                return Ok(await mediator.Send(new CreateBoxItem(box_id, item_id, amount)));
            }catch(Exception ex){
                return NotFound(ex.Message);
            }

        }

        [HttpPut("items/change_quantity")]
        public async Task<ActionResult<BoxItem>> addBoxItem(uint box_id, uint item_id, int amount) {

            try{
                
                BoxItem box_item;
                
                if(amount > 0){
                    box_item = await mediator.Send(new ChangeItemQuantity(item_id, box_id, amount, true));
                } else{
                    box_item = await mediator.Send(new ChangeItemQuantity(item_id, box_id, Math.Abs(amount), false));
                }

                return Ok(box_item);

            }catch(Exception ex){
                return NotFound(ex.Message);
            }

        }

    }
}