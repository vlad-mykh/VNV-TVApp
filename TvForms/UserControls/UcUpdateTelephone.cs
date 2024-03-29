﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    // class to update user's telephone
    public partial class UcUpdateTelephone : UserControl
    {
        // create variable for further validation
        private int _phoneNumber;
        public UcUpdateTelephone()
        {
            InitializeComponent();
        }

        public void UpdateTelephone(int phoneId)
        {
            var i = 0;
            var phoneRepo = new BaseRepository<UserPhone>();
            var phoneToUpdate = phoneRepo.Get(c => c.Id == phoneId).First();
            var types = new BaseRepository<TypeConnect>(phoneRepo.ContextDb).GetAll().Distinct();

            _phoneNumber = phoneToUpdate.Number;
            tbNumber.Text = phoneToUpdate.Number.ToString();
            tbComment.Text = phoneToUpdate.Comment;
            foreach (var typeConnect in types)
            {
                cbPhoneType.Items.Add(typeConnect.NameType);
                if (typeConnect.NameType == phoneToUpdate.TypeConnect.NameType)
                {
                    cbPhoneType.SelectedIndex = i;
                }
                i++;
            }
        }

        // validate tb fields once OK button has been pressed
        public bool ValidateControls(int phoneId)
        {
            string errorMessage = "Error:";
            bool isValidNumber = true;
            if (tbNumber.Text.Trim() != String.Empty)
            {
                if (!tbNumber.Text.Trim().IsValidPhone())
                {
                    errorMessage += "\nPlease enter 5 to 9 phone number digits";
                    isValidNumber = false;
                }
                else if (tbNumber.Text.Trim() != _phoneNumber.ToString() && tbNumber.Text.Trim().GetInt().IsUniqueNumber())
                {
                    errorMessage += "\nNumber already exists. Please enter another one";
                    isValidNumber = false;
                }
            }
            else
            {
                errorMessage += "\nNumber field cannot be empty";
                isValidNumber = false;
            }

            if (!tbComment.Text.Trim().IsValidComment())
            {
                errorMessage += "\nComment cannot be longer than 500 characters";
                isValidNumber = false;
            }

            if (isValidNumber)
            {
                SaveAddedDetails(phoneId);
            }
            else
            {
                MessageContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidNumber;
        }

        // save in case of valid number
        public void SaveAddedDetails(int phoneId)
        {
            var phoneRepo = new BaseRepository<UserPhone>();
            var numberToUpdate = phoneRepo.Get(x => x.Id == phoneId)
                .Include(x => x.TypeConnect)
                .Include(x => x.User).First();
            numberToUpdate.Number = tbNumber.Text.GetInt();
            numberToUpdate.Comment = tbComment.Text;
            numberToUpdate.TypeConnect = new BaseRepository<TypeConnect>(phoneRepo.ContextDb).Get(l => l.NameType == cbPhoneType.SelectedItem.ToString()).First();
            phoneRepo.Update(numberToUpdate);
        }
    }
}
