using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Shop.Controllers
{


    [Route("users")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context
                .Users
                .AsNoTracking()
                .ToListAsync();
            return users;    

        }


        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post(
        [FromServices] DataContext context,
        [FromBody] User model)
        {
            //verifica se os dados são validos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                // Força o usuário a ser sempre "funcionário"
                model.Role = "employee";

                context.Users.Add(model);
                await context.SaveChangesAsync();

                model.Password = "";
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar um usuário" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "manager")]
    public async Task<ActionResult<User>> Put(
            [FromServices] DataContext context,
            int id,
            [FromBody] User model)
    {
        // verfica se os dados são válidos

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Verfica se o ID informado é o mesmo do modelo 
        if (id != model.Id)
            return NotFound(new { message = "Usuário não encontrado" });

        try
        {
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return model;
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível criar usuário" });
        }
    }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            var user = await context.Users
            .AsNoTracking()
            .Where(x => x.Username == model.Username && x.Password == model.Password)
            .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidas" });

            var token = TokenService.GenerateToken(user);
            //Esconde a senha 
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };    
        }
        

    }
}