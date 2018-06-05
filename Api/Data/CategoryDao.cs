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
    public class CategoryDao :BaseDao, IBaseDao<Category>
    {
        //private Category activ;

        public CategoryDao(IConfiguration config)
        {
            base._configuracoes = config;
            //activ = new Category();
        }

        #region CRUD Operations
        public List<Category> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<Category> activities = new List<Category>();
                activities = conexao.GetAll<Category>().ToList(); //Query<Category>("SELECT * FROM Category").ToList();
                return activities;
            }
        }

        public Category GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                Category usr = new Category();
                usr = conexao.Get<Category>(id);
                return usr;
            }
        }

        public void Update(Category entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Category
                {
                    id = entity.id,
                    board_id = entity.board_id,
                    color = entity.color,
                    name = entity.name,
                });
            }
        }

        public void Insert(Category entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Category
                {
                    board_id = entity.board_id,
                    color = entity.color,
                    name = entity.name,
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new Category { id = id });
            }
        }
        #endregion

        
    }
}
