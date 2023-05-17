using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int InventoryId { get; set; } = 0;
        public string? InventoryName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double? Price { get; set; }

        #region ===[ Source - Entity Relationship ]=============================================================

        public ICollection<InventorySource>? InventorySources { get; set; } // Updated navigation property
        //public ICollection<InventoryDiscriminator> InventoryDiscriminators { get; set; } // Updated navigation property


        #endregion
    }
}





