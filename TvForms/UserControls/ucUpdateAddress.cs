﻿using System;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcUpdateAddress : UserControl
    {
        private int _addressID;
        UserAddress _address = new UserAddress();
        public UcUpdateAddress()
        {
            InitializeComponent();
        }

        public void UpdateAddress(int addressID)
        {
            _addressID = addressID;
            SetControlView();
        }
        
        private void SetControlView()
        {
            int i = 0;
            using (var context = new TvDBContext())
            {
                var types = from t in context.TypeConnects
                            select t;
                types.ToList();

                _address = context.UserAddresses.First(c => c.Id == _addressID);
                tbUserAddress.Text = _address.Address;
                tbComment.Text = _address.Comment;
                foreach (var typeConnect in types)
                {
                    cbAddressType.Items.Add(typeConnect.NameType);
                    if (typeConnect.NameType == _address.TypeConnect.NameType)
                    {
                        cbAddressType.SelectedIndex = i;
                    }
                    i++;
                }
            }
        }

        public bool ValidateControls()
        {
            if (tbUserAddress.Text.Trim() == String.Empty)
            {
                return false;
            }
            return true;
        }

        public void SaveAddedDetails()
        {
            if (_address.Address != tbUserAddress.Text ||
                _address.Comment != tbComment.Text ||
                _address.TypeConnect.NameType != cbAddressType.SelectedItem)
            {
                using (var context = new TvDBContext())
                {
                    var addressToChange = context.UserAddresses.First(l => l.Id == _addressID);
                    addressToChange.Address = tbUserAddress.Text;
                    addressToChange.Comment = tbComment.Text;
                    addressToChange.TypeConnect = context.TypeConnects.First(l => l.NameType == cbAddressType.SelectedItem.ToString());
                    addressToChange.User = context.Users.First(u => u.Id == addressToChange.User.Id);
                    context.SaveChanges();
                    MessageBox.Show("Results saved correctly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
