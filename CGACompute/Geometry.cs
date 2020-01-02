using System.Collections.Generic;

namespace CGACompute
{
    /// <summary>
    /// This class represents tha base class for all geometries.
    /// </summary>
    public class Geometry : Shape
    {
        public List<Polygon> Polygons { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Geometry()
        {
            this.Polygons = new List<Polygon>();
        }
    }
}
