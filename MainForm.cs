using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouseGesturesProject {
    public partial class MainForm : Form {
        Gestures.Gestures my;
        public MainForm() {
            InitializeComponent();
        }
  

        private void Form1_Load(object sender, EventArgs e) {

            my = new Gestures.Gestures(false);

            //Add some gestures
            List<Gestures.Direction> dirs = new List<Gestures.Direction>() { Gestures.Direction.right, Gestures.Direction.up };
            my.AddGesture(new Gestures.Gesture(dirs,"first"));
            dirs = new List<Gestures.Direction>(){ Gestures.Direction.right , Gestures.Direction.down};
            my.AddGesture(new Gestures.Gesture(dirs,"second"));

            my.AddGesture(new Gestures.Gesture("u  d", "third", ' ', true));
            my.AddGesture(new Gestures.Gesture("u  d l", "forth", ' ', true));
            my.AddGesture(new Gestures.Gesture("u  r", "fith", ' ', true));

            //Capture this form
            my.CaptureControl(this);

            //Add text to label
            Gestures.Gesture[] gestures = my.getGestures().ToArray();
            for (int i = 0, l = gestures.Length; i < l; ++i)
            {
                gesturesLabel.Text += Environment.NewLine +  i + ") " + gestures[i].ToString();
            }


            /*for (byte i = 0; i < 9; i++) {
                Console.WriteLine("[ {0} , {1} ]", ((i) * 45 - 22.5), ((i) * 45 + 22.5));
            }
            for (int i = 0; i <= 360; i += 5) {
                Console.WriteLine("deg = {0} dir = {1}",i, Gestures.Gesture.getDirectionByAngle(i));
            }*/

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < this.Width / 25; i++) {
                for (int j = 0; j < this.Height / 25; j++) {
                    e.Graphics.DrawLine(Pens.Blue, 0, 25 * j, this.Width, 25 * j);
                }
                e.Graphics.DrawLine(Pens.Blue, 25 * i, 0, 25 * i, this.Height);
            }
            base.OnPaint(e);
        }
    }
}
