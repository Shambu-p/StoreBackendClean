using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreBackendClean.Domain.Entity;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

using MediatR;
using StoreBackendClean.Application.UserModule.command;

namespace StoreBackendClean.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class UserController : ControllerBase {
        
        private ISender sender;

        public UserController(ISender m_sender) {
            sender = m_sender;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<User>>> all() {
        //     UserService service = new UserService(stContext);
        //     return await service.getAllUsers();
        // }

        [HttpGet("/clean/{id}")]
        public async Task<ActionResult<User>> getSingleUser(uint id){
            try{
                return await sender.Send(new GetUser(id));
            }catch(Exception ex){
                return NotFound(ex.Message);
            }
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<User>> single(uint id) {

        //     UserService service = new UserService(stContext);
        //     var user = await service.getUserById(id);

        //     if(user == null) {
        //         return NotFound("user not found");
        //     }
            
        //     return user;

        // }

        // [HttpPost]
        // public async Task<ActionResult<User>> add([FromForm] string name,[FromForm] string email,[FromForm] string password,[FromForm] byte role) {

        //     UserService service = new UserService(stContext);
        //     // return CreatedAtAction("Add User", new {Id = new_user.Id }, new_user);
        //     return await service.addUser(name, email, password, role);

        // }

        // [HttpPut]
        // public async Task<ActionResult<User>> change([FromForm]uint id,[FromForm] string name,[FromForm] string email,[FromForm] byte role) {

        //     UserService service = new UserService(stContext);
        //     User new_user = new User();
        //     new_user.Name = name;
        //     new_user.Id = id;
        //     new_user.Email = email;
        //     new_user.Role = role;

        //     var user = await service.changeUser(new_user);
        //     if(user == null) {
        //         return NotFound();
        //     }

        //     return user;

        // }

        // [HttpPut("change_password")]
        // public async Task<ActionResult<User>> changePassword([FromForm] string current_password, [FromForm] string new_password, [FromForm] string confirm_password) {
            
        //     UserService service = new UserService(stContext);

        //     User found_user = await service.getUserById(uint.Parse(User?.FindFirstValue("Id")));

        //     if(found_user == null){
        //         return NotFound("user not found!");
        //     }

        //     if(!BCrypt.Net.BCrypt.Verify(current_password, found_user.Password)) {
        //         return NotFound("incorrect password!");
        //     }

        //     if(new_password != confirm_password){
        //         return NotFound("new passwords does not match!");
        //     }

        //     found_user.Password = new_password;

        //     var user = await service.changeUser(found_user);
        //     if(user == null) {
        //         return NotFound("user not found!");
        //     }

        //     return user;

        // }

    }
}