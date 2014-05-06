using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestures {
    public class Gestures {
        List<Gesture> _GesturesList;

        private System.Windows.Forms.Control control;
        private CaptureGesture currentGesture;

        private int minDistance = 20;
        private bool fullDirections = true;

        public Gestures(bool _fullDirections=true) {
            _GesturesList = new List<Gesture>();
            currentGesture = null;
            fullDirections= _fullDirections;
        }

        public void AddGesture(Gesture n) {
            //Check if exists;
            _GesturesList.Add(n);
        }
        public List<Gesture> getGestures(){
            return _GesturesList;
        }

        public void CaptureControl(System.Windows.Forms.Control _control) {
            control = _control;
            control.MouseDown += new System.Windows.Forms.MouseEventHandler(control_MouseDown);
        }

        void control_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            Console.WriteLine("mouse clicked");
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                if (currentGesture == null){
                    currentGesture = new CaptureGesture(new System.Drawing.Point(e.X,e.Y),fullDirections);
                    control.MouseMove += new System.Windows.Forms.MouseEventHandler(control_MouseMove);
                    control.Cursor = System.Windows.Forms.Cursors.Cross;
                } else {
                    currentGesture.StopCapturing();
                    control.MouseMove -= new System.Windows.Forms.MouseEventHandler(control_MouseMove);
                    Console.WriteLine("Comparing gestures...");

                    foreach (Gesture g in _GesturesList) {
                        if (currentGesture == g) {
                            Console.WriteLine("Gesture found! action = {0}", g.Action);
                            System.Windows.Forms.MessageBox.Show("Action = " + g.Action);
                            break;
                        }

                    }                
                                        
                    currentGesture = null;
                    control.Cursor = System.Windows.Forms.Cursors.Default;
                }

            }
        }

        void control_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
            currentGesture.currentSample++;
            if (currentGesture.currentSample >= currentGesture.Samples && currentGesture.getDistance(new System.Drawing.Point(e.X, e.Y)) >= minDistance) {

                currentGesture.currentSample = 0;
                //Draw to form ( REMOVE IF NOT USING DEMO )
                System.Drawing.Graphics formGraphics = control.CreateGraphics();
                formGraphics.DrawLine(System.Drawing.Pens.Red, currentGesture.LastPoint, new System.Drawing.Point(e.X, e.Y));

                //formGraphics.DrawLine(System.Drawing.Pens.Black, currentGesture.LastPoint.X - 150, currentGesture.LastPoint.Y, currentGesture.LastPoint.X + 150, currentGesture.LastPoint.Y);

                //formGraphics.DrawLine(System.Drawing.Pens.Black, currentGesture.LastPoint.X, currentGesture.LastPoint.Y - 150 , currentGesture.LastPoint.X, currentGesture.LastPoint.Y+150);

                formGraphics.Dispose();

                currentGesture.AddPoint(new System.Drawing.Point(e.X, e.Y));

                //control.CreateGraphics().DrawLine(System.Drawing.Pens.DarkBlue, currentGesture.LastPoint, new System.Drawing.Point(e.X, e.Y));
          
            }
        }

    }
}
