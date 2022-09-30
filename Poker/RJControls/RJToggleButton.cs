using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Poker.RJControls
{
    public class RJToggleButton : CheckBox
    {
        //Atributs del control
        private Color onBackColor = Color.Teal;
        private Color onToggleColor = Color.Lime;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Red;
        private bool solidStyle = true;
        //Propietats del control (per poder modificar-les des del designer)
        public Color OnBackColor { get => onBackColor; set { onBackColor = value; this.Invalidate(); } }
        public Color OnToggleColor { get => onToggleColor; set { onToggleColor = value; this.Invalidate(); } }
        public Color OffBackColor { get => offBackColor; set { offBackColor = value; this.Invalidate(); } }
        public Color OffToggleColor { get => offToggleColor; set { offToggleColor = value; this.Invalidate(); } }
        
        [DefaultValue(true)]
        public bool SolidStyle { get => solidStyle; set { solidStyle = value; this.Invalidate(); } }
        
        public override string Text { get => base.Text; set {  } }

        //Constructor
        public RJToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }
        //Mètodes
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width-arcSize-2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Color curColor;
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
           
            if (this.Checked) //estat = ON
            {
                //dibuixem la superfície ovalada sobre la que es dibuixa el botó
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                //dibuixem el selector de la rodona indicant l'estat ON
                curColor = onToggleColor;
                if (!this.Enabled) { curColor = Color.Gray;}
                pevent.Graphics.FillEllipse(new SolidBrush(curColor), 
                    new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));

            }
            else //estat = OFF
            {
                //dibuixem la superfície ovalada sobre la que es dibuixa el botó
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                //dibuixem el selector de la rodona indicant l'estat OFF
                curColor = offToggleColor;
                if (!this.Enabled) { curColor = Color.Gray; }
                pevent.Graphics.FillEllipse(new SolidBrush(curColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
