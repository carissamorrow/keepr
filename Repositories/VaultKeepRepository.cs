using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;

    }
    public VaultKeep GetKeepsByVaultId(int id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>($"SELECT * FROM vaultkeeps WHERE id = @id", new { id });
    }
  }
}