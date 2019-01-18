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

    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep keep)
    {
      return _repo.AddKeep(keep);
    }
    //delete
    // [Authorize]
    [HttpDelete("{id}")]
    public void Delete([FromRoute] int id)
    {
      _repo.DeleteKeep(id);
    }
  }
}
