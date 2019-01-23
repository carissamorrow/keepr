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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }

    // GET KEEPS BY VAULTID
    [Authorize]
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<VaultKeep>> GetKeepsByVaultId(int vaultId)
    {
      var uId = HttpContext.User.Identity.Name;
      return Ok(_repo.GetKeepsByVaultId(vaultId, uId));
      // return list of keeps with the userID and VaultID
    }
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep kp)
    {
      kp.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddKeepByVaultId(kp);
      return Created("/api/vaultkeep/" + result.Id, result);
    }

  }
}