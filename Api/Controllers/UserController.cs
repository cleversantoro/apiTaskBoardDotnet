using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {

        [HttpPost("~/api/login")]
        public async Task<string> Login([FromServices]UserDao UsersDao, [FromBody]Login login)
        {
            return await UsersDao.login(login.username, login.password, login.rememberme);
        }

        [HttpGet("~/api/logout")]
        public async Task<string> Logout([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.logout(Authorization);
        }

        [HttpGet("~/api/updatepassword")]
        public async Task<string> UpdatePassword([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UpdatePassword(Authorization);
        }

        [HttpGet("~/api/updateusername")]
        public async Task<string> UpdateUserName([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UpdateUsername(Authorization); ;
        }

        [HttpGet("~/api/updateemail")]
        public async Task<string> UpdateEmail([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UpdateEmail(Authorization); ;
        }

        [HttpGet("~/api/updateboard")]
        public async Task<string> UpdateBoard([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UpdateBoard(Authorization); ;
        }

        [HttpGet("~/api/actions")]
        public async Task<string> Actions([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.Actions(Authorization); ;
        }

        [HttpGet("current")]
        public async Task<string> UsersCurrent([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UserCurrent(Authorization); ;
        }

        [HttpGet("current/options")]
        public async Task<string> UsersCurrentOptions([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UserCurrentOptions(Authorization); ;
        }

        [HttpGet]
        public async Task<string> Users([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UserGetAll(Authorization); ;
        }

        [HttpPost]
        public async Task<string> Create([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UserCreate(Authorization); ;
        }

        [HttpGet("update")]
        public async Task<string> Update([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UserUpdate(Authorization); ;
        }

        [HttpGet("remove")]
        public async Task<string> Remove([FromServices]UserDao UsersDao, [FromHeader]string Authorization)
        {
            return await UsersDao.UserRemove(Authorization); ;
        }

    }
}