using adoptpet.Models;
using adoptpet.Repositories;

namespace adoptpet.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;
    private readonly PostsService _ps;

    public CommentsService(CommentsRepository repo, PostsService ps)
    {
      _repo = repo;
      _ps = ps;
    }

    internal Comment Create(Comment commentData, string userId)
    {
      return _repo.Create(commentData);
    }
  }
}