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
    [HttpGet("{vaultId}")]
    public VaultKeep GetKeepsByVaultId(int id)
    {
      SELECT* FROM vaultkeeps vk;
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vaultId = @vaultId AND vk.userId = @userId)
    }
  }
}