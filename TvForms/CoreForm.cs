﻿using System;
using System.Windows.Forms;
using TvDbContext;

namespace TvForms
{
    public partial class CoreForm : Form
    {
        public CoreForm()
        {
            InitializeComponent();
            tabCoreAllCh.Controls.Add(new ucAllChannels());
            tabCoreTvShow.Controls.Add(new ucTvShow());

        }

        private void bCancelCore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveCore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveYourListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void additionalServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionForm action = new ActionForm(new ucTvShow());
            action.Show();
            this.Enabled = false;

        }

    

        //Uncomment when bookmarks will be ready end specify appropriate one!!!!
        //private void tVShowsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ActionForm action = new ActionForm(new ucTvShow());
        //    action.Show();
        //    this.Enabled = false;

        //}


    }
}
