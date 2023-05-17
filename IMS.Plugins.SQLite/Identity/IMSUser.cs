using Microsoft.AspNetCore.Identity;

namespace IMS.Plugins.SQLite.Identity
{
    public class IMSUser : IdentityUser, IEquatable<IMSUser>
    {
        // Your custom properties and methods go here

        public bool Equals(IMSUser other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals((IMSUser)obj);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }
}