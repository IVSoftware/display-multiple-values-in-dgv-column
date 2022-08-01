﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewcomboboxcolumn?view=windowsdesktop-6.0

namespace display_multiple_values_in_dgv_column
{
    public partial class CreditUserLimitsForm  : Form
    {
        public CreditUserLimitsForm () => InitializeComponent();

        readonly BindingList<CreditUser> CreditUsers = new BindingList<CreditUser>();
        protected override void OnLoad(EventArgs e)
        {
            dataGridViewCreditUser.DataSource = CreditUsers;
            // This will autogenerate columns
            foreach (var creditUser in mockMainForm_srv_GetCreditUser("", ""))
            {
                CreditUsers.Add(creditUser);
            }

            // Create the ComboBox column. This will be swapped out for the autogenerated one.
            var colCB = new DataGridViewComboBoxColumn
            {
                Name = nameof(CreditUser.CustomerType),
                DataPropertyName = nameof(CreditUser.CustomerType),
                HeaderText = "Customer Type",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DataSource = ResponsibleList,
            };
            // Swap out the autogenerated column
            var index = dataGridViewCreditUser.Columns[nameof(CreditUser.CustomerType)].Index;
            dataGridViewCreditUser.Columns.RemoveAt(index);
            dataGridViewCreditUser.Columns.Insert(index, colCB);

            // Make sure the cell is NOT left in an editing
            // state after change of ComboBox or CheckBox.
            dataGridViewCreditUser.CurrentCellDirtyStateChanged += (sender, e) =>
            {
                switch (dataGridViewCreditUser.Columns[dataGridViewCreditUser.CurrentCell.ColumnIndex].Name)
                {
                    case nameof(CreditUser.CustomerType):
                    case nameof(CreditUser.Restricted):
                        dataGridViewCreditUser.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        break;
                }
            };

            // Update the Title bar when anything changes in the list.
            CreditUsers.ListChanged += (sender, e) =>
            {
                if ((dataGridViewCreditUser.CurrentCell != null) && (dataGridViewCreditUser.CurrentCell.RowIndex < CreditUsers.Count))
                {
                    var creditUser = CreditUsers[dataGridViewCreditUser.CurrentCell.RowIndex];
                    Text = creditUser.ToString();
                }
            };

            // Format columns
            foreach (DataGridViewColumn col in dataGridViewCreditUser.Columns)
            {
                if (col.Name == nameof(CreditUser.UserName))
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        // Provides the combo box options. This list will not change.
        private readonly string[] ResponsibleList = new []
        {
            "Production", 
            "Distribution", 
            "Customer Service", 
            "Sales",
            String.Empty
        };

        // MOCK for minimal example
        private List<CreditUser> mockMainForm_srv_GetCreditUser(string v1, string v2)
        {
            return new List<CreditUser>
            {
                new CreditUser
                {
                    UserName = "Tom",
                    CreditLimit=10000m,
                },
                new CreditUser
                {
                    UserName = "Richard",
                    CreditLimit=1250m,
                    Restricted = true,
                },
                new CreditUser
                {
                    UserName = "Harry",
                    CreditLimit=10000m,
                },
            };
        }
    }

    // REDUCED for minimal example
    public class CreditUser : INotifyPropertyChanged
    {
        string _UserName = string.Empty;
        public string UserName
        {
            get => _UserName;
            set
            {
                if (!Equals(_UserName, value))
                {
                    _UserName = value;
                    OnPropertyChanged();
                }
            }
        }
        string _CustomerType = String.Empty;
        public string CustomerType
        {
            get => _CustomerType;
            set
            {
                if (!Equals(_CustomerType, value))
                {
                    _CustomerType = value;
                    OnPropertyChanged();
                }
            }
        }
        decimal _CreditLimit = 0;
        public decimal CreditLimit
        {
            get => _CreditLimit;
            set
            {
                if (!Equals(_CreditLimit, value))
                {
                    _CreditLimit = value;
                    OnPropertyChanged();
                }
            }
        }

        bool _Restricted = false;
        public bool Restricted
        {
            get => _Restricted;
            set
            {
                if (!Equals(_Restricted, value))
                {
                    _Restricted = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            var ctype = CustomerType == string.Empty ? "Not Specified" : $"{CustomerType}";
            return Restricted ?
            $"{UserName} ({ctype}) Restricted" :
            $"{UserName} ({ctype}) {CreditLimit}";
        }
    }
}
