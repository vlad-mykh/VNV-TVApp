﻿using System.Windows.Forms;

namespace TvForms
{
    public partial class AccountChargeForm : Form
    {

        private int CurrentUserId { get; set; }

        private UсAccountCharge _ucCharge;

        public AccountChargeForm(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;
            _ucCharge = new UсAccountCharge(CurrentUserId);
            panChargeAccount.Controls.Add(_ucCharge);
        }

        private void btOkey_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void AccountChargeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var eventSource = (Form)sender;
            //todo I don't understand why is DialogResult allways CANCEL ???????
            //if (eventSource.DialogResult != DialogResult.Cancel)
            //{
            if (!_ucCharge.ValidateControls())
                {
                    e.Cancel = true;
                }
            //}
        }


    }
}
