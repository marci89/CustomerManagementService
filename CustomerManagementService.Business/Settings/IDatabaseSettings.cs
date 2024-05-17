using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementService.Business
{
	/// <summary>
	/// Interface describing database settings
	/// </summary>
	public interface IDatabaseSettings
	{
		/// <summary>
		/// Connection String for database
		/// </summary>
		string ConnectionString { get; }

		/// <summary>
		/// Whether to enable automatic database schema update (migration update)
		/// </summary>
		bool AutoMigrationEnabled { get; }
	}
}
