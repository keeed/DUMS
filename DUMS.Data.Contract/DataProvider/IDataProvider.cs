using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUMS.Data.Contract.UserManagement.Services;

namespace DUMS.Data.Contract.DataProvider
{
    public interface IDataProvider
    {
        /// <summary>
        /// Connects to the data source.
        /// </summary>
        /// <param name="connectionString">Connection string to the data source.</param>
        /// <returns>Boolean value to indicate if the connection was successful.</returns>
        bool Connect(string connectionString);
    }
}
