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
    public int KeepId { get; set; }
    [Required]
    public int VaultId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }


  }
}