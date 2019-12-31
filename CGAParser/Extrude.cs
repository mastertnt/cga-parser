using System.Collections.Generic;
using Sprache;

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

    /// <summary>
    /// Extrude operation.
    /// See : https://doc.arcgis.com/en/cityengine/latest/cga/cga-extrude.htm
    /// extrude (distance)
    /// extrude (extrusionType, distance)
    /// </summary>
    public class Extrude : Operation
    {
        /// <summary>
        /// Parser for extrusion type.
        /// </summary>
        public static readonly Parser<ExtrusionType> PARSER_EXTRUSION_TYPE = Common.CreateEnumParser<ExtrusionType>(new Dictionary<ExtrusionType, string>() {
            { ExtrusionType.World_Up, "world.up" },
            { ExtrusionType.WorldUp_FlatTop, "world.up.flatTop" },
            { ExtrusionType.Face_Normal, "face.normal" },
            { ExtrusionType.Vertex_Normal, "vertex.normal" }
        });

        /// <summary>
        /// First form for extrude operation.
        /// </summary>
        public static readonly Parser<Extrude> PARSER_1 =
        from lIdentifier in Sprache.Parse.String("extrude")
        from lWhiteSpace0 in Common.SPACE.Many()
        from lOpenParenthesis in Sprache.Parse.Char('(')
        from lWhiteSpace1 in Common.SPACE.Many()
        from lDistance in Float.PARSER
        from lWhiteSpace2 in Common.SPACE.Many()
        from lCloseParenthesis in Sprache.Parse.Char(')')
        select new Extrude(lDistance.TypedValue);

        /// <summary>
        /// Second form for extrude operation.
        /// </summary>
        public static readonly Parser<Extrude> PARSER_2 =
        from lIdentifier in Sprache.Parse.String("extrude")
        from lWhiteSpace0 in Common.SPACE.Many()
        from lOpenParenthesis in Sprache.Parse.Char('(')
        from lWhiteSpace2 in Common.SPACE.Many()
        from lEnumValue in PARSER_EXTRUSION_TYPE
        from lWhiteSpace3 in Common.SPACE.Many()
        from lComma in Sprache.Parse.Char(',')
        from lWhiteSpace4 in Common.SPACE.Many()
        from lDistance in Float.PARSER
        from lWhiteSpace5 in Common.SPACE.Many()
        from lCloseParenthesis in Sprache.Parse.Char(')')
        select new Extrude(lEnumValue, lDistance.TypedValue);

        /// <summary>
        /// Main parser for extrude operation.
        /// </summary>
        public static readonly Parser<Extrude> PARSER = Extrude.PARSER_1.Or(Extrude.PARSER_2);

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Extrude(float pDistance)
        :base("extrude", new List<AArgument> () { new Float(pDistance)} )
        {

        }

        public Extrude(ExtrusionType pExtrusionType, float pDistance)
            : base("extrude", new List<AArgument> () {new Enumeration<ExtrusionType>(pExtrusionType), new Float(pDistance)} )
        {

        }
    }
}
