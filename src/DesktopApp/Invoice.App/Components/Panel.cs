using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.App.Components
{
    class Panel: System.Windows.Forms.Panel
    {
        public Panel()
        {
            Location = new Point(0, 0);
            Width = 800;
            Height = 100;
            BackColor = Color.SteelBlue;

        }
    }
}
