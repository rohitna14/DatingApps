using System;
using System.Collections;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]

public class UsersController(IUserRepository userRepository) : BaseApiController
{
    [HttpGet]
    [Route("AllUsers")]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();
    


        return Ok(users);
    }

    [HttpGet("{username}")] //api/users/id (can be 1, 2, or 3)
    public async Task<ActionResult<MemberDto>> Getuser(string username)
    {
        var user = await userRepository.GetMemberAsync(username);

        if(user == null)
        return NotFound();
        return user;
    }
}
