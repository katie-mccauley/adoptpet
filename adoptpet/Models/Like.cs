namespace adoptpet.Models
{
  public class Like
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public int PostId { get; set; }
    public string ProfileId { get; set; }
    public int Amount { get; set; }

  }
}