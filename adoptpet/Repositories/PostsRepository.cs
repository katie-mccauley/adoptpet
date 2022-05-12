using System.Data;
using adoptpet.Models;
using Dapper;

namespace adoptpet.Repositories
{
  public class PostsRepository
  {
    private readonly IDbConnection _db;

    public PostsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Post Create(Post postData)
    {
      string sql = @"
      INSERT INTO posts
      (description, img, type, views, offers, creatorId)
      VALUES 
      (@Description, @Img, @Type, @Views, @Offers, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, postData);
      postData.Id = id;
      return postData;
    }
  }
}