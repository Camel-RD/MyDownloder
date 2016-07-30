using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyDownloader.Classes
{
    public partial class SomeConfig : Component
    {
        public Color ColorError { get; set; } = Color.Red;
        public Color ColorReady { get; set; } = Color.Blue;
        public Color ColorRunning { get; set; } = Color.Yellow;
        public Color ColorCompleted { get; set; } = Color.Green;
        public Color ColorDisabled { get; set; } = Color.Gray;

        public SomeConfig()
        {
            InitializeComponent();
        }

        public SomeConfig(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
