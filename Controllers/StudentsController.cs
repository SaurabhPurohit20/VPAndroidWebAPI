using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
	public class StudentsController : ApiController
	{
		static string cs = ConfigurationManager.ConnectionStrings["db_studentsConnectionString"].ConnectionString;
		StudentsDataClassesDataContext db = new StudentsDataClassesDataContext(cs);

		[HttpGet]
		[Route("api/add_student")]
		public IHttpActionResult demo([FromUri] string name)
		{
			db.tbl_student2s.InsertOnSubmit(new tbl_student2
			{
				name= name
			});
			db.SubmitChanges();

			var v = "Name: "+name+" Added Successfully";
			return Json(v);
		}
		[HttpGet]
		[Route("api/get_students")]
		public IHttpActionResult getStudents()
		{
			var v=db.tbl_student2s;
			return Json(v);
		}
	}
}