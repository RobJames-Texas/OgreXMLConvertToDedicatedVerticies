using System;
using System.Xml.Serialization;

namespace RJTX.Ogre.Mesh.Models
{
    [Serializable]
    public class SubMesh
    {
        [XmlAttribute("material")]
        public string Material { get; set; }

        [XmlAttribute("operationtype")]
        public string OperationType { get; set; }

        [XmlAttribute("use32bitindexes")]
        public string Use32BitIndexes { get; set; }

        [XmlAttribute("usesharedvertices")]
        public bool UseSharedVerticies { get; set; }

        [XmlArray("faces")]
        [XmlArrayItem("face")]
        public Face[] Faces { get; set; }

        [XmlElement("geometry")]
        public Geometry Geometry { get; set; }

        [XmlArray("boneassignments")]
        [XmlArrayItem("vertexboneassignment")]
        public VertexBoneAssignment[] BoneAssignments { get; set; }
    }
}
