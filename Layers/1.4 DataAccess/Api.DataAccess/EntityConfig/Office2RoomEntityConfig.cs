using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.EntityConfig
{
    public class Office2RoomEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Office2RoomsEntity> entityBuilder)
        {
            entityBuilder
                .ToTable("Office2Room");

            entityBuilder
                .HasOne(x => x.Office)
                .WithMany(x => x.Office2Room)
                .HasForeignKey(x => x.OfficeId);

            entityBuilder
                .HasOne(x => x.Room)
                .WithMany(x => x.Office2Room)
                .HasForeignKey(x => x.RoomId);

            entityBuilder
                .HasKey(x => new { x.OfficeId, x.RoomId });

            entityBuilder
                .Property(x => x.OfficeId)
                .IsRequired();

            entityBuilder
                .Property(x => x.RoomId)
                .IsRequired();
        }
    }
}