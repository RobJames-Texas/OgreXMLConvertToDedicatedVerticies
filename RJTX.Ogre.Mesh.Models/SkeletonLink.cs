using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    public class SkeletonLink
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
