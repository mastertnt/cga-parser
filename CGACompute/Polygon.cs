using System;
using System.Collections.Generic;
using SharpDX;


namespace CGACompute
{
    /// <summary>
    /// This class represents a polygon.
    /// </summary>
    public class Polygon : Shape, ICloneable
    {
        /// <summary>
        /// Gets the normal.
        /// </summary>
        public Vector3 Normal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the list of vertices.
        /// </summary>
        public List<Vector3> Vertices
        {
            get;
            set;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Polygon()
        {
            this.Normal = Vector3.UnitY;
            this.Vertices = new List<Vector3>();
        }

        /// <summary>
        /// Clones the object.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Polygon lClone = new Polygon();
            foreach (Vector3 lVertex in this.Vertices)
            {
                lClone.Vertices.Add(new Vector3(lVertex.X, lVertex.Y, lVertex.Z));
            }
            lClone.Normal = this.Normal;
            return lClone;
        }
    }
}
