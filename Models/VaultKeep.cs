using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    public string UserId { get; set; }
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    public bool IsPrivate { get; set; }


  }
}