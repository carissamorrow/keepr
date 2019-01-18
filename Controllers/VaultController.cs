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
  public class VaultController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultController(VaultRepository repo)
    {
      _repo = repo;
    }
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault vault)
    {
      Vault result = _repo.AddVault(vault);
      return Created("/api/vault/" + result.Id, result);
    }
    [Authorize]
    [HttpDelete("{id}")]

    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteVault(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}