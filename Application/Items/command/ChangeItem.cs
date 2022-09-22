using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoreBackendClean.Infrastructure.Persistance;
using StoreBackendClean.Domain.Entity;

namespace StoreBackendClean.Application.Items.command
{
    public class ChangeItem : IRequest<Item> {
        public ChangeItem(){}
    }

    public class ChangeItemHandler : IRequestHandler<ChangeItem, Item> {

        private readonly ApplicationContext context;

        public ChangeItemHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<Item> Handle(ChangeItem request, CancellationToken cancellationToken) {

        }

    }
}