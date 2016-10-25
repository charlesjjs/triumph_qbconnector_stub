using System.Drawing;
using System.Windows.Forms;

namespace QuickBooksIntegration
{

    public class QuickBooksIntegrationLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                    Color.FromArgb(209, 216, 223), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 216, 223), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 216, 223), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(209, 216, 223), 1, ButtonBorderStyle.Solid);
        }
    }

    
}
