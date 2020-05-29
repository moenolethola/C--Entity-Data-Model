using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class PolicyData
    {
        SqlConnection dbConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Tsubila Business Solutions\_SYSTEMS\_BolepoIntegratedManagementSystem.master\integratedmanagementsystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");


        // Constructors
        public PolicyData()
        {
        }

        public PolicyData(Entity.Policy policyObject)
        {
        }

        // Methods
        public int createPolicy(Entity.Policy policyObject)
        {
            int noOfRowsAffected = 0;

            try
            {
                SqlCommand dbCommand = new SqlCommand("createPolicy", dbConnection);
                dbCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters
                dbCommand.Parameters.Add("@No", SqlDbType.NChar, 8).Value = policyObject.No;
                dbCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = policyObject.Name;
                dbCommand.Parameters.Add("@Description", SqlDbType.Text).Value = policyObject.Description;
                dbCommand.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = policyObject.Type;
                dbCommand.Parameters.Add("@Target_group", SqlDbType.NVarChar, 50).Value = policyObject.Target_group;
                dbCommand.Parameters.Add("@Originator", SqlDbType.NVarChar, 20).Value = policyObject.Originator;
                dbCommand.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = policyObject.Author;
                dbCommand.Parameters.Add("@Approver", SqlDbType.NVarChar, 20).Value = policyObject.Approver;
                dbCommand.Parameters.Add("@Date_created", SqlDbType.DateTime).Value = policyObject.Date_created;
                dbCommand.Parameters.Add("@Approval_date", SqlDbType.DateTime).Value = policyObject.Approval_date;
                dbCommand.Parameters.Add("@Effective_date", SqlDbType.DateTime).Value = policyObject.Effective_date;

                dbConnection.Open();
                noOfRowsAffected = dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
            catch (Exception exception)
            {               
                throw exception;
            }

            return noOfRowsAffected;
        }

        public DataSet selectPolicyByNo(Entity.Policy policyObject)
        {
            DataSet policyData = new DataSet();

            try
            {
                SqlCommand dbCommand = new SqlCommand("selectPolicyByNo", dbConnection);
                dbCommand.CommandType = CommandType.StoredProcedure;

                // Add command parameters
                dbCommand.Parameters.Add("@Policy_no", SqlDbType.NChar, 8).Value = policyObject.No;

                SqlDataAdapter policyDataAdapter = new SqlDataAdapter(dbCommand);
                policyDataAdapter.Fill(policyData);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            return policyData;
        }

        public DataSet selectPolicyByType(Entity.Policy policyObject)
        {
            DataSet policiesData = new DataSet();

            try
            {
                SqlCommand dbCommand = new SqlCommand("selectPoliciesByType", dbConnection);
                dbCommand.CommandType = CommandType.StoredProcedure;

                // Add command parameters
                dbCommand.Parameters.Add("@Policy_type", SqlDbType.NVarChar, 50).Value = policyObject.Type;

                SqlDataAdapter policyDataAdapter = new SqlDataAdapter(dbCommand);
                policyDataAdapter.Fill(policiesData);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            return policiesData;
        }

        public DataSet selectPolicies(Entity.Policy policyObject)
        {
            DataSet policiesData = new DataSet();

            try
            {
                SqlCommand dbCommand = new SqlCommand("selectPolicies", dbConnection);
                dbCommand.CommandType = CommandType.StoredProcedure;
                                
                SqlDataAdapter policyDataAdapter = new SqlDataAdapter(dbCommand);
                policyDataAdapter.Fill(policiesData);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            return policiesData;
        }

        public string generateNewPolicyNo(Entity.Policy policyObject)
        {
            string newPolicyNo = "";
            int currentYear = DateTime.Now.Year;

            try
            {
                // Create sql command
                SqlCommand dbCommand = new SqlCommand("SELECT COUNT(*) FROM tbl_policy WHERE date_created LIKE '%" + currentYear + "%'", dbConnection);
                                
                dbConnection.Open();
                
                int noOfPoliciesCreatedThisYear = (int)dbCommand.ExecuteScalar();
                noOfPoliciesCreatedThisYear++;

                dbConnection.Close();
                
                // Determine policy no.                
                if (noOfPoliciesCreatedThisYear < 10)
                    newPolicyNo = currentYear + "000" + noOfPoliciesCreatedThisYear;
                else if (noOfPoliciesCreatedThisYear < 100)
                    newPolicyNo = currentYear + "00" + noOfPoliciesCreatedThisYear;
                else if (noOfPoliciesCreatedThisYear < 1000)
                    newPolicyNo = currentYear + "0" + noOfPoliciesCreatedThisYear;
                else
                    newPolicyNo = currentYear + "" + noOfPoliciesCreatedThisYear;                
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return newPolicyNo;
        }

        public int policyExists(Entity.Policy policyObject)
        {
            int count = 0;

            try
            {
                // Create sql command
                SqlCommand dbCommand = new SqlCommand("policyExists", dbConnection);
                dbCommand.CommandType = CommandType.StoredProcedure;

                // Add command parameters
                dbCommand.Parameters.Add("@Policy_no", SqlDbType.NChar, 8).Value = policyObject.No;

                dbConnection.Open();

                count = (int)dbCommand.ExecuteScalar();
                
                dbConnection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return count;
        }

        public int checkOwnPolicy(Entity.Employee employeeObject, Entity.Policy policyObject)
        {
            int count = 0;

            try
            {
                // Create sql command
                SqlCommand dbCommand = new SqlCommand("checkOwnPolicy", dbConnection);
                dbCommand.CommandType = CommandType.StoredProcedure;

                // Add command parameters
                dbCommand.Parameters.Add("@Employee_id", SqlDbType.NVarChar, 20).Value = employeeObject.Employee_id;
                dbCommand.Parameters.Add("@Policy_no", SqlDbType.NChar, 8).Value = policyObject.No;

                dbConnection.Open();

                count = (int)dbCommand.ExecuteScalar();

                dbConnection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return count;
        }
    }
}
