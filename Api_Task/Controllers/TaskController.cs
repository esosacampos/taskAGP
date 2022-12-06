using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_Task.Controllers
{
    public class TaskController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.TaskRequest model)
        {
            using (Models.BD_TaskEntities db = new Models.BD_TaskEntities())
            {
                var oTask = new Models.TASK();
                oTask.title_task = model.title;
                oTask.description_task = model.description;
                oTask.end_date = model.end_date;
                oTask.start_date = model.start_date;
                oTask.priority_level = model.priority_level;
                db.TASK.Add(oTask);
                db.SaveChanges();
            }
            return Ok("Successful");
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Models.Request.TaskRequest> lst = new List<Models.Request.TaskRequest>();
            using (Models.BD_TaskEntities db = new Models.BD_TaskEntities())
            {
                lst = (from d in db.TASK
                      select new Models.Request.TaskRequest
                      {
                          idTask = d.task_id,
                          title = d.title_task,
                          description = d.description_task,
                          start_date = (DateTime?)d.start_date ?? DateTime.Now,
                          end_date = (DateTime?)d.end_date ?? DateTime.Now,
                          priority_level = d.priority_level
                      }).ToList();
            }
            return Ok(lst);
        }

        [HttpGet]
        public IHttpActionResult Get(int pId)
        {
            List<Models.Request.TaskRequest> lst = new List<Models.Request.TaskRequest>();
            using (Models.BD_TaskEntities db = new Models.BD_TaskEntities())
            {
                lst = (from d in db.TASK
                       where d.task_id == pId
                       select new Models.Request.TaskRequest
                       {
                           idTask = d.task_id,
                           title = d.title_task,
                           description = d.description_task,
                           start_date = (DateTime?)d.start_date ?? DateTime.Now,
                           end_date = (DateTime?)d.end_date ?? DateTime.Now,
                           priority_level = d.priority_level
                       }).ToList();
            }
            return Ok(lst);
        }
    }
}
