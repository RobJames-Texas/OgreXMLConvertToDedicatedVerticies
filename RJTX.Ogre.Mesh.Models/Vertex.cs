using System;
using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    [Serializable]
    [XmlRoot("vertexbuffer")]
    public class Vertex
    {
        [XmlElement("position")]
        public Position Position { get; set; }

        [XmlElement("normal")]
        public Normal Normal { get; set; }

        [XmlElement("texcoord")]
        public TexCoord TexCoord { get; set; }
    }
}
