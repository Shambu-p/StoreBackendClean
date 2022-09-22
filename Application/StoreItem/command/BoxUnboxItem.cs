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
    public class BoxUnboxItem : IRequest<StoreItem> {
        public BoxUnboxItem(){}
    }

    public class BoxUnboxItemHandler : IRequestHandler<BoxUnboxItem, User> {

        private readonly ApplicationContext context;

        public BoxUnboxItemHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<StoreItem> Handle(BoxUnboxItem request, CancellationToken cancellationToken) {

        }

    }
}