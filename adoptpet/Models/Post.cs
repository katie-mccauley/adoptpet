using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adoptpet.Models
{
  public class Post
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Type { get; set; }
    public string Img { get; set; }
    public string Description { get; set; }
    public int Offers { get; set; }
    public int Views { get; set; }
    public Profile Creator { get; set; }
  }
}