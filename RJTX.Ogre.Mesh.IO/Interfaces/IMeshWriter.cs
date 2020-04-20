namespace RJTX.Ogre.Mesh.IO.Interfaces
{
    using RJTX.Ogre.Mesh.Models;

    /// <summary>
    /// Allows an object to handle writing <see cref="Mesh"/> objects.
    /// </summary>
    public interface IMeshWriter
    {
        /// <summary>
        /// Write the given <see cref="Mesh"/> to the given file path.
        /// </summary>
        void Write(Mesh mesh, string path);
    }
}
