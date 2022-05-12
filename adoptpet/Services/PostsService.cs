using System.Collections.Generic;
using adoptpet.Models;
using adoptpet.Repositories;

namespace adoptpet.Services
{
  public class PostsService
  {
    private readonly PostsRepository _repo;

    public PostsService(PostsRepository repo)
    {
      _repo = repo;
    }

    internal Post Create(Post postData)
    {
      return _repo.Create(postData);
    }

    internal List<Post> GetAllPosts()
    {
      return _repo.GetAllPosts();
    }
  }
}