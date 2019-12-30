using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAParser
{
    /// <summary>
    /// Type of extrusion.
    /// </summary>
    public enum ExtrusionType
    {

        // Extrudes faces along the world coordinates system's y-axis. takes the face with lowest y world-coordinates
        World_Up,

        // Same as world.up but creates a flat top surface.
        WorldUp_FlatTop,

        // Each face is extruded along its normal. face.normal is the default.
        Face_Normal,

        // Extrudes face vertices along their normals. Duplicate vertices must be merged in order to compute vertex normals using adjacent face normals.
        Vertex_Normal,
    }

    ///// <summary>
    ///// Extude operation.
    ///// See : https://doc.arcgis.com/en/cityengine/latest/cga/cga-extrude.htm
    ///// </summary>
    //public class Extrude : AOperation
    //{
    //    /// <summary>
    //    /// Default constructor.
    //    /// </summary>
    //    public Extrude(float pDistance)
    //    :base("extrude")
    //    {

    //    }

    //    public Extrude(ExtrusionType pExtrusionType, float pDistance)
    //        : base("extrude")
    //    {

    //    }
    //}
}
