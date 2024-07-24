﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Product Name is required.")]
    public String? ProductName { get; set; } = String.Empty;
    [Required(ErrorMessage = "Price is required.")]
    public decimal Price { get; set; }
}
