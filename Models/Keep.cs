using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public string UserId { get; set; }
    public int Id { get; set; }
    public string Img { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public int Viewing { get; set; }
    public int Keeping { get; set; }
    public int Sharing { get; set; }
    public Keep(string userId, string img, string name, string description)
    {
      UserId = userId;
      Img = img;
      Name = name;
      Description = description;
      // public bool IsPrivate { get; set; } 
    }
  }
}
