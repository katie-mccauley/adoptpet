using System;
using System.Data;
using System.Linq;
using adoptpet.Models;
using Dapper;

namespace adoptpet.Repositories
{
  public class CommentsRepository
  {
    private readonly IDbConnection _db;

    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Comment Create(Comment commentData)
    {
      string sql = @"
      INSERT INTO comments 
      (postId, body, creatorId)
      VALUES
      (@PostId, @Body, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, commentData);
      commentData.Id = id;
      return commentData;
    }

    internal Comment GetById(int id)
    {
      string sql = @"
      SELECT * FROM comments 
      WHERE id = @id;
      ";
      return _db.Query<Comment>(sql, new { id }).FirstOrDefault();
    }

    internal string Remove(int id)
    {
      string sql = @"
       DELETE FROM comments WHERE id = @id LIMIT 1;
      ";
      int rows = _db.Execute(sql, new { id });
      if (rows > 0)
      {
        return "post delted";
      }
      else
      {
        throw new Exception("There are no rows being affected");
      }
    }
  }
}