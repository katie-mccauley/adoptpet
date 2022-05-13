using System.Data;
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
  }
}