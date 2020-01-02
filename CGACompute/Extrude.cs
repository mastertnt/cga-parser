using System;
using CGAParser;
using SharpDX;

namespace CGACompute
{
    /// <summary>
    /// Extrude algorithm.
    /// </summary>
    public class Extrude : IAlgorithm<Polygon, Geometry>
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

        public Shape Compute(Shape pSource)
        {
            return this.Compute(pSource as Polygon);
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
                        lTop.Vertices.Add(new Vector3(lVertex.X, lVertex.Y + this.Distance, lVertex.Z));
                    }
                    lTop.Normal = lBase.Normal;
                    lResult.Polygons.Add(lBase);
                    lResult.Polygons.Add(lTop);
                    

                    // Now, create all other polygons.
                    for (int lIndex = 0; lIndex < lBase.Vertices.Count; lIndex++)
                    {
                        int lNext = (lIndex + 1) % (lBase.Vertices.Count - 1);
                        Polygon lSide = new Polygon();
                        lSide.Vertices.Add(new Vector3(lBase.Vertices[lIndex].X, lBase.Vertices[lIndex].Y, lBase.Vertices[lIndex].Z));
                        lSide.Vertices.Add(new Vector3(lBase.Vertices[lNext].X, lBase.Vertices[lNext].Y, lBase.Vertices[lNext].Z));
                        lSide.Vertices.Add(new Vector3(lTop.Vertices[lNext].X, lTop.Vertices[lNext].Y, lTop.Vertices[lNext].Z));
                        lSide.Vertices.Add(new Vector3(lTop.Vertices[lIndex].X, lTop.Vertices[lIndex].Y, lTop.Vertices[lIndex].Z));
                        lResult.Polygons.Add(lSide);
                    }

                    lTop.Normal = lBase.Normal;
                }
                   break;

                case ExtrusionType.Face_Normal:
                {
                    throw new NotSupportedException();
                }
  
                case ExtrusionType.Vertex_Normal:
                {
                    throw new NotSupportedException();
                }

                case ExtrusionType.WorldUp_FlatTop:
                {
                    throw new NotSupportedException();
                }
            }

            return lResult;
        }
    }
}
