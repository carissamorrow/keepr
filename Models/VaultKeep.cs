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
    public string KeepId { get; set; }
    [Required]
    public string VaultId { get; set; }


  }
}