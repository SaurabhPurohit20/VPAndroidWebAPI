using System;
using System.Configuration;
using System.Linq;
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

		[HttpPost]
		[Route("api/change_students")]
		public IHttpActionResult changeStudents([FromBody] dynamic data)
		{
			string id = data.id;
			var v=db.tbl_student2s.Where(x=>x.id==Convert.ToInt32(id)).Single();
			v.name = data.name;
			db.SubmitChanges();

			string r = "Change Successfully Id: "+id+" Name: " + v.name;
			return Json(r);
		}

		[HttpPost]
		[Route("api/remove_student")]
		public IHttpActionResult deleteStudents([FromBody] dynamic data)
		{
			string id = data.id;
			var v=db.tbl_student2s.Where(x=>x.id==Convert.ToInt32(id)).Single();
			db.tbl_student2s.DeleteOnSubmit(v);
			db.SubmitChanges();

			string r = "Deleted Successfully Id: "+id+" Name: " + v.name;
			return Json(r);
		}

		[HttpGet]
		[Route("api/student_details")]
		public IHttpActionResult getDetails()
		{
			var v=db.tbl_student_datas
				.Select(x=>new { 
					x.id,
					x.address,
					x.mobile,
					x.tbl_student2.name,
					id2=x.tbl_student2.id
				});

			return Json(v);
		}
	}
}