﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInterface.Views
{
    /// <summary>
    /// A view for a summary file.
    /// </summary>
    public partial class SummaryView : UserControl, ISummaryView
    {
        private HTMLView htmlView1 = null;

        /// <summary>Initializes a new instance of the <see cref="SummaryView"/> class.</summary>
        public SummaryView()
        {
            InitializeComponent();

            // MONO doesn't seem to like HTMLView
            if (Environment.OSVersion.Platform == PlatformID.Win32NT ||
                Environment.OSVersion.Platform == PlatformID.Win32Windows)
            {
                htmlView1 = new HTMLView();
                htmlView1.Parent = panel1;
                htmlView1.Dock = DockStyle.Fill;
            }
            else
            {

            }
        }

        /// <summary>Occurs when the name of the simulation is changed by the user</summary>
        public event EventHandler SimulationNameChanged;

        /// <summary>Gets or sets the currently selected simulation name.</summary>
        public string SimulationName
        {
            get
            {
                return this.comboBox1.Text;
            }

            set
            {
                this.comboBox1.Text = value;
            }
        }

        /// <summary>Gets or sets the simulation names.</summary>
        public IEnumerable<string> SimulationNames
        {
            get
            {
                return this.comboBox1.Items.OfType<string>();
            }

            set
            {
                this.comboBox1.Items.AddRange(value as object[]);
            }
        }

        /// <summary>Sets the content of the summary window.</summary>
        /// <param name="content">The html content</param>
        public void SetSummaryContent(string content)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT ||
                Environment.OSVersion.Platform == PlatformID.Win32Windows)
            {
                this.htmlView1.MemoText = content;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.SimulationNameChanged != null)
                this.SimulationNameChanged(this, e);
        }
    }
}
