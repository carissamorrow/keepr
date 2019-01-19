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
  public class VaultKeepController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepController(VaultKeepRepository repo)
    {
      _repo = repo;
    }

    // GET KEEPS BY VAULTID
    [Authorize]
    [HttpGet("{id}")]
    public IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      var uId = HttpContext.User.Identity.Name;
      _repo.GetKeepsByVaultId(id, uId);
      return new List<Keep>();
      // return list of keeps with the userID and VaultID
    }

  }
}