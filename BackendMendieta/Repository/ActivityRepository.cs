using RichoM.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Model;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace Repository
{
    public class ActivityRepository
    {
        private Database<SqlConnection> db;

        public ActivityRepository(Database<SqlConnection> db)
        {
            this.db = db;
        }

        private Activity MapToEntity(DatabaseRowReader row)
        {
            var id = row.GetString("Id");
            var author = row.GetString("Author");
            var area= row.GetString("Area");
            var title = row.GetString("Title");
            return new Activity()
            {
                Id = id,
                Author = author,
                Area = area,
                Title = title
            };
        }

        public IEnumerable<Activity> GetAll()
        {
            return db
                .Query("SELECT Id, Author, Area, Title FROM Activity")
                .Select(MapToEntity);
        }

        public Activity GetById(string id)
        {
            var activity = db
                .Query("SELECT Id, Author, Area, Title FROM Activity " +
                "WHERE Id = @id")
                .WithParameter("@id", id)
                .First(MapToEntity);
            if (activity == null) return null;

            return activity;
        }

        public void Create(Activity activity)
        {
            db.TransactionDo(tr =>
            {
                var activityId = Guid.NewGuid();
                tr.NonQuery("INSERT INTO Activity (Id, Author, Area, Title) " +
                    "VALUES (@id, @author, @area, @title)")

                    .WithParameter("@id", activityId)
                    .WithParameter("@author", activity.Author)
                    .WithParameter("@area", activity.Area)
                    .WithParameter("@title", activity.Title)
                    .Execute();
            
            });
        }
    }
}
