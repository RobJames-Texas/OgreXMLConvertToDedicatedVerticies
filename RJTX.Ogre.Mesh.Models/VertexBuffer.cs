using System;
using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    [Serializable]
    public class VertexBuffer
    {
        [XmlAttribute("colours_diffuse")]
        public string ColoursDiffuse { get; set; }

        [XmlAttribute("normals")]
        public bool Normals { get; set; }

        [XmlAttribute("positions")]
        public bool Positions { get; set; }

        [XmlAttribute("texture_coords")]
        public int TextureCoords { get; set; }

        [XmlElement("vertex")]
        public Vertex[] Vertices { get; set; }
    }
}
