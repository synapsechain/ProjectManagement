using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Api.Data.Entities
{
    public abstract class BaseIdEntity
    {
        public long Id { get; set; }
    }
    
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseIdEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
