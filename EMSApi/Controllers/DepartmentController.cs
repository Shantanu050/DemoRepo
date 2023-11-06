using EMSApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EMSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController:ControllerBase
    {
      IDept repo;
      public DepartmentController(IDept _repo)
      {
        repo=_repo;
      }

      [HttpGet]
      [Route("ListDept")]
      public IActionResult GetDept()
      {
        var data=repo.GetDepartments();
        return Ok(data);
      }

      [HttpPost]
      [Route("Create")]
      public IActionResult PostDept(Department department)
      {
        if(ModelState.IsValid)
        {
            repo.AddDept(department);
            return Created("Record created",department);
        }
        return BadRequest();
      }

      [HttpGet]
      [Route("ListDept/{id}")]
      public IActionResult GetDept(int id)
      {
        var data=repo.FindDept(id);
        return Ok(data);
      }

      [HttpPut]
      [Route("EditDept/{id}")]
      public IActionResult PutDept(int id , Department dept)
      {
        repo.EditDept(dept);
        return Ok();
      }

      [HttpDelete]
      [Route("DeleteDept/{id}")]
      public IActionResult DeleteDept(int id)
      {
        repo.DeleteDept(id);
        return Ok();
      }
    }
}