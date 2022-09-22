using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoreBackendClean.Infrastructure.Persistance;
using StoreBackendClean.Domain.Entity;

namespace StoreBackendClean.Application.StoreItem.command
{
    public class CreateStoreItem : IRequest<StoreItem> {
        public CreateStoreItem(){}
    }

    public class CreateStoreItemHandler : IRequestHandler<CreateStoreItem, StoreItem> {

        private readonly ApplicationContext context;

        public CreateStoreItemHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<StoreItem> Handle(CreateStoreItem request, CancellationToken cancellationToken) {

        }

    }
}