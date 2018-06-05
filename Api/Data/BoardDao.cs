using Api.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Api.helper;
using Api.ViewModels;

namespace Api.Data
{
    public class BoardDao :BaseDao, IBaseDao<Board>
    {
        private Board board;

        public BoardDao(IConfiguration config)
        {
            base._configuracoes = config;
            board = new Board();
        }

        #region CRUD Operations
        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new Board { id = id });
            }
        }

        public List<Board> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("taskboarddatabase")))
            {
                List<Board> boards = new List<Board>();
                boards = conexao.GetAll<Board>().ToList();
                return boards;
            }
        }

        public Board GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                Board usr = new Board();
                usr = conexao.Get<Board>(id);
                return usr;
            }
        }

        public void Insert(Board entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Board
                {
                    id = entity.id,
                    active = entity.active,
                    name = entity.name,
                });
            }
        }

        public void Update(Board entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Board
                {
                    active = entity.active,
                    name = entity.name,
                });
            }
        }
        #endregion

        public Task<string> BoardGetAll()
        {
            return null; // await boardsDao.BoardGetAll(); ;
        }

        public Task<string> BoardCreate()
        {
            return null;// await boardsDao.BoardCreate(); ;
        }

        public Task<string> BoardUpdate()
        {
            return null; //await boardsDao.BoardUpdate(); ;
        }

        public Task<string> BoardRemove()
        {
            return null; // await boardsDao.BoardRemove(); ;
        }

        public Task<string> UpdateEmail()
        {
            return null; //await boardsDao.UpdateEmail(); ;
        }

        public Task<string> UpdateBoard(AutoActions autoactions)
        {
            return null;// await boardsDao.UpdateBoard(autoactions); ;
        }

        public Task<string> Actions()
        {
            return null;// await boardsDao.Actions(); ;
        }

        public Task<string> BoardsCurrent()
        {
            return null;// await boardsDao.BoardToggle(); ;
        }

        public Task<string> BoardsCurrentOptions()
        {
            return null; // await boardsDao.BoardToggleActive(); ;
        }

    }
}
