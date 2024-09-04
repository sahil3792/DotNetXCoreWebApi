using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Data;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpController : ControllerBase
	{
		private readonly ApplicationDbContext db;
		public EmpController(ApplicationDbContext db)
		{
			this.db = db;		
		}


		[Route("AddEmp")]
		[HttpPost]
		public IActionResult AddNewEmp(Emp e)
		{
			db.Employees.Add(e);
			db.SaveChanges();
			return Ok("Emp Add Succesfully!!");
		}

		[Route("GetEmps")]
		[HttpGet]
		public IActionResult GetAllEmpData()
		{ 
			var d = db.Employees.ToList();
			return Ok(d);
		}

		[Route("DelEmp/{id}")]
		[HttpDelete]
		public IActionResult DeleteEmp(int id)
		{
			var data = db.Employees.Find(id);
			db.Employees.Remove(data);
			db.SaveChanges();
			return Ok("Emp Delete Succesfully");
		}

		[Route("UpdateEmp")]
		[HttpPut]
		public IActionResult UpdateEmp(Emp e)
		{
			db.Employees.Update(e);
			db.SaveChanges();
			return Ok("Emp Updated Succesfully");
		}

		[Route("DeleteMutiple")]
		[HttpDelete]
		public IActionResult DeleteMultiple(List<int> emp)
		{
			var data =db.Employees.Where(x=>emp.Contains(x.Id)).ToList();
			db.Employees.RemoveRange(data);
			db.SaveChanges();
			return Ok("Employees Delete Sucessfully");
		}

		[Route("SearchByName/{search}")]
		[HttpGet]
		public IActionResult SearchByName(string search)
		{
			var data = db.Employees.Where(x => search.Contains(x.Name) || search.Contains(x.Dept) || search.Contains(x.Salary.ToString()));
			return Ok(data);
		}
	}
}
