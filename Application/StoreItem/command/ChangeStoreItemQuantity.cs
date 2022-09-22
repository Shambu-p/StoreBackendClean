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
    public class ChangeStoreItemQuantity : IRequest<StoreItem> {
        public ChangeStoreitemQuantity(){}
    }

    public class ChangeStoreItemQuantityHandler : IRequestHandler<ChangeStoreItemQuantity, User> {

        private readonly ApplicationContext context;

        public ChangeStoreItemQuantityHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<StoreItem> Handle(ChangeStoreItemQuantity request, CancellationToken cancellationToken) {

        }

    }

}