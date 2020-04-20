namespace RJTX.Ogre.Mesh.IO.Components
{
    using RJTX.Ogre.Mesh.IO.Interfaces;
    using RJTX.Ogre.Mesh.Models;
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// An implementation of <see cref="IMeshWriter"/> for writing <see cref="Mesh"/> objects to Ogre XML.
    /// </summary>
    public class Writer : IMeshWriter
    {
        private XmlSerializer _serializer;

        /// <summary>
        /// Initializes a new instance of <see cref="Writer"/>.
        /// </summary>
        public Writer()
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            _serializer = new XmlSerializer(typeof(Mesh), overrides);
        }

        /// <summary>
        /// Write the given <see cref="Mesh"/> to the given file path.
        /// </summary>
        public void Write(Mesh mesh, string path)
        {
            (new FileInfo(path)).Directory.Create();

            Console.WriteLine($"Writing {path}");
            using (TextWriter writer = new StreamWriter(path))
            {
                _serializer.Serialize(writer, mesh);
                writer.Close();
            }
        }
    }
}
