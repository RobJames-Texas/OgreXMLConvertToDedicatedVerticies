using System;
using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    [Serializable]
    [XmlRoot("mesh")]
    public class Mesh
    {
        [XmlArray("submeshes")]
        [XmlArrayItem("submesh")]
        public SubMesh[] SubMeshes { get; set; }

        [XmlElement("skeletonlink")]
        public SkeletonLink SkeletonLink { get; set; }

        [XmlElement("sharedgeometry")]
        public Geometry SharedGeometry { get; set; }

        [XmlArray("boneassignments")]
        [XmlArrayItem("vertexboneassignment")]
        public VertexBoneAssignment[] BoneAssignments { get; set; }
    }
}
