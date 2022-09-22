using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoreBackendClean.Infrastructure.Persistance;
using StoreBackendClean.Domain.Entity;

namespace StoreBackendClean.Application.Store.command
{
    public class ChangeStore : IRequest<Store> {

        uint Id {get; init;}
        string Name {get; init;}
        uint StoreKeeper {get; init}

        public ChangeStore(uint id, string name, uint store_keeper){
            this.Name = name;
            this.Id id;
            this.StoreKeeper = store_keeper;
        }

    }

    public class ChangeStoreHandler : IRequestHandler<ChangeStore, Store> {

        private readonly ApplicationContext context;

        public ChangeStoreHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<Store> Handle(ChangeStore request, CancellationToken cancellationToken) {
            
            Store store = await context.Stores.FindAsync(request.Id);
            User store_keeper = null;

            if(store == null){
                throw new Exception("Store not found!");
            }

            if(store.Name !=  null){
                store.Name = new_change.Name;
            }

            if(store.StoreKeeper != request.StoreKeeper){
                
                store_keeper = await context.Users.FindAsync(request.StoreKeeper);
                if(store_keeper == null){
                    throw new Exception("Store keeper not found!");
                }

                store.StoreKeeper = request.StoreKeeper;

            }

            context.Entry(store).State = EntityState.Modified;
            await context.SaveChangesAsync();

            if(store_keeper != null){
                store.StoreKeeperNavigation = store_keeper;
            }

            return store;
            
        }

    }
}