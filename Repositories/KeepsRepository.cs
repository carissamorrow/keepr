using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;

    }

    //GetAll
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Keep");
    }

    //GetById

    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keep WHERE id = @id", new { id });
    }

    //GetByUserId
    public IEnumerable<Keep> GetByUserId(int id)
    {
      // new id object is an anonymous object and @id pulls the property off of it
      return _db.Query<Keep>("SELECT * FROM Keep WHERE userId = @id", new { id });
    }


    //AddKeep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(name, description, img, userId, viewing, keeping, sharing)
      VALUES(@Name, @Description, @Img, @UserId, @Viewing, @Keeping, @Sharing);
      SELECT LAST_INSERT_ID();
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    //DeleteKeep

    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"DELETE FROM Keep WHERE id = @id", new { id });
      return success != 0;

    }


  }
}