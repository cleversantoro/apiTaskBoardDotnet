using Api.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Api.helper;
using Dapper.Contrib.Extensions;

namespace Api.Data
{
    public class JwtDao :BaseDao, IBaseDao<Jwt>
    {
        public JwtDao(IConfiguration config)
        {
            base._configuracoes = config;
        }

        #region  CRUD Operations
        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new Activity { id = id });
            }
        }

        public List<Jwt> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<Jwt> activities = new List<Jwt>();
                activities = conexao.GetAll<Jwt>().ToList();
                return activities;
            }
        }

        public Jwt GetById(int id)
        {
            Jwt usr = new Jwt();

            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                usr = conexao.Get<Jwt>(id);
                return usr;
            }
        }

        public void Insert(Jwt entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Jwt
                {
                    id = 0,
                    token = entity.token,
                });
            }
        }

        public void Update(Jwt entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Jwt
                {
                    id = 0,
                    token = entity.token,
                });
            }
        }
        #endregion

        public string GetJwtKey()
        {
            JwtDao jwtdao = new JwtDao(_configuracoes);
            Jwt jwt = jwtdao.GetById(1);

            if (jwt.id != 0)
            {
                jwt.token = BCrypt.Net.BCrypt.HashPassword(DateTime.Now.ToString("yyyyMMddHHmmss"));
                jwtdao.Insert(jwt);
            }

            return jwt.token;
        }

    }
}
