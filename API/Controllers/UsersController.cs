using System;
using System.Collections;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]


public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>> Getuser()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }

       [HttpGet("{id: int}")] //api/users/id (can be 1, 2, or 3)
    public async Task<ActionResult<AppUser>> Getuser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user == null)
        return NotFound();

        return user;
    }
}
