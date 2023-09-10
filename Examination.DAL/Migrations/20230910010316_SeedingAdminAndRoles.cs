using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdminAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var Admin = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()

            };

            var User = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "User".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()

            };


            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

               values: new object[] { Admin.Id, Admin.Name, Admin.NormalizedName, Admin.ConcurrencyStamp }
               );

            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

            values: new object[] { User.Id, User.Name, User.NormalizedName, User.ConcurrencyStamp }
            );


            var passwordHasher = new PasswordHasher<IdentityUser>();

            var Admin1 = new IdentityUser
            {
                UserName = "Admin",
                Email = "Admin@gmail.com",
                NormalizedUserName = "ADMIN1",
                NormalizedEmail = "ADMIN1@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            Admin1.PasswordHash = passwordHasher.HashPassword(Admin1, "Admin@123");


            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
                values: new object[] { Admin1.Id, Admin1.UserName, Admin1.NormalizedUserName, Admin1.Email, Admin1.NormalizedEmail, Admin1.EmailConfirmed, Admin1.PasswordHash, Admin1.SecurityStamp, Guid.NewGuid().ToString(), Admin1.PhoneNumberConfirmed, Admin1.TwoFactorEnabled, null, Admin1.LockoutEnabled, Admin1.AccessFailedCount }
            );
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { Admin1.Id, Admin.Id }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");
            migrationBuilder.Sql("DELETE FROM AspNetUsers");
            migrationBuilder.Sql("DELETE FROM AspNetUserRoles");
        }
    }
}
