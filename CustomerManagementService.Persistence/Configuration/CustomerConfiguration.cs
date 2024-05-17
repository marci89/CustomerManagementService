using CustomerManagementService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementService.Persistence.Configuration
{
	/// <summary>
	/// Customer datatable configuration class
	/// </summary>
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		/// <summary>
		/// Customer datatable configuration
		/// </summary>
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customer");

			builder.HasKey(u => u.Id);

			builder.Property(u => u.Id)
				  .ValueGeneratedOnAdd()
				  .IsRequired();

			builder.Property(u => u.Category)
		   .IsRequired()
		   .HasDefaultValue(CustomerCategory.Residential)
		   .HasConversion(new EnumToStringConverter<CustomerCategory>());

			builder.Property(u => u.Identifier)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.HasIndex(u => u.Identifier)
				   .IsUnique(true);

			builder.Property(u => u.FirstName)
				   .HasMaxLength(100)
				   .IsRequired(false);

			builder.Property(u => u.LastName)
				   .HasMaxLength(100)
				   .IsRequired(false);

			builder.Property(u => u.ContactName)
				   .HasMaxLength(100)
				   .IsRequired(false);

			builder.Property(u => u.PhoneNumber)
			   .HasMaxLength(100)
			   .IsRequired(false);

			builder.Property(u => u.Address)
			   .HasMaxLength(100)
			   .IsRequired(false);
		}
	}
}