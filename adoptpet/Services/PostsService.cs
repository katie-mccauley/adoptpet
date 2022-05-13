using System;
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

    internal Post GetById(int id)
    {
      Post post = _repo.GetById(id);
      if (post == null)
      {
        throw new Exception("No post by that id");
      }
      else
      {
        return post;
      }
    }

    internal string Remove(int id, string userId)
    {
      Post original = GetById(id);
      if (userId != original.CreatorId)
      {
        throw new Exception("you can't deldte something that isnt yours");
      }
      return _repo.Remove(id);
    }

    internal List<Comment> GetCommentsByPostId(int id, string userId)
    {
      Post found = GetById(id);
      if (found == null)
      {
        throw new Exception("can't find the post");
      }
      else
      {
        return _repo.GetCommentsByPostId(id);
      }

    }
  }
}