using System;
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
      return _db.Query<Keep>("SELECT * FROM Keeps");
    }

    //GetById

    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
      //had as select from Keep. should be keep or keeps? 
    }

    //GetByUserId
    public IEnumerable<Keep> GetByUserId(int id)
    {

      return _db.Query<Keep>("SELECT * FROM Keeps WHERE userId = @id", new { id });
    }


    //AddKeep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(name, description, img, userId, views, keeps, shares)
      VALUES(@Name, @Description, @Img, @UserId, @Views, @Keeps, @Shares);
      SELECT LAST_INSERT_ID();
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"DELETE FROM Keeps WHERE id = @id", new { id });
      return success != 0;
    }
    public Keep GetOneByIdAndUpdate(int id, Keep newkeep)
    {
      {
        return _db.QueryFirstOrDefault<Keep>($@"
               UPDATE Keeps SET
                   Views = @Views,
                   Shares = @Shares,
                   Keeps = @Keeps
               WHERE Id = {id};
               SELECT * FROM Keeps WHERE id = {id};", newkeep);
      }
    }
  }
}