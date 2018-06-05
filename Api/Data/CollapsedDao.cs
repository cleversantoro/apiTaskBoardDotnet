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
    public class CollapsedDao :BaseDao, IBaseDao<Collapsed>
    {
        //private Collapsed activ;

        public CollapsedDao(IConfiguration config)
        {
            base._configuracoes = config;
            //activ = new Collapsed();
        }

        #region CRUD Operations
        public List<Collapsed> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<Collapsed> activities = new List<Collapsed>();
                activities = conexao.GetAll<Collapsed>().ToList();
                return activities;
            }
        }

        public Collapsed GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                Collapsed usr = new Collapsed();
                usr = conexao.Get<Collapsed>(id);
                return usr;
            }
        }

        public void Update(Collapsed collapsed)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Collapsed
                {
                    id = collapsed.id,
                    lane_id = collapsed.lane_id,
                    user_id = collapsed.user_id,
                });
            }
        }

        public void Insert(Collapsed collapsed)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Collapsed
                {
                    lane_id = collapsed.lane_id,
                    user_id = collapsed.user_id,
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new Collapsed { id = id });
            }
        }
        #endregion


    }
}
