using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Policy
    {
        // Fields
        string no;
        string name;
        string description;
        string type;
        string target_group;
        string originator;
        string author;
        string approver;
        DateTime date_created;
        DateTime approval_date;
        DateTime effective_date;

        // Constructors
        public Policy()
        {
        }

        public Policy(string Type)
        {
            type = Type;
        }

        public Policy(int PolicyNo)
        {
            no = PolicyNo.ToString();
        }
        
        public Policy(string No, string Name, string Description, string Type, string Target_group, string Originator,
                        string Author, string Approver, DateTime Date_created, DateTime Approval_date, DateTime Effective_date)
        {
            no = No;
            name = Name;
            description = Description;
            type = Type;
            target_group = Target_group;
            originator = Originator;
            author = Author;
            approver = Approver;
            date_created = Date_created;
            approval_date = Approval_date;
            effective_date = Effective_date;
        }   
 
        // Properties
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Target_group
        {
            get { return target_group; }
            set { target_group = value; }
        }

        public string Originator
        {
            get { return originator; }
            set { originator = value; }
        }
        
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Approver
        {
            get { return approver; }
            set { approver = value; }
        }

        public DateTime Date_created
        {
            get { return date_created; }
            set { date_created = value; }
        }

        public DateTime Approval_date
        {
            get { return approval_date; }
            set { approval_date = value; }
        }

        public DateTime Effective_date
        {
            get { return effective_date; }
            set { effective_date = value; }
        }
    }
}
