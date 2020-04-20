using System;
using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    [Serializable]
    public class Face
    {
        [XmlAttribute("v1")]
        public int V1 { get; set; }

        [XmlAttribute("v2")]
        public int V2 { get; set; }

        [XmlAttribute("v3")]
        public int V3 { get; set; }
    }
}
