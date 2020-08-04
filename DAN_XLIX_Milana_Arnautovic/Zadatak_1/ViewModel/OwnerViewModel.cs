using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class OwnerViewModel : ViewModelBase
    {
        OwnerView ownerview;
        Service service = new Service();

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

        private Visibility viewEmployee = Visibility.Visible;
        public Visibility ViewEmployee
        {
            get
            {
                return viewEmployee;
            }
            set
            {
                viewEmployee = value;
                OnPropertyChanged("ViewEmployee");
            }
        }
        #endregion

        #region Constructors


        public OwnerViewModel(OwnerView ownerOpen)
        {
            ownerview = ownerOpen;
            using (DAN_XLIXEntities context = new DAN_XLIXEntities())
            {
                EmployeeList = context.tblEmployees.ToList();
            }
        }
        #endregion

        #region Commands

        private ICommand addCommandEmployee;
        /// <summary>
        /// Add product command
        /// </summary>
        public ICommand AddCommandEmployee
        {
            get
            {
                if (addCommandEmployee == null)
                {
                    addCommandEmployee = new RelayCommand(param => AddCommandEmployeeExecute(), param => CanAddCommandExecute());
                }
                return addCommandEmployee;
            }
        }

        /// <summary>
        /// Add product execute
        /// </summary>
        private void AddCommandEmployeeExecute()
        {
            try
            {
                AddEmployeeView addViewEmployee = new AddEmployeeView();
                addViewEmployee.ShowDialog();
                if ((addViewEmployee.DataContext as AddEmployeeViewModel).IsUpdateEmployee == true)
                {
                    EmployeeList = service.GetAllEmployees().ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can add product
        /// </summary>
        /// <returns></returns>
        private bool CanAddCommandExecute()
        {
            return true;
        }

        private ICommand cancel;
        /// <summary>
        ///Cancel command 
        /// </summary>
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        /// <summary>
        /// Cancel execute
        /// </summary>
        private void CancelExecute()
        {
            try
            {
                ownerview.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private bool CanCancelExecute()
        {
            return true;
        }
    }
}
#endregion
