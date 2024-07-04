using GymV1.ModelsContextDTOs.Models;
using Microsoft.EntityFrameworkCore;

namespace GymV1.ModelsContextDTOs.Context
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) :base(options) { }

        //DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<GymClass> GymClasses { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<GymclassEquipment> GymClassEquipments { get; set; }
        public DbSet<GymClassMembership> gymClassMemberships { get; set; }

    }
}
