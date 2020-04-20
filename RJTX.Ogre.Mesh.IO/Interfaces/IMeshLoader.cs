namespace RJTX.Ogre.Mesh.IO.Interfaces
{
    using RJTX.Ogre.Mesh.Models;

    /// <summary>
    /// Allows an object to handle loading <see cref="Mesh"/> objects.
    /// </summary>
    public interface IMeshLoader
    {
        /// <summary>
        /// Load a <see cref="Mesh"/> from the given file path.
        /// </summary>
        Mesh Load(string filename);
    }
}
