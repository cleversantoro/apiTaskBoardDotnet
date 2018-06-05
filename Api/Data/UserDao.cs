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
using Api.ViewModels;
using Dapper.Contrib.Extensions;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Api.Data
{
    public class UserDao : BaseDao, IBaseDao<User>
    {
        private User user;
        private TokenDao tkdao;
        private ActivityDao actdao;

        public UserDao(IConfiguration config)
        {
            base._configuracoes = config;
            user = new User();
            tkdao = new TokenDao(_configuracoes);
            actdao = new ActivityDao(_configuracoes);
        }

        #region CRUD Operations
        public User GetUserByName(string username)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                User usr = new User();
                usr = conexao.QueryFirstOrDefault<User>(
                    "SELECT id, " +
                    "username, " +
                    "is_admin, " +
                    "logins, " +
                    "last_login, " +
                    "default_board, " +
                    "salt, password, " +
                    "email " +
                    "FROM [user] " +
                    "WHERE username = @UserName",
                    new { UserName = username });
                return usr;
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                User usr = new User();
                conexao.Open();
                usr = conexao.Get<User>(id);
                return usr;
            }
        }

        public void Update(User user)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Update(new User
                {
                    id = user.id,
                    default_board = user.default_board,
                    email = user.email,
                    is_admin = user.is_admin,
                    last_login = user.last_login,
                    logins = user.logins,
                    password = user.password,
                    salt = user.salt,
                    username = user.username
                });
            }
        }

        public void Insert(User user)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Update(new User
                {
                    default_board = user.default_board,
                    email = user.email,
                    is_admin = user.is_admin,
                    last_login = user.last_login,
                    logins = user.logins,
                    password = user.password,
                    salt = user.salt,
                    username = user.username
                });
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<User> activities = new List<User>();
                activities = conexao.GetAll<User>().ToList();
                return activities;
            }
        }

        #endregion

        public Task<string> login(string username, string password, bool rememberme)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            user = GetUserByName(username);

            DateTime exp = rememberme ? DateTime.Now.AddDays((2 * 7 * 24 * 60 * 60)) : DateTime.Now.AddHours((1.5 * 60 * 60));
            int expires = (int)(exp - new DateTime(1970, 1, 1)).TotalSeconds;

            jsr.message = "Invalid username or password.";
            //$app->response->setStatus(401);

            if (user != null)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(password, user.salt);

                if (BCrypt.Net.BCrypt.Verify(password, hash))
                //if (usr.password == hash)
                {
                    if (user.logins == 0 && user.username.Equals("admin"))
                    {
                        jsh.addAlert("warning", "This is your first login, don't forget to change your password.");
                        jsh.addAlert("success", "Go to Settings to add your first board.");
                    }

                    tkdao.SetUserToken(user, expires);

                    user.logins = user.logins + 1;
                    user.last_login = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                    Update(user);

                    actdao.logAction(user.username + " logged in.", null, null);
                    jsr.message = "Login successful.";
                    jsr.data = (string)tkdao.GetTokenUser(user.id);
                    //$app->response->setStatus(200);
                }

            }
            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> logout(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
                tkdao.ClearDbToken(authorization);
                jsr.message = "Logout complete.";
                user = GetUser(authorization);
                actdao.logAction(user.username + " logged out.", null, null);
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UpdatePassword(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UpdateUsername(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UpdateEmail(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UpdateBoard(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> Actions(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UserCurrent(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UserCurrentOptions(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UserGetAll(string authorization)
        {
            Task<string> rt;

            if (tkdao.ValidateToken(authorization, false))
            {
                jsr.data = this.GetAll();
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UserCreate(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UserRemove(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }

        public Task<string> UserUpdate(string authorization)
        {
            Task<string> rt;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (tkdao.ValidateToken(authorization, false))
            {
            }

            return rt = Task<string>.Factory.StartNew(() => { return jsh.asJson(); });
        }
    }
}
