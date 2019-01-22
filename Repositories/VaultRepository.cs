using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;

    }

    //GetById

    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vaults WHERE id = @id", new { id });
    }

    //GetAll
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Vaults");
    }

    //GetByUserId
    public IEnumerable<Vault> GetByUserId(int id)
    {

      return _db.Query<Vault>("SELECT * FROM Vaults WHERE userId = @id", new { id });
    }


    //AddVault
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Vaults(name, description, userId)
      VALUES(@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();
      ", newVault);
      newVault.Id = id;
      return newVault;
    }

    public bool DeleteVault(int id)
    {
      int success = _db.Execute(@"DELETE FROM Vaults WHERE id = @id", new { id });
      return success != 0;
    }
  }
}