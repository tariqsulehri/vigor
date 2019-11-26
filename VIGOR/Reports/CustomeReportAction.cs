using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Common;

namespace VIGOR.Reports
{
    public class CustomeReportAction : ActionResult
    {
        private readonly byte[] _contentBytes;

        public CustomeReportAction(ReportDocument reportDocument)
        {
            _contentBytes = StreamToBytes(reportDocument.ExportToStream(ExportFormatType.PortableDocFormat));
        }

        public CustomeReportAction(string reportPath)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(reportPath);

            _contentBytes = StreamToBytes(reportDocument.ExportToStream(ExportFormatType.PortableDocFormat));
        }
        public override void ExecuteResult(ControllerContext context)
        {

            var response = context.HttpContext.ApplicationInstance.Response;
            response.Clear();
            response.Buffer = false;
            response.ClearContent();
            response.ClearHeaders();
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.ContentType = "application/pdf";

            using (var stream = new MemoryStream(_contentBytes))
            {
                stream.WriteTo(response.OutputStream);
                stream.Flush();
            }
        }

        private static byte[] StreamToBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static ReportDocument SetUsersInfo(String source)
        {
            ConnectionInfo crconnectioninfo = new ConnectionInfo();
            ReportDocument cryrpt = new ReportDocument();
            TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
            Tables CrTables;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigSettings.ConnectionString);
            String ServerName = builder.DataSource;
            String Database = builder.InitialCatalog;
            String UserID = builder.UserID;
            String Password = builder.Password;

            crconnectioninfo.ServerName = ServerName;
            crconnectioninfo.DatabaseName = Database;
            crconnectioninfo.UserID = UserID;
            crconnectioninfo.Password = Password;
            cryrpt.Load(source.ToString());
            CrTables = cryrpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }

            cryrpt.Refresh();
            return cryrpt;
        }
    }
}

