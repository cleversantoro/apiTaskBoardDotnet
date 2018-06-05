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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Api.Data
{
    public class TokenDao : BaseDao, IBaseDao<Token>
    {
        private Token token;

        public TokenDao(IConfiguration config)
        {
            base._configuracoes = config;
            token = new Token();
        }

        #region CRUD Operations
        public List<Token> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<Token> tokens = new List<Token>();
                tokens = conexao.GetAll<Token>().ToList();
                return tokens;
            }
        }

        public Token GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                Token usr = new Token();
                usr = conexao.Get<Token>(id);
                return usr;
            }
        }

        public void Update(Token entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Token
                {
                    id = entity.id,
                    token = entity.token,
                    user_id = entity.id,
                });
            }
        }

        public void Insert(Token entity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Token
                {
                    token = entity.token,
                    user_id = entity.user_id,
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Delete(new Token { id = id });
            }
        }
        #endregion

        public string GetTokenUser(int userid)
        {
            string sql = "select * from token where user_id = @UserId order by id desc";

            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                var token = conexao.QueryFirstOrDefault(sql, new { Userid = userid });
                return token.token;
            }
        }

        public void SetUserToken(User user, int expires)
        {
            JwtDao jwtdao = new JwtDao(_configuracoes);

            var tok = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create(jwtdao.GetJwtKey()))
                                .AddExpiry(expires)
                                .AddClaim("uid", user.id.ToString())
                                .Build();

            token.user_id = user.id;
            token.token = tok;

            Insert(token);
        }

        public bool ValidateToken(string authorization, bool requireAdmin = false)
        {
            //global $jsonResponse, $app;
            bool retVal = true;

            if (CheckDbToken(authorization))
            {
                retVal = true;
            }
            else
            {
                ClearDbToken(authorization);
                jsr.message = "Invalid token.";
                //$app->response->setStatus(401);
            }

            if (retVal && requireAdmin)
            {
                var user = GetUser(authorization);

                if (user.is_admin)
                {
                    ClearDbToken(authorization);
                    jsr.message = "Insufficient user privileges.";
                    //$app->response->setStatus(401);
                }
            }

            return retVal;
        }

        public bool CheckDbToken(string authorization)
        {
            bool isValid = false;
            User user = GetUser(authorization);
            if (user != null)
            {
                string tokenuser = GetTokenUser(user.id);
                if (tokenuser.Equals(authorization.Substring(7)))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public void ClearDbToken(string authorization)
        {
            UserDao userdao = new UserDao(_configuracoes);

            Payload payload = null;
            string hash = authorization.Substring(7);

            try
            {
                payload = this.DecodeToken(authorization);
            }
            catch (Exception ex) { }

            if (payload != null)
            {
                User user = userdao.GetById( Convert.ToInt32(payload.uid) );
                if (user.id != 0)
                {
                    List<Token> lstToken = this.GetAll().Where(p => p.user_id == Convert.ToInt32(payload.uid) ).ToList();

                    foreach (Token tk in lstToken) {

                        if (hash.Equals(tk.token)) 
                        {
                            this.Delete(token.id);
                        }
                    }
                    //r::store($user);
                }
            }
        }
    }
}
