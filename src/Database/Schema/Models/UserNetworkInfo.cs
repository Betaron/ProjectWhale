using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schema.Models;
public class UserNetworkInfo
{
    public int UserId { get; set; }

    public required byte[] IpAddressBytes { get; set; }

    public DateTime UpdateTime { get; set; }

    [NotMapped]
    public IPAddress IPAddress
    {
        get => new IPAddress(IpAddressBytes);
        set => IpAddressBytes = value.GetAddressBytes();
    }

    /* navigation properties */
    public required User User { get; set; }

    internal class Map : IEntityTypeConfiguration<UserNetworkInfo>
    {
        public void Configure(EntityTypeBuilder<UserNetworkInfo> builder)
        {
            builder.HasKey(x => x.UserId);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.UserNetworkInfo)
                .HasForeignKey<UserNetworkInfo>(x => x.UserId);
        }
    }
}
