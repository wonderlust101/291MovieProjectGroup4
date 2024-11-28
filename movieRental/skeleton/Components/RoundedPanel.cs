using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls.RoundedPanel
{
    public class RoundedPanel : TableLayoutPanel
    {
        public int BorderRadius { get; set; } = 30; // Adjust radius as needed
        public Color BorderColor { get; set; } = Color.Transparent; // Default to no border
        public int BorderSize { get; set; } = 0; // Default to no border

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseFigure();

            // Apply clipping region
            this.Region = new Region(path);

            // Optionally, draw a border if BorderSize > 0 and BorderColor is not transparent
            if (BorderSize > 0 && BorderColor != Color.Transparent)
            {
                using (Pen pen = new Pen(BorderColor, BorderSize))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
