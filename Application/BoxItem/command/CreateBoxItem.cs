using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoreBackendClean.Infrastructure.Persistance;
using StoreBackendClean.Domain.Entity;

namespace StoreBackendClean.Application.BoxItem.command
{
    public class CreateBoxItem : IRequest<BoxItem> {

        uint ItemId {get; init;}
        uint StoreId {get; init;}
        int Amount {get; init;}

        public CreateBoxItem(uint item_id, uint box_id, uint store_id, int amount){
            this.ItemId = item_id;
            this.StoreId = store_id;
            this.BoxId = box_id;
            this.Amount = amount;
        }

    }

    public class CreateBoxItemHandler : IRequestHandler<CreateBoxItem, BoxItem> {

        private readonly ApplicationContext context;

        public CreateBoxItemHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<BoxItem> Handle(CreateBoxItem request, CancellationToken cancellationToken) {

            Box bx = context.Boxes
                .Include(b => b.Store)
                .Where(b => b.Id == request.BoxId)
                .FirstOrDefault();
            
            if(bx == null){
                throw new Exception("box not found!");
            }

            StoreItem st = StoreItem st = context.StoreItems
                .Where(st => st.ItemId == request.ItemId && st.StoreId == request.StoreId)
                .FirstOrDefault<StoreItem>();
            
            if(st.UnboxedAmount == 0 || st.UnboxedAmount < request.Amount){
                throw new Exception("trying to box more number of items than the available number of items in store");
            }

            BoxItem bx_item = new BoxItem();
            bx_item.BoxId = request.BoxId;
            bx_item.ItemId = request.ItemId;
            bx_item.Amount = request.Amount;

            // await store_item_service.itemBoxing(item_id, bx.Store.Id, Convert.ToUInt32(amount));
            st.UnboxedAmount -= request.Amount;
            context.BoxItems.Add(bx_item);
            await context.SaveChangesAsync();

            return bx_item;

        }

    }
}