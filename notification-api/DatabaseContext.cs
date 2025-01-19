using Microsoft.EntityFrameworkCore;
using notification_api.Email;

namespace notification_api;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<EmailModel> Emails { get; set; }
}