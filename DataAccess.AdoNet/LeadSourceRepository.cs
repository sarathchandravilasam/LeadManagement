using Configuration;
using Domain;
using Domain.Abstract.Entities;
using Domain.Abstract.Repository;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.AdoNet
{
    public class LeadSourceRepository : ILeadSourceRepository
    {
        SqlConnection _sqlConnection;
        AppSettings _appSettings;

        public LeadSourceRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
            _sqlConnection = new SqlConnection(_appSettings.SqlConnectionString);
        }

        public ILeadSource GetLeadSourceById(int id)
        {
            DataSet ds = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("spGetLeadSourceById", _sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@pSourceId", id);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(ds);
            DataRow row = ds.Tables[0].Rows[0];
            ILeadSource leadSource = new LeadSource
            {
                SourceId = Int32.Parse(row["SourceId"].ToString()),
                Source = row["Source"].ToString(),
                Description = row["Description"].ToString()
            };
            return leadSource;
        }

        public List<ILeadSource> GetLeadSources()
        {
            SqlDataAdapter da = new SqlDataAdapter("spSelectLeadSource", _sqlConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<ILeadSource> leadSources = new List<ILeadSource>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ILeadSource leadSource = new LeadSource
                {
                    SourceId = Int32.Parse(item["SourceId"].ToString()),
                    Source = item["Source"].ToString(),
                    Description = item["Description"].ToString()
                };
                leadSources.Add(leadSource);
            }
            return leadSources;
        }

        public void InsertLeadSource(ILeadSource leadSource)
        {
            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("spInsertLeadSource", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pSource", leadSource.Source);
            cmd.Parameters.AddWithValue("@pDescription", leadSource.Description);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            _sqlConnection.Close();
        }
    }
}
