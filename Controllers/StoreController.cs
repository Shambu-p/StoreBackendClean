using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StoreBackendClean.Domain.Entity;

namespace StoreBackendClean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StoreController : ApiController {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> getAllStores() {

            StoreService service = new StoreService(context);
            return Ok(await service.getAll());

        }

        [HttpGet("items/{store_id}")]
        public async Task<ActionResult<IEnumerable<StoreItem>>> getAllStoreItems(uint store_id) {

            StoreService service = new StoreService(context);
            return Ok(await service.getAllItems(store_id));
            // return Ok(await context.StoreItems.Include(s => s.Store).Where(s => s.Store.Id == store_id).ToListAsync());

        }

        [HttpGet("{store_id}")]
        public async Task<ActionResult<Store>> getStore(uint store_id){

            StoreService service = new StoreService(context);
            return Ok(await service.getStoreById(store_id));

        }

        [HttpGet("items/single_item/{id}")]
        public async Task<ActionResult<IEnumerable<StoreItem>>> getStoreItem(uint id) {

            StoreItemService service = new StoreItemService(context);
            return Ok(service.storeItem(id));

        }

        [HttpPost]
        public async Task<ActionResult<Store>> addStore([FromForm] string store_name, [FromForm] uint store_keeper) {

            StoreService service = new StoreService(context);
            return Ok(await service.addStore(store_name, store_keeper));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

        }

        [HttpPost("items")]
        public async Task<ActionResult<StoreItem>> createStoreItem([FromForm] uint store_id, [FromForm] uint item_id, [FromForm] uint amount) {

            StoreItemService service = new StoreItemService(context);
            var store_item = await service.createItem(store_id, item_id, amount);

            if(store_item != null){
                return NotFound("operation failed!");
            }else{
                return store_item;
            }

        }

        [HttpPut]
        public async Task<ActionResult<Store>> editStore([FromForm] uint store_id, [FromForm] string store_name, [FromForm] uint store_keeper) {

            StoreService service = new StoreService(context);
            Store store = new Store();
            store.Id = store_id;
            store.Name = store_name;
            store.StoreKeeper = store_keeper;

            return await service.changeStore(store);

        }

        [HttpPut("items/change_amount")]
        public async Task<ActionResult<StoreItem>> addStoreItemAmount([FromForm] uint store_id, [FromForm] uint item_id, [FromForm] int amount) {

            try{
                StoreItemService service = new StoreItemService(context);
                StoreItem store_item;
                
                if(amount > 0){
                    store_item = await service.addItem(store_id, item_id, Convert.ToUInt32(amount));
                }else{
                    store_item = await service.minimizeItem(store_id, item_id, Convert.ToUInt32(Math.Abs(amount)));
                }

                if(store_item == null){
                    return NotFound("operation failed!");
                }

                return Ok(store_item);

            }catch(Exception ex){
                return NotFound(ex.Message);
            }

        }

    }

}