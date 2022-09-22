using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBackendClean.Application.StoreItem.Query
{
    public class GetStoreItemsQuery : IRequest<Store> {
        public GetStoreItemsQuery(){

        }
    }

    public class GetStoreItemsQuery : IRequestHandler<GetStoreItemsQuery, Store> {

        private readonly ApplicationContext context;

        public GetStoreItemsQuery(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<Store> Handle(GetStoreItemsQuery request, CancellationToken cancellationToken) {

        }

    }
}