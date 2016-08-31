﻿using System;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TvForms
{
    public partial class UcAdminView : UserControl
    {
        // Variable contains selected in users lv user's details
        private int _selectedUser;

        private int CurrentUserId { get; set; }

        // used this flag to show / not show dialog box after changing adultContent status on launch or manually
        private bool _adultContentFlag;

        private bool _activeUserFlag;

        private bool _userType;

        //private User _currentUser;
        public UcAdminView(int currentUser)
        {
            CurrentUserId = currentUser;
            InitializeComponent();
            SetPageView();
        }

        private void SetPageView()
        {
            // clear the list view in case user's opened it previously during a session
            lvUserList.Items.Clear();
            var users = BaseRepository<User>.GetAll();

            FillUsersLv(users);

            //set max value for search user numeric up and down
            numSearchUserId.Maximum = lvUserList.Items.Count;

            cbStatus.Items.Add(UserStatus.Active);
            cbStatus.Items.Add(UserStatus.Inactive);

            /*foreach (var type in userRepo._context.UserTypes)
            {
                cbUserType.Items.Add(type.TypeName);
            }*/

            cbUserType.Items.Add(EUserType.ACCESS_DENIED);
            cbUserType.Items.Add(EUserType.ADMIN);
            cbUserType.Items.Add(EUserType.CLIENT);
            cbUserType.Items.Add(EUserType.MANAGER);
            cbUserType.Items.Add(EUserType.CHIEF);

                lvUserList.Items[0].Selected = true;
        }

        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetItemsForChosenUser();
            var listView = (ListView) sender;
            if (listView.SelectedItems.Count > 0)
            {
                var listViewItem = listView.SelectedItems[0];
                _selectedUser = listViewItem.SubItems[0].Text.GetInt();
                tbName.Text = listViewItem.SubItems[2].Text;
                tbSurname.Text = listViewItem.SubItems[3].Text;

                #region filling user data for admin user control
                var user = BaseRepository<User>.Get(c => c.Id == _selectedUser).First();

                // Filling user's address list List View
                if (user.UserAddresses.Any())
                {
                    foreach (var address in user.UserAddresses)
                    {
                        var lvItem = new ListViewItem(address.TypeConnect.NameType);
                        lvItem.SubItems.Add(address.Address);
                        lvItem.SubItems.Add(address.Comment);
                        lvUserAddress.Items.Add(lvItem);
                    }
                }

                // Filling user's email list List View
                if (user.UserEmails.Any())
                {
                    foreach (var email in user.UserEmails)
                    {
                        var lvItem = new ListViewItem(email.TypeConnect.NameType);
                        lvItem.SubItems.Add(email.EmailName);
                        lvItem.SubItems.Add(email.Comment);
                        lvUserEmail.Items.Add(lvItem);
                    }
                }

                // Filling user's phone list List View
                if (user.UserPhones.Any())
                {
                    foreach (var phone in user.UserPhones)
                    {
                        var lvItem = new ListViewItem(phone.TypeConnect.NameType);
                        lvItem.SubItems.Add(phone.Number.ToString());
                        lvItem.SubItems.Add(phone.Comment);
                        lvUserTelephone.Items.Add(lvItem);
                    }
                }

                // Filling Money and status TB's
                // uncomment when whole functionality has been provided
                tbMoney.Text = @"Change in ucAdminClass";

                _activeUserFlag = true;
                if (user.IsActiveStatus)
                {
                    cbStatus.SelectedIndex = 0;
                }
                else
                {
                    cbStatus.SelectedIndex = 1;
                }
                _activeUserFlag = false;

                _userType = true;
                cbUserType.SelectedIndex = user.UserType.Id;
                _userType = false;
                /*var moneyStatus = context.DepositAccounts.Where(s => s.User.Id == id);
                if (moneyStatus.Any())
                {
                    money.ToList();
                    foreach (var i in money)
                    {
                        tbMoney.Text = i.Balance.ToString();
                        bool status = i.Status;
                        if (status)
                        {
                            cbStatus.SelectedIndex = 0;
                        }
                        else
                        {
                            cbStatus.SelectedIndex = 1;
                        }
                    }
                }*/

                _adultContentFlag = true;
                cbAdultContent.Checked = user.IsAllowAdultContent;
                _adultContentFlag = false;

                if (user.UserType.Id == (int)EUserType.ADMIN)
                {
                    cbAdultContent.Enabled = false;
                    cbAccountStatus.Enabled = false;
                    cbStatus.Enabled = false;
                }
                else
                {
                    cbAdultContent.Enabled = true;
                    cbAccountStatus.Enabled = true;
                    cbStatus.Enabled = true;
                }
                #endregion
            }
        }

        private void SetItemsForChosenUser()
        {
            // clear the list views in case user's opened it previously during a session
            lvUserAddress.Items.Clear();
            lvUserTelephone.Items.Clear();
            lvUserEmail.Items.Clear();
        }

        // method to activate / deactivate selected user
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_activeUserFlag)
            {
                var user = BaseRepository<User>.Get(c => c.Id == _selectedUser)
                    .Include(x => x.UserType)
                    .First();

                if ((UserStatus)Enum.Parse(typeof(UserStatus), cbStatus.SelectedItem.ToString()) == UserStatus.Active
                    && !user.IsActiveStatus)
                {
                    if (MessageBox.Show(@"Do you want to activate this user?", @"Activate user",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.IsActiveStatus = true;
                    }
                    else
                    {
                        _activeUserFlag = true;
                        cbStatus.SelectedIndex = 1;
                    }
                }
                else if ((UserStatus)Enum.Parse(typeof(UserStatus), cbStatus.SelectedItem.ToString()) == UserStatus.Inactive
                    && user.IsActiveStatus)
                {
                    if (MessageBox.Show(@"Do you want to deactivate this user?", @"Deactivate user",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.IsActiveStatus = false;
                    }
                    else
                    {
                        _activeUserFlag = true;
                        cbStatus.SelectedIndex = 0;
                    }
                }
                BaseRepository<User>.Update(user);
                _activeUserFlag = false;
            }
        }

        // method to allow / forbid adult content for a user
        private void cbAdultContent_CheckedChanged(object sender, EventArgs e)
        {
            if (!_adultContentFlag)
            {
                var user = BaseRepository<User>.Get(x => x.Id == _selectedUser)
                    .Include(x => x.UserType)
                    .First();
                if (cbAdultContent.Checked)
                {
                    if (MessageBox.Show(@"Do you want to allow adult content for this user?", @"Allow adult content",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.IsAllowAdultContent = true;
                    }
                    else
                    {
                        _adultContentFlag = true;
                        cbAdultContent.Checked = false;
                    }
                }
                else
                {
                    if (MessageBox.Show(@"Do you want to forbid adult content for this user?", @"Forbid adult content",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.IsAllowAdultContent = false;
                    }
                    else
                    {
                        _adultContentFlag = true;
                        cbAdultContent.Checked = true;
                    }
                }
                BaseRepository<User>.Update(user);

                _adultContentFlag = false;
            }
        }

        private void btViewOrders_Click(object sender, EventArgs e)
        {
            var actions = new ActionForm(new UсOrdersView(CurrentUserId))
            {
                Text = @"User orders history"
                //Icon = new Icon(@"d:\docs\C#\TvAppTeam\TVAppVNV\TvForms\icons\wallet.ico")
            };
            actions.Show();
        }

        private void btViewPayment_Click(object sender, EventArgs e)
        {
            var actions = new ActionForm(new UcPayments(CurrentUserId))
            {
                Text = @"PAYMENTS",
                Icon = new Icon(@"d:\docs\C#\TvAppTeam\TVAppVNV\TvForms\icons\dollar.ico")
            };
            actions.Show();
        }

        private void btViewChannels_Click(object sender, EventArgs e)
        {
            var actionForm = new ActionForm(new UcAllChannels(CurrentUserId));
            actionForm.Show();
        }

        // method to change chosen user's type
        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_userType)
            {
                var user = BaseRepository<User>.Get(x => x.Id == _selectedUser)
                    .Include(x => x.UserType)
                    .First();
                var newTypeId = (int)Enum.Parse(typeof(EUserType), cbUserType.SelectedItem.ToString());
                var newType = BaseRepository<UserType>.Get(x => x.Id == newTypeId).FirstOrDefault();
                if (newTypeId != user.UserType.Id &&
                    MessageBox.Show(@"Do you want to change user type from " + user.UserType.TypeName +
                                    @" to " + newType?.TypeName, @"Change user type",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    user.UserType = newType;
                    BaseRepository<User>.Update(user);
                    MessagesContainer.DisplayInfo("Next session for this user will start with new rights", "User type has been updated");
                }
                else
                {
                    cbUserType.SelectedIndex = user.UserType.Id;
                }
                _userType = false;
            }
        }

        // function searches a user in the db by id / login / id + login
        private void btSearch_Click(object sender, EventArgs e)
        {
            //check if search criteria have been entered
            if (tbSearchLogin.Text.Trim() == String.Empty &&
                tbSurname.Text.Trim() == String.Empty &&
                numSearchUserId.Value == 0)
            {
                MessagesContainer.DisplayError("Please, set search criteria", "Error");
            }
            else 
            {
                var foundUsers = BaseRepository<User>.GetAll();

                // try to find by Name
                if (tbSearchName.Text.Trim() != string.Empty)
                {
                    foundUsers = foundUsers.Where(x => x.FirstName == tbSearchName.Text.Trim());
                }

                // try to find by Surname
                if (tbSearchSurname.Text.Trim() != string.Empty)
                {
                    foundUsers = foundUsers.Where(x => x.LastName == tbSearchSurname.Text.Trim());
                }

                // try to find by login
                if (tbSearchLogin.Text.Trim() != string.Empty)
                {
                    foundUsers = foundUsers.Where(x => x.Login == tbSearchLogin.Text.Trim());
                }

                // try to find by Id
                if (numSearchUserId.Value != 0)
                {
                    foundUsers = foundUsers.Where(x => x.Id == numSearchUserId.Value);
                }

                if (!foundUsers.Any())
                {
                    MessagesContainer.DisplayError("No users found according to selected criteria", "Error");
                    return;
                }
                FillUsersLv(foundUsers);
            }
        }

        // unselecting row in users list view to select found user automatically
        private void UnselectLvItem()
        {
            for (int i = 0; i < lvUserList.Items.Count; i++)
            {
                if (lvUserList.Items[i].Selected)
                {
                    lvUserList.Items[i].Selected = false;
                    return;
                }
            }
        }

        // filling users LV according to the received data
        private void FillUsersLv(IQueryable<User> users)
        {
            lvUserList.Items.Clear();
            foreach (var user in users)
            {
                var lvItem = new ListViewItem(user.Id.ToString());
                lvItem.SubItems.Add(user.Login);
                lvItem.SubItems.Add(user.FirstName);
                lvItem.SubItems.Add(user.LastName);
                lvUserList.Items.Add(lvItem);
            }
            UnselectLvItem();
            lvUserList.Items[0].Selected = true;
        }

        private void btResrtSearch_Click(object sender, EventArgs e)
        {
            tbSearchName.Clear();
            tbSearchSurname.Clear();
            tbSearchLogin.Clear();
            numSearchUserId.Value = 0;
            SetPageView();
        }
    }
}