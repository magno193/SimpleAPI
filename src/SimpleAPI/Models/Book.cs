using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models
{
  public class Book
  {
    [Key]
    public Guid Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [StringLength(100)]
    public string Publisher { get; set; }

    [StringLength(100)]
    public string Author { get; set; }

    [StringLength(100)]
    public string Category { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
  }
}
