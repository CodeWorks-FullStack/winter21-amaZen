using System;
using System.ComponentModel.DataAnnotations;

namespace amaZen.Models
{
  public class Product
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public string Sku { get; set; }
    public string Description { get; set; }
  }
}