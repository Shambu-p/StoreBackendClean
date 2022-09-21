using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBackendClean.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoreBackendClean.Infrastructure.Persistance;

namespace StoreBackendClean.Application.UserModule.command {
    
    public record GetUser : IRequest<ActionResult<User>> {
        
        public uint id {get; init;}

        public GetUser(uint id){
            this.id = id;
        }

    }

    public class GetUserHandler: IRequestHandler<GetUser, ActionResult<User>> {

        private readonly ApplicationContext context;

        public GetUserHandler(ApplicationContext db_context){
            context = db_context;
        }

        public async Task<ActionResult<User>> Handle(GetUser request, CancellationToken cancellationToken) {

            var result = await context.Users.FindAsync(request.id);
            
            if(result == null){
                throw new Exception("user not found");
            }

            return result;

        }

    }
}