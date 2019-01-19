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
    // GET KEEPS BY VAULTID
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT* FROM vaultkeeps vk
    INNER JOIN keeps k ON k.id = vk.keepId
    WHERE(vaultId = @vaultId AND vk.userId = @userId)", new { vaultId, userId });
    }
    public Keep AddKeepByVaultId(Keep kp)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(userId, vaultId)
      VALUES(@UserId, @VaultId);
      SELECT LAST_INSERT_ID();
      ", kp);
      kp.Id = id;
      return kp;
    }
    public bool DeleteKeepByVaultId(Keep kp)
    {
      int success = _db.Execute(@"DELETE FROM Keeps WHERE userId = @UserId AND vaultId = @VaultId", kp);
      return success != 0;

    }
  }
}