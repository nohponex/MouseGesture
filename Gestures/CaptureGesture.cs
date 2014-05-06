using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestures {
    public class CaptureGesture : Gesture {
        System.Drawing.Point _LastPoint;

        public System.Drawing.Point LastPoint { get { return _LastPoint; } }

        public ushort Samples = 2;
        public ushort currentSample;

        private bool fullDirections=true;

        public CaptureGesture(System.Drawing.Point StartPoint,bool _fullDirections=true) {
            _LastPoint = StartPoint;
            fullDirections = _fullDirections;
            currentSample = 0;
        }

        public void AddPoint(System.Drawing.Point newPoint) {

            double deg = 360 -  getAngleBetweenPoints(_LastPoint.X, _LastPoint.Y, newPoint.X, newPoint.Y);
      
            Direction dir = Gesture.getDirectionByAngle(deg,fullDirections);
            
            Console.WriteLine("deg = {0}  dir = {1}" , deg,  dir);

            if (this._directions.Count == 0 || this._directions[this._directions.Count - 1] != dir) _directions.Add(dir);
 
            _LastPoint = newPoint;
        }

        public void StopCapturing() {
            Console.WriteLine("Gesture recorder ... :");
            foreach (Direction dir in _directions) {
                Console.WriteLine(dir);
            }

        }

        public static bool operator ==(CaptureGesture a, Gesture b) {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b)) {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null)) {
                return false;
            }

            if (a._directions.Count != b.DirectionsL.Count) return false;

            // Return true if the directions match:
            for (ushort i = 0; i < a._directions.Count; i++)
                if (a._directions[i] != b.DirectionsL[i]) return false;

            return true;

        }
        public override int GetHashCode() {
            return _directions.Count;
        }

        public static bool operator !=(CaptureGesture a, Gesture b) {
            return !(a == b);
        }
        public override bool Equals(System.Object obj) {
            Gesture g = obj as Gesture;
            if ((object)g == null) {
                return false;
            }
            if (_directions.Count != g.DirectionsL.Count) return false;

            // Return true if the directions match:
            for (ushort i = 0; i < _directions.Count; i++)
                if (_directions[i] != g.DirectionsL[i]) return false;

            return true;
        }


        /// <summary>
        ///  
        /// </summary>
        /// <param name="newPoint"></param>
        /// <returns> Returns the distance between last point</returns>
        public double getDistance(System.Drawing.Point newPoint) {
            return Math.Sqrt( Math.Pow( newPoint.X - _LastPoint.X,2) +  Math.Pow(newPoint.Y - _LastPoint.Y, 2));
        }

        /// <summary>
        /// Returns the angle between 2 points
        /// </summary>
        /// <param name="px1"></param>
        /// <param name="py1"></param>
        /// <param name="px2"></param>
        /// <param name="py2"></param>
        /// <returns></returns>
        public static double getAngleBetweenPoints(double px1, double py1, double px2, double py2) {

            double px = px2 - px1;
            double py = py2 - py1;

            double angle = 0.0;

            // Calculate the angle 
            if (px == 0.0) {
                if (px == 0.0)

                    angle = 0.0;
                else if (py > 0.0) angle = System.Math.PI / 2.0;

                else
                    angle = System.Math.PI * 3.0 / 2.0;

            } else if (py == 0.0) {
                if (px > 0.0)

                    angle = 0.0;

                else
                    angle = System.Math.PI;

            } else {
                if (px < 0.0)

                    angle = System.Math.Atan(py / px) + System.Math.PI;
                else if (py < 0.0) angle = System.Math.Atan(py / px) + (2 * System.Math.PI);

                else
                    angle = System.Math.Atan(py / px);

            }

            // Convert to degrees 
            angle = angle * 180 / System.Math.PI; 
            return angle;

        }
    }
}
