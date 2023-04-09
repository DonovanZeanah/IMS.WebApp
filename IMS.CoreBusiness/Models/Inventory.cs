﻿using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness.Models
{
    public class Inventory
    {

        [Required]
        public int InventoryId { get; set; }
        [Required]
        public string? InventoryName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than 0")]

        public double Price { get; set; }
    }
}