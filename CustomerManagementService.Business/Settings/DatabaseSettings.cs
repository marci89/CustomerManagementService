using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementService.Business
{
	/// <summary>
	/// Department responsible for database settings
	/// </summary>
	public class DatabaseSettings : IDatabaseSettings
	{
		public DatabaseSettings(IConfiguration configuration)
		{
			ConnectionString = configuration.GetSection("DatabaseSettings").GetValue<string>("ConnectionString");
			AutoMigrationEnabled = configuration.GetSection("DatabaseSettings").GetValue<bool>("AutoMigrationEnabled");

		}

		/// <summary>
		/// Connection String for database
		/// </summary>
		public virtual string ConnectionString { get; private set; }

		/// <summary>
		/// Whether to enable automatic database schema update (migration update)
		/// </summary>
		public virtual bool AutoMigrationEnabled { get; private set; }
	}
}