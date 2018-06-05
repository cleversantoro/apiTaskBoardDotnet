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
    public class ActivityDao : BaseDao, IBaseDao<Activity> 
    {
        private Activity activity;

        public ActivityDao(IConfiguration config)
        {
            _configuracoes = config;
            activity = new Activity();
        }

        #region CRUD Operations
        public List<Activity> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                List<Activity> activities = new List<Activity>();
                activities = conexao.GetAll<Activity>().ToList();
                return activities;
            }
        }

        public Activity GetById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                Activity usr = new Activity();
                usr = conexao.Get<Activity>(id);
                return usr;
            }
        }

        public void Update(Activity activity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Update(new Activity
                {
                    id = activity.id,
                    comment = activity.comment,
                    item_id = activity.item_id,
                    new_value = activity.new_value,
                    old_value = activity.old_value,
                    timestamp = activity.timestamp,
                });
            }
        }

        public void Insert(Activity activity)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();

                conexao.Insert(new Activity
                {
                    id = 0,
                    comment = activity.comment,
                    item_id = activity.item_id,
                    new_value = activity.new_value,
                    old_value = activity.old_value,
                    timestamp = activity.timestamp,
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_configuracoes.GetConnectionString("TaskBoardDatabase")))
            {
                conexao.Open();
                conexao.Insert(new Activity { id = id });
            }
        }
        #endregion

        public void logAction(string comment, string oldValue, string newValue, int itemId = 0)
        {
            activity.comment = comment;
            activity.old_value = JsonConvert.SerializeObject(oldValue);
            activity.new_value = JsonConvert.SerializeObject(newValue);
            activity.timestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            activity.item_id = itemId;
            Insert(activity);
        }

    }
}
