using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Gebied
    {
        private int id;
        private double x;
        private double y;
        private int zoom;

        public int Id { get { return id; } set { id = value; } }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public int Zoom { get { return zoom; } set { zoom = value; } }

        public Gebied(int id, double x, double y, int zoom)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.zoom = zoom;
        }
    }
}
