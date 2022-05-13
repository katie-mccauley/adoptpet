using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adoptpet.Models;
using adoptpet.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace adoptpet.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PostsController : ControllerBase
  {
    private readonly PostsService _ps;
    private readonly CommentsService _cs;

    public PostsController(PostsService ps, CommentsService cs)
    {
      _ps = ps;
      _cs = cs;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Post>> Create([FromBody] Post postData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        postData.CreatorId = userInfo.Id;
        Post post = _ps.Create(postData);
        post.Creator = userInfo;
        return Created($"api/posts/{post.Id}", post);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Post>> GetAllPosts()
    {
      try
      {
        List<Post> posts = _ps.GetAllPosts();
        return Ok(posts);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Post> GetById(int id)
    {
      try
      {
        return Ok(_ps.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/comments")]
    public async Task<ActionResult<List<Comment>>> GetCommentsByPostId(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        List<Comment> comments = _ps.GetCommentsByPostId(id, userInfo.Id);
        return Ok(comments);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return _ps.Remove(id, userInfo.Id);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}