using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using System.Collections.Generic;
using keepr.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class KeepController : ControllerBase
  {
    private readonly KeepsRepository _repo;
    public KeepController(KeepsRepository repo)
    {
      _repo = repo;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_repo.GetAll());
    }
    [Authorize]
    [HttpGet("{id}")]

    public ActionResult<Keep> Get(int id)
    {
      Keep result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep keep)
    {
      keep.UserId = HttpContext.User.Identity.Name;
      Keep result = _repo.AddKeep(keep);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest("Unable to post");
    }
    [Authorize]
    [HttpDelete("{id}")]

    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteKeep(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
    // PUT api/keep
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      Keep result = _repo.GetOneByIdAndUpdate(id, value);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

  }
}
