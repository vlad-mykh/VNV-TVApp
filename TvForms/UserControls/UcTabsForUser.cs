﻿using System.Drawing;
using System.Windows.Forms;

namespace TvForms
{
    public partial class UcTabsForUser : UserControl
    {
        //private readonly List<Channel> _channelRepo = BaseRepository<Channel>.GetAll().ToList();

        private int CurrentUserId { get; set; }

        //private int CurrentOrderId { get; set; }

        //ToDO Use only one UC
        //private List<Channel> CurrentWeekChannel { get; set; }

        private UcAllChannels AllChannelControl { get; set; }

        private UcFavoirute MyFavouriteControl { get; set; }

        public UcTabsForUser(int userId)
        {
            
            //ToDo Load channels for put in into constructor of ucChannelShowInfo
            InitializeComponent();
            CurrentUserId = userId;
            LoadControls();
            
        }

        private void LoadControls()
        {
            AllChannelControl = new UcAllChannels(CurrentUserId);
            tabPan_AllChannels.Controls.Add(AllChannelControl);
        }


        private void tabForUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //0 - AllChannels tab, 1 - MyFavourite tab
            var numberCurrentTab = tabForUsers.SelectedIndex;
            switch (numberCurrentTab)
            {
                case 0:
                    AllChannelControl.MarkChosenMedia();
                    break;
                case 1:
                    MyFavouriteControl?.Dispose();
                    MyFavouriteControl = new UcFavoirute(CurrentUserId);
                    tabPan_MyFavourite.Controls.Add(MyFavouriteControl);
                    break;
            }
            
        }


        public void SetReloadChannelButton(bool visible, Color color)
        {
            if (tabForUsers.SelectedTab == tabPan_AllChannels)
                AllChannelControl.SetReloadButton(true, Color.Crimson);
        }

        public void SetReloadMoneyButton(bool visible, Color color)
        {
            if(tabForUsers.SelectedTab == tabPan_MyFavourite)
                MyFavouriteControl.SetReloadButton(true, Color.Crimson);
        }
    }
}
