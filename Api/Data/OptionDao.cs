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
    public class OptionDao : BaseDao, IBaseDao<Option>
    {
       private Option option;

        public OptionDao(IConfiguration config)
        {
            base._configuracoes = config;
            option = new Option();
        }

        #region CRUD Operations
        public List<Option> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<Option> activities = new List<Option>();
                activities = conexao.GetAll<Option>().ToList(); 
                return activities;
            }
        }

        public Option GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                Option usr = new Option();
                usr = conexao.Get<Option>(id);
                return usr;
            }
        }

        public void Update(Option entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Option
                {
                    id = entity.id,
                    show_animations = entity.show_animations,
                    show_assignee = entity.show_assignee,
                    tasks_order = entity.tasks_order,
                    user_id = entity.user_id,
                });
            }
        }

        public void Insert(Option entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Option
                {
                    show_animations = entity.show_animations,
                    show_assignee = entity.show_assignee,
                    tasks_order = entity.tasks_order,
                    user_id = entity.user_id,
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new Option { id = id });
            }
        }
        #endregion
  

    }
}
