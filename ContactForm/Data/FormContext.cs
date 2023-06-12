using ContactForm.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactForm.Data
{
    public class FormContext : DbContext
    {
        public FormContext(DbContextOptions<FormContext> options) :base(options)

        {

        }
        public DbSet<Customer> Persondets { get; set; }
        public DbSet<PhoneContact> Phonedets { get; set; }

    }
}
