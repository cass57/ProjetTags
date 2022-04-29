using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetTags
{
    public static class Utils
    {
        public static ContextMenuStrip CreateContextMenu(List<Tuple<string, EventHandler>> items)
        {
            var tagMenu = new ContextMenuStrip();
            foreach (var item in items) tagMenu.Items.Add(CreateMenuItem(item));
            return tagMenu;
        }

        public static ToolStripMenuItem CreateMenuItem(Tuple<string, EventHandler> item)
        {
            var label = new ToolStripMenuItem(item.Item1);
            label.Click += item.Item2;
            return label;
        }

        public static double Luminance(int r, int g, int b)
        {
            var values = new double[] {r, g, b};
            for (var i = 0; i < values.Length; i++)
            {
                values[i] /= 255;
                values[i] = values[i] <= 0.03928
                    ? values[i] / 12.92
                    : Math.Pow((values[i] + 0.055) / 1.055, 2.4);
            }

            return values[0] * 0.2126 + values[1] * 0.7152 + values[2] * 0.0722;
        }

        public static double Contrast(Color c1, Color c2)
        {
            var l1 = Luminance(c1.R, c1.G, c1.B);
            var l2 = Luminance(c2.R, c2.G, c2.B);
            return (Math.Max(l1, l2) + 0.05)
                   / (Math.Min(l1, l2) + 0.05);
        }
    }
}