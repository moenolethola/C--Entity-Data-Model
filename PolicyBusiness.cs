using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Data;
using System.Data;

namespace Business
{
    public class PolicyBusiness
    {
        public int policyCreation(Entity.Policy policyObject)
        {
            Data.PolicyData policyData = new PolicyData(policyObject);

            return policyData.createPolicy(policyObject);
        }

        public int createPolicy(Entity.Policy policyObject)
        {
            Data.PolicyData policyData = new PolicyData(policyObject);

            return policyData.createPolicy(policyObject);
        }

        public DataSet policySummary(Entity.Policy policyObject)
        {
            Data.PolicyData policySummaryData = new PolicyData(policyObject);

            return policySummaryData.selectPolicies(policyObject);
        }

        public void getPolicyByNo(Entity.Policy policyObject)
        {
            Data.PolicyData policyData = new PolicyData(policyObject);
            DataSet policyDataSet = policyData.selectPolicyByNo(policyObject);
            
            // Set policy object values
            policyObject.Name = (string)policyDataSet.Tables[0].Rows[0]["name"];
            policyObject.Description = (string)policyDataSet.Tables[0].Rows[0]["description"];
            policyObject.Target_group = (string)policyDataSet.Tables[0].Rows[0]["target_group"]; 
            policyObject.Author = (string)policyDataSet.Tables[0].Rows[0]["author"];
            policyObject.Effective_date = (DateTime)policyDataSet.Tables[0].Rows[0]["effective_date"];
        }

        public DataSet getPolicyByType(Entity.Policy policyObject)
        {
            Data.PolicyData policySummaryData = new PolicyData(policyObject);
            
            return policySummaryData.selectPolicyByType(policyObject);                        
        }

        public void newPolicyNo(Entity.Policy policyObject)
        {
            Data.PolicyData newPolicyData = new PolicyData(policyObject);

            policyObject.No = newPolicyData.generateNewPolicyNo(policyObject);
        }

        public bool policyExists(Entity.Policy policyObject)
        {
            Data.PolicyData policyData = new PolicyData(policyObject);

            return (policyData.policyExists(policyObject) > 0);
        }

        public bool ownPolicy(Entity.Employee employeeObject, Entity.Policy policyObject)
        {
            Data.PolicyData policyData = new PolicyData();

            return (policyData.checkOwnPolicy(employeeObject, policyObject) > 0);
        }
    }
}
