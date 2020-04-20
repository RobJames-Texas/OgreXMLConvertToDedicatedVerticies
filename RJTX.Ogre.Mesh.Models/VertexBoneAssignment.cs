using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    public class VertexBoneAssignment
    {
        [XmlAttribute("boneindex")]
        public long BoneIndex { get; set; }

        [XmlAttribute("vertexindex")]
        public long VertexIndex { get; set; }

        [XmlAttribute("weight")]
        public decimal Weight { get; set; }
    }
}
