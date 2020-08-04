using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class AddEmployeeViewModel: ViewModelBase
    {
        AddEmployeeView addEmployeeView;
        Service service = new Service();

        #region Constructor

        public AddEmployeeViewModel(AddEmployeeView addEmployeeOpen)
        {
            addEmployeeView = addEmployeeOpen;
            Employee = new tblEmployee();
            EmployeeList = service.GetAllEmployees().ToList();
        }

        public AddEmployeeViewModel(AddEmployeeView addEmployeeOpen, tblEmployee tblEmployee)
        {
            addEmployeeView = addEmployeeOpen;
            EmployeeList = service.GetAllEmployees().ToList();
        }
        #endregion

        #region Properties
        private tblEmployee employee;
        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private List<tblEmployee> employeeList;
        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }


        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }
        #endregion
    }
}
