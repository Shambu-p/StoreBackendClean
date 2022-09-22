using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using StoreBackendClean.Infrastructure.Persistance;
using StoreBackendClean.Domain.Entity;

namespace StoreBackendClean.Application.UserModule.command
{
    public class CreateUser : IRequest<User> {

        string Name {get; init;}
        string Email {get; init;}
        string Password {get; init;}
        byte Role {get; init;}

        public CreateUser(string name, string email, byte role, string password){
            
            this.Name = name;
            this.Email = email;
            this.Role = role;
            this.Password = password;

        }

    }

    public class GetUserQueryHandler : IRequestHandler<CreateUser, User>{

        private readonly ApplicationContext context;

        public GetUserQueryHandler(ApplicationContext db_context){
            this.context = db_context;
        }

        public async Task<User> Handle(GetUsersQuery request, CancellationToken cancellationToken){
            
            User new_user = new User();
            new_user.Name = request.Name;
            new_user.Email = request.Email;
            new_user.Role = request.Role;
            new_user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            //the following code will be used to verify password
            //BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash);

            context.Users.Add(new_user);
            var result = await context.SaveChangesAsync();

            return new_user;

        }
    }
}