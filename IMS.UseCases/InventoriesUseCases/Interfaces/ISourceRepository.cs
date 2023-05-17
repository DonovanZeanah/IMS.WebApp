using IMS.CoreBusiness.Models;

namespace IMS.UseCases.InventoriesUseCases.Interfaces
{
    public interface ISQLiteBaseSourceRepository
    {
        //IEnumerable<SourceDiscriminator> GetAllSourceDiscriminators();
        //Task<IEnumerable<Source>> GetAllSources();
        Task<ICollection<Source>>? GetAllSourcesAsync();
    }
}