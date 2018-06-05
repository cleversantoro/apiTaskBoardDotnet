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
    public class LaneDao :BaseDao, IBaseDao<Lane>
    {
        //private Lane activ;
        public LaneDao(IConfiguration config)
        {
            base._configuracoes = config;
            //activ = new Lane();
        }

        #region CRUD Operations
        public List<Lane> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<Lane> activities = new List<Lane>();
                activities = conexao.GetAll<Lane>().ToList();
                return activities;
            }
        }

        public Lane GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                Lane usr = new Lane();
                usr = conexao.Get<Lane>(id);
                return usr;
            }
        }

        public void Update(Lane entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Lane
                {
                    id = entity.id,
                    board_id = entity.board_id,
                    name = entity.name,
                    position = entity.position
                });
            }
        }

        public void Insert(Lane entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Lane
                {
                    board_id = entity.board_id,
                    name = entity.name,
                    position = entity.position
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new Lane { id = id });
            }
        }
        #endregion


        



    }
}
