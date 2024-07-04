using GymV1.ModelsContextDTOs.Context;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;

namespace GymV1.Repositories.Implementations
{
    public class GymClassEquipmentRepository : RepositoryBase<GymclassEquipment>, IGymClassEquipmentRepository
    {
        public GymClassEquipmentRepository(GymContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void DeleteGCE(GymclassEquipment gymclassEquipment)
        {
            Delete(gymclassEquipment);
            SaveChanges();
        }
    }
}
