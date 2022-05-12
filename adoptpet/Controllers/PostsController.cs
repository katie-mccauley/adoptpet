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

    public PostsController(PostsService ps)
    {
      _ps = ps;
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
  }
}