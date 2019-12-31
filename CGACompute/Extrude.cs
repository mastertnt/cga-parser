using CGAParser;
using SharpDX;

namespace CGACompute
{
    /// <summary>
    /// Extrude algorithm.
    /// </summary>
    public class Extrude : Algorithm<Polygon, Geometry>
    {
        /// <summary>
        /// Distance of extrusion.
        /// </summary>
        public float Distance
        {
            get;
            private set;
        }

        /// <summary>
        /// Extrusion type.
        /// </summary>
        public ExtrusionType ExtrusionType
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the extrude algorithm.
        /// </summary>
        /// <param name="pDistance">The distance to applies.</param>
        /// <param name="pExtrusionType">The type of extrusion.</param>
        public Extrude(float pDistance, ExtrusionType pExtrusionType = ExtrusionType.World_Up)
        {
            this.Distance = pDistance;
            this.ExtrusionType = pExtrusionType;
        }

        /// <summary>
        /// This method computes the geometry based on the incoming polygon.
        /// </summary>
        /// <param name="pSource">The source polygon.</param>
        /// <returns>The computed geometry.</returns>
        public Geometry Compute(Polygon pSource)
        {
            Geometry lResult = new Geometry();
            switch (this.ExtrusionType)
            {
                case ExtrusionType.World_Up:
                {
                    // First clone the polygon and add it to the geometry.
                    Polygon lBase = (Polygon)pSource.Clone();
                    Polygon lTop = new Polygon();
                    foreach (Vector3 lVertex in lBase.Vertices)
                    {
                        lTop.Vertices.Add(new Vector3(lVertex.X, lVertex.Y + this.Distance, lVertex.Y));
                    }

                    lTop.Normal = lBase.Normal;
                }
                   break;

                case ExtrusionType.Face_Normal:
                {

                }
                    break;

                case ExtrusionType.Vertex_Normal:
                {

                }
                    break;

                case ExtrusionType.WorldUp_FlatTop:
                {

                }
                    break;
            }

            return lResult;
        }
    }
}
