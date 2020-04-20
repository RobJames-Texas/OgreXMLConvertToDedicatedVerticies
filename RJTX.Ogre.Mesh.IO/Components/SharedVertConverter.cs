namespace RJTX.Ogre.Mesh.IO.Components
{
    using RJTX.Ogre.Mesh.Models;
    using System.Linq;

    /// <summary>
    /// Class used to convert from a <see cref="Mesh"/> with shared verticies, to a <see cref="Mesh"/> without shared verticies.
    /// </summary>
    public static class SharedVertConverter
    {
        /// <summary>
        /// Method to take a <see cref="Mesh"/> object with shared verticies and create a new <see cref="Mesh"/> that does not used shared verticies.
        /// </summary>
        public static Mesh Convert(Mesh shared)
        {
            var dedicated = new Mesh
            {
                SkeletonLink = shared.SkeletonLink,
                SubMeshes = new SubMesh[] 
                {
                    ConvertSubMesh(shared.SubMeshes.First(), shared.SharedGeometry, shared.BoneAssignments)
                }
            };

            return dedicated;
        }

        private static SubMesh ConvertSubMesh(SubMesh sharedSubMesh, Geometry geometry, VertexBoneAssignment[] boneAssignments)
        {
            return new SubMesh
            {
                Faces = sharedSubMesh.Faces,
                BoneAssignments = boneAssignments,
                Geometry = geometry,
                Material = sharedSubMesh.Material,
                OperationType = sharedSubMesh.OperationType,
                Use32BitIndexes = sharedSubMesh.Use32BitIndexes,
                UseSharedVerticies = false
            };
        }
    }
}
