using InGreed_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using InGreed_API.Enums;

namespace InGreed_API.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Column names
            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Username)
                .HasColumnName("username");

            builder.Property(u => u.Mail)
                .HasColumnName("mail");

            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash");

            builder.Property(u => u.Role)
                .HasColumnName("role");

            builder.Property(u => u.EmailNotifications)
                .HasColumnName("email_notifications");

            // Property types
            builder.Property(u => u.EmailNotifications)
                .HasColumnType("bit");

            // Default values
            var passwordHasher = new PasswordHasher<User>();

            var users = new List<User>()
            {
                new User() { Id = 1, Username =  "client", Mail = "clientingreed@gmail.com", Role = UserRoleEnum.Client, EmailNotifications = true, PasswordHash = "AQAAAAIAAYagAAAAECFziXNCSrKgVQUGu4Ius9In7O1dytR+XOgViy8cOrwqdwj6zcjrRJOBS/vPAPJjZg=="},
                new User() { Id = 2, Username =  "client2", Mail = "clientingreed2@gmail.com", Role = UserRoleEnum.Client, EmailNotifications = false, PasswordHash  = "AQAAAAIAAYagAAAAEFMl2ibmxljVgSYUvel1WmE+iB7IbRjl8QeWhf1fA0bhaR0TSaGEwETnWj2z/SjbfA=="},
                new User() { Id = 3, Username =  "producent", Mail = "producent@gmail.com", Role = UserRoleEnum.Producent, EmailNotifications = true, PasswordHash = "AQAAAAIAAYagAAAAEMzfRediqiZFTiV6Xpz38DYmSUDq3j5hmqbaaTbBrbLVWThkHKG508Iznr/bca8uWg==" },
                new User() { Id = 4, Username =  "producent2", Mail = "producentingreed2@gmail.com", Role = UserRoleEnum.Producent, EmailNotifications = false, PasswordHash = "AQAAAAIAAYagAAAAEIFvpaWPRcE+iakhC6p4hHrmq0EOmt3id7vIPU3iMZjNM7aTuAJVsv3yxtLzgG1KHQ=="},
                new User() { Id = 5, Username =  "admin", Mail = "admin@gmail.com", Role = UserRoleEnum.Administrator, EmailNotifications = false, PasswordHash = "AQAAAAIAAYagAAAAECFziXNCSrKgVQUGu4Ius9In7O1dytR+XOgViy8cOrwqdwj6zcjrRJOBS/vPAPJjZg=="},

            };
            
            builder.HasData(users);
        }
    }
}
