using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/boards")]
    public class BoardController : Controller
    {
        [HttpGet]
        public async Task<string> Boards([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.BoardGetAll(); ;
        }

        [HttpPost]
        public async Task<string> Create([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.BoardCreate(); ;
        }

        [HttpPost("update")]
        public async Task<string> Update([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.BoardUpdate(); ;
        }

        [HttpPost("remove")]
        public async Task<string> Remove([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.BoardRemove(); ;
        }

        [HttpGet("~/api/autoactions")]
        public async Task<string> UpdateEmail([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.UpdateEmail(); ;
        }

        [HttpPost("~/api/autoactions")]
        public async Task<string> UpdateBoard([FromServices]BoardDao boardsDao, [FromBody]AutoActions autoactions)
        {
            return await boardsDao.UpdateBoard(autoactions); ;
        }

        [HttpPost("~/api/autoactions/remove")]
        public async Task<string> Actions([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.Actions(); ;
        }

        [HttpGet("~/lanes/{laneId}/toggle")]
        public async Task<string> BoardsCurrent([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.BoardsCurrent(); ;
        }

        [HttpGet("{boardId}/toggleActive")]
        public async Task<string> BoardsCurrentOptions([FromServices]BoardDao boardsDao)
        {
            return await boardsDao.BoardsCurrentOptions(); ;
        }


    }
}