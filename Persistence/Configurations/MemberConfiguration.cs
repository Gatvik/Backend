using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Member = Domain.Member;

namespace Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Domain.Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasData(
            // new Member()
            // {
            //     Id = 1,
            //     IdentityId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
            //     FirstName = "Admin",
            //     LastName = "Adminovich",
            //     DateOfBirth = new DateOnly(2003,11,13)
            // },
            new Member()
            {
                Id = 1,
                IdentityId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                FirstName = "User",
                LastName = "Userovich",
                Sex = "Male",
                DateOfBirth = new DateOnly(2004,1,9)
            }
        );
    }
}