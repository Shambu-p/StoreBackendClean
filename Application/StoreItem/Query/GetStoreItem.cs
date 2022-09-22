using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoreBackendClean.Infrastructure.Persistance;
using StoreBackendClean.Domain.Entity;

namespace StoreBackendClean.Application.StoreItem.Query
{
    public class GetStoreItem : IRequest<StoreItem> {
        
        public GetStoreItem(){

        }
    }

    public class GetStoreItemHandler : IRequestHandler<GetStoreItem, StoreItem> {

        private readonly ApplicationContext context;

        public GetStoreItemHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<StoreItem> Handle(GetStoreItem request, CancellationToken cancellationToken) {

        }

    }
}