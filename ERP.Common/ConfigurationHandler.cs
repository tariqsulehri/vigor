using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
    class ConfigurationHandler
    {
        private void InitConfigurationHandler()
        {
            
        }
    }
}


//private void InitConfigurationHandler()
//{
//    try
//    {
//        //get current connection name
//        var currentConnectionName = GetAppSettingsValueByKey("CurrentAppConnection");
//        if (string.IsNullOrEmpty(currentConnectionName))
//            throw new ConfigurationErrorsException(string.Format("No connection name exist in the current
//            app / web.config."));
//            ConnectionStringSettings connectionName = ConfigurationManager.ConnectionStrings[currentConnectio
//            nName];
//        if (connectionName == null)
//            throw new ConfigurationErrorsException(string.Format("Failed to find connection named '{0}' i
//            n app / web.config.", currentConnectionName));
//            _connectionString = connectionName.ConnectionString;
//        _connectionProvider = connectionName.ProviderName;
//        if (string.IsNullOrEmpty(_connectionString) || string.IsNullOrEmpty(_connectionProvider))
//            throw new ConfigurationErrorsException(string.Format("The Connection String and/or the Data P
//            rovider can't be found in app/web.config."));
//    }
//    catch (Exception ex)
//    {
//        // some error occured. Bubble it to caller and encapsulate Exception object
//        throw new Exception("ConfigurationHandler::InitConfigurationHandler::Error occured.", ex);
//    }
//}
///// <summary>
///// Purpose: ConfigurationHandler class constructor
///// </summary>
//public ConfigurationHandler()
//{
//    InitConfigurationHandler();
//}
//public string GetAppSettingsValueByKey(string sKey)
//{
//    try
//    {
//        if (string.IsNullOrEmpty(sKey))
//            throw new ArgumentNullException("sKey", "The AppSettings key name can't be Null or Empty.");
//        if (ConfigurationManager.AppSettings[sKey] == null)
//            throw new ConfigurationErrorsException(string.Format("Failed to find the AppSettings Key name
//            d '{0}' in app / web.config.", sKey));
//    return ConfigurationManager.AppSettings[sKey].ToString();
//    }
//    catch (Exception ex)
//    {
//        //bubble error.
//        throw new Exception("ConfigurationHandler::GetAppSettingsValueByKey:Error occured.", ex);
//    }
//}
