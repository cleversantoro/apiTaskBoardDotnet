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
    public class BoardUserDao :BaseDao, IBaseDao<BoardUser>
    {
        //private BoardUser activ;

        public BoardUserDao(IConfiguration config)
        {
            base._configuracoes = config;
            //activ = new BoardUser();
        }

        #region CRUD Operations
        public List<BoardUser> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<BoardUser> activities = new List<BoardUser>();
                activities = conexao.GetAll<BoardUser>().ToList();
                return activities;
            }
        }

        public BoardUser GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                BoardUser usr = new BoardUser();
                usr = conexao.Get<BoardUser>(id);
                return usr;
            }
        }

        public void Update(BoardUser boardUser)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new BoardUser
                {
                    id = boardUser.id,
                    board_id = boardUser.board_id,
                    user_id = boardUser.user_id,
                });
            }
        }

        public void Insert(BoardUser boardUser)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new BoardUser
                {
                    board_id = boardUser.board_id,
                    user_id = boardUser.user_id,
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new BoardUser { id = id });
            }
        }
        #endregion


        
    }
}
