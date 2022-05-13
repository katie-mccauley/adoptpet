using System;
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

    internal Comment GetById(int id)
    {
      return _repo.GetById(id);
    }

    internal string Remove(int id, string userId)
    {
      Comment found = GetById(id);
      if (found.CreatorId != userId)
      {
        throw new Exception("You can't delete something that isn't yours");
      }
      else
      {
        return _repo.Remove(id);
      }

    }
  }
}