using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
	public class DefaultController : ApiController
	{
		public class UserLoginRequest
		{
			public string name { get; set; }
			public string pass { get; set; }
		}

		[HttpPost]
		[Route("api/login")]
		public IHttpActionResult userlogin([FromBody] UserLoginRequest ulr)
		{
			object obj;
			try
			{
				if (ulr.name == "Saurabh" && ulr.pass == "2308") { obj = new { e = false, d = "Login Successful" }; }
				else { obj = new { e = false, d = "Login Failed" }; }
			}
			catch (Exception ex) { obj = new { e = true, d = "Error " + ex.Message }; }
			return Json(obj);
		}

		[HttpGet]
		[Route("api/demo")]
		public IHttpActionResult demo()
		{//[FromBody] dynamic param
			var v = new { name = "Android", mobile = "1234567890" };
			return Json(v);
		}
		[HttpGet]
		[Route("api/employees")]
		public IHttpActionResult employees([FromUri] int size, [FromUri] string name)
		{
			List<object> data = new List<object>();
			for (int i = 1; i <= size; i++)
			{
				data.Add(new
				{
					id = i,
					employee_name = name + " " + i,
					employee_salary = 320800 + i,
					employee_age = 20 + i,
					profile_image = ""
				});
			}

			var v = new
			{
				status = "success",
				data,
				message = "Successfully! All records has been fetched."
			};
			return Json(v);
		}
	}
}
