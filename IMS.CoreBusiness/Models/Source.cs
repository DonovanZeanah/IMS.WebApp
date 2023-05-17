using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public enum SourceDiscriminator
    {
        LocationSource,
        StoreSource,
        ContactSource,
        SelfObtainedSource
    }
    public abstract class Source
    {
        public int Id { get; set; }
        public string? Name { get; set; }
      //  public int DiscriminatorId { get; set; }
      //  public SourceDiscriminator? DiscriminatorId { get; set; }

        public virtual ICollection<Inventory>? InventorySources { get; set; }

        // Add other common properties if needed
    }
    public class LocationSource : Source
    {
        public string? Address { get; set; }
        //public string? 
        // Add other location-specific properties
    }

    public class StoreSource : Source
    {
        public string? StoreName { get; set; }
        // Add other store-specific properties
    }

    public class ContactSource : Source
    {
        public string? ContactName { get; set; }
        public string? PhoneNumber { get; set; }
        // Add other contact-specific properties
    }

    public class SelfObtainedSource : Source
    {   
       public string? Process { get; set; }
        // Add any self-obtained-specific properties if needed
    }

}
