using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestures  {
    public enum Direction : byte { none , right = 0, upright, up, upleft, left, downleft, down, downright }

    public class Gesture  {

        public static Direction getDirectionByAngle(double deg, bool fullDirections = true) {
            if (fullDirections) 
                return (Direction)(byte)((((deg > 337.5 ? 0 : deg) + 22.5) / 45));
            
            if (deg >= 225 && deg < 315) return Direction.down;

            if (deg >= 135 && deg < 225) return Direction.left;

            if (deg >= 45 && deg < 135) return Direction.up;

            if (deg >= 315 &&  deg <= 360 || deg >= 0 && deg < 45) return Direction.right;

            return Direction.none;
        }


        protected List<Direction> _directions;
        private string _action;
        
        public List<Direction> DirectionsL { get { return _directions; } }

        public String Action { get { return _action; } }

        public Gesture() {
            _directions = new List<Direction>();
            _action = string.Empty;
        }
        public Gesture(List<Direction> directions) {
            _directions = directions;
            _action = string.Empty;
        }

        public Gesture(List<Direction> directions, string action) {
            _directions = directions;
            _action = action;
        }

        public Gesture(string directions, char seperator = ' ') {
            string[] values = directions.ToLower().Split(seperator);
            _directions = new List<Direction>(values.Length);
            foreach (string v in values) {
               _directions.Add((Direction)Enum.Parse(typeof(Direction), v));
            }
            _action = string.Empty;
        }

        public Gesture(string directions,string action, char seperator = ' ' , bool shortDirection = false) {
            string[] values = directions.ToLower().Split(seperator);
            _directions = new List<Direction>(values.Length);
            Console.WriteLine(directions);
            foreach (string v in values) {
                if (shortDirection) {
                    switch(v) {
                        case "ur": _directions.Add(Direction.upright); break;
                        case "ul": _directions.Add(Direction.upleft); break;
                        case "dr": _directions.Add(Direction.downright); break;
                        case "dl": _directions.Add(Direction.downleft); break;
                        case "r": _directions.Add(Direction.right); break;
                        case "u": _directions.Add(Direction.up); break;
                        case "l": _directions.Add(Direction.left); break;
                        case "d": _directions.Add(Direction.down); break;

                        default:
                            break;
                    }
                    Console.WriteLine(v);
                    continue;
                }
                    _directions.Add((Direction)Enum.Parse(typeof(Direction), v));
                }

            _action = action;
    
        }

        ~Gesture() {
            _directions.Clear();
        }

        public override string ToString() {
            string v = string.Empty;
            foreach (Direction dir in _directions) {
                v += (dir.ToString() + " ");
            }
            if (v.EndsWith(" "))
            {
                v = v.Remove(v.Length - 1);
            }

            return v;

        }

        public static bool operator ==(Gesture a, Gesture b) {
           // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the directions match:
            for (ushort i = 0; i < a._directions.Count; i++)
                if (a._directions[i] != b._directions[i]) return false;

            return true;

        }
        public override int GetHashCode() {
            return _directions.Count;
        }
        public static bool operator !=(Gesture a, Gesture b) {
            return !(a == b);
        }

        public override bool Equals(System.Object obj) {
            // If parameter cannot be cast to Gesture return false:
            Gesture g = obj as Gesture;
            if ((object)g == null) {
                return false;
            }

            // Return true if the directions match:
            for (ushort i = 0; i < _directions.Count; i++)
                if (_directions[i] != g._directions[i]) return false;

            return true;
        }
    }
}