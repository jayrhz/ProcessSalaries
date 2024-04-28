using System.ComponentModel;
using System.Linq.Expressions;
using System.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ch13_ProcessSalaries
{

    public partial class ProcessSalaries : Form
    {
        private List<Employee> employees = new List<Employee>();

        public ProcessSalaries()
        {
            InitializeComponent();
            InitializecomboBoxType();
        }

        private void InitializecomboBoxType()
        {
            comboBoxType.Items.Add("Employee");
            comboBoxType.Items.Add("Manager");
            comboBoxType.Items.Add("Executive");
            comboBoxType.SelectedIndex = 0;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            double salary = double.Parse(txtSalary.Text);
            int yearsOfService = int.Parse(txtService.Text);
            string typeOfEmployee = comboBoxType.SelectedItem.ToString();

            Employee employee;

            switch (typeOfEmployee)
            {
                case "Manager":
                    employee = new Manager(name, salary, yearsOfService);
                    break;
                case "Executive":
                    employee = new Executive(name, salary, yearsOfService);
                    break;
                default:
                    employee = new Employee(name, salary, yearsOfService);
                    break;
            }

            employees.Add(employee);
        }

        private void btnCurrentList_Click(object sender, EventArgs e)
        {
            lstEmployees.Items.Clear();
            foreach (var emp in employees)
            {
                lstEmployees.Items.Add(emp.ToString());
            }
        }

        private void btnUpdateSalary_Click(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedItem != null)
            {
                int selectedIndex = lstEmployees.SelectedIndex;
                double newSalary = double.Parse(txtSalary.Text);
                employees[selectedIndex].Salary = newSalary;
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstEmployees.Items.Clear();
        }
    }
}

namespace ch13_ProcessSalaries
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int YearsOfService { get; set; }

        public Employee(string name, double salary, int yearsOfService) 
        {
            Name = name;
            Salary = salary;
            YearsOfService = yearsOfService;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Salary: {Salary}, Years of Service: {YearsOfService}, Type: Employee";
        }
    }
}


namespace ch13_ProcessSalaries
{
    public class Executive : Manager
    {
        public Executive(string name, double salary, int yearsOfService) : base(name, salary, yearsOfService)
        {
        }

        public override string ToString()
        {
            return $"Name: {Name}, Salary: {Salary}, Years Of Service: {YearsOfService}, Type: Executive";
        }
    }
}


namespace ch13_ProcessSalaries
{
    public class Manager : Employee
    {
        public Manager(string name, double salary, int yearsOfService) : base(name, salary, yearsOfService)
        {
        }

        public override string ToString()
        {
            return $"Name: {Name}, Salary: {Salary}, Years Of Service: {YearsOfService}, Type: Manager";
        }
    }

}




