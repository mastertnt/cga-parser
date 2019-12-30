using System.Collections.Generic;
using Sprache;

namespace CGAParser
{
    /// <summary>
    /// Type of component selector.
    /// </summary>
    public enum CompSelector
    {
        Faces,
        Edges,
        FaceEdges,
        Vertices,
        Groups,
        Materials,
        Holes,
    }

    /// <summary>
    /// Type of component normal.
    /// </summary>
    public enum ComponentNormal
    {
        Front,
        Back,
        Left,
        Right,
        Top,
        Bottom,
    }

    /// <summary>
    /// Comp operation.
    /// See : https://doc.arcgis.com/en/cityengine/latest/cga/cga-extrude.htm
    /// comp (compSelector) { selector operator operations | ... }
    /// </summary>
    public class Comp
    {
        public static readonly Parser<CompSelector> PARSER_COMPSELECTOR = Common.CreateEnumParser(new Dictionary<CompSelector, string>() {
            { CompSelector.Faces, "f" },
            { CompSelector.Edges, "e" },
            { CompSelector.FaceEdges, "fe" },
            { CompSelector.Vertices, "v" },
            { CompSelector.Groups, "g" },
            { CompSelector.Materials, "m" },
            { CompSelector.Holes, "h" }
        });

        public static readonly Parser<ComponentNormal> PARSER_COMPONENTNORMAL = Common.CreateEnumParser(new Dictionary<ComponentNormal, string>() {
            { ComponentNormal.Front, "front" },
            { ComponentNormal.Back, "back" },
            { ComponentNormal.Left, "left" },
            { ComponentNormal.Right, "right" },
            { ComponentNormal.Top, "top" },
            { ComponentNormal.Bottom, "bottom" },
        });
    }
}
