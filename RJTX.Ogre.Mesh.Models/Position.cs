using System;
using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    [Serializable]
    public class Position
    {
        [XmlAttribute("x")]
        public decimal X { get; set; }

        [XmlAttribute("y")]
        public decimal Y { get; set; }

        [XmlAttribute("z")]
        public decimal Z { get; set; }
    }
}
