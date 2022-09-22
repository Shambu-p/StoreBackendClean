using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StoreBackendClean.Model.Entity;


namespace StoreBackendClean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxController : ApiController {

        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> getBox(uint id) {

            BoxService service = new BoxService(context);
            var box = await service.viewBox(id);

            if(box == null){
                return NotFound("box not founds!");
            }

            return Ok(box);

        }

        [HttpPost]
        public async Task<ActionResult<Box>> saveBox(uint store_id, uint user_id){

            BoxService service = new BoxService(context);
            var box = await service.addBox(store_id, user_id);
            if(box == null){
                return NotFound("store or user not found! opertaion failed!");
            }

            return Ok(box);

        }

        [HttpGet("items/{box_id}/{item_id}")]
        public async Task<ActionResult<BoxItem>> boxItem(uint box_id, uint item_id){
            BoxItemService service = new BoxItemService(context);
            return Ok(await service.single(box_id, item_id));
        }

        [HttpGet("items/{box_id}")]
        public async Task<ActionResult<IEnumerable<BoxItem>>> getByBox(uint box_id){
            BoxItemService service = new BoxItemService(context);
            return Ok(await service.getByBox(box_id));
        }

        [HttpPost("items")]
        public async Task<ActionResult<BoxItem>> createBoxItem(uint box_id, uint item_id, int amount) {

            BoxItemService service = new BoxItemService(context);
            return Ok(await service.create(box_id, item_id, amount));

        }

        [HttpPut("items/add")]
        public async Task<ActionResult<BoxItem>> addBoxItem(uint box_id, uint item_id, int amount) {

            BoxItemService service = new BoxItemService(context);
            var res = await service.addBoxItem(box_id, item_id, amount);
            if(res == null){
                return NotFound("operation failed");
            }
            return Ok(res);

        }

        [HttpPut("items/minimize")]
        public async Task<ActionResult<BoxItem>> unbox(uint box_id, uint item_id, int amount) {

            BoxItemService service = new BoxItemService(context);
            var res = await service.UnboxItem(box_id, item_id, amount);
            if(res == null){
                return NotFound("operation failed");
            }
            return Ok(res);

        }

    }
}