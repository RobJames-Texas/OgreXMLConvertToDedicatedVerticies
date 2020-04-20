namespace RJTX.Ogre.Mesh.IO.Components
{
    using RJTX.Ogre.Mesh.IO.Interfaces;
    using RJTX.Ogre.Mesh.Models;
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// An implementation of <see cref="IMeshLoader"/> for loading <see cref="Mesh"/> objects from Ogre XML.
    /// </summary>
    public class Loader : IMeshLoader
    {
        private XmlSerializer _serializer;

        /// <summary>
        /// Initializes a new instance of <see cref="Loader"/>.
        /// </summary>
        public Loader()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "mesh";
            xRoot.IsNullable = true;

            _serializer = new XmlSerializer(typeof(Mesh), xRoot);

            _serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
            _serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
        }

        /// <summary>
        /// Load a <see cref="Mesh"/> from the given file path.
        /// </summary>
        /// <param name="filename">The path to the xml file containing the mesh xml.</param>
        public Mesh Load(string filename)
        {
            Mesh mesh = null;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                XmlReader reader = new XmlTextReader(fs);
                if (_serializer.CanDeserialize(reader))
                {
                    mesh = (Mesh)_serializer.Deserialize(reader);
                }
                reader.Close();
                fs.Close();
            }
            return mesh;
        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine($"Unknown Node:{e.Name}\t{e.Text}");
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            XmlAttribute attr = e.Attr;
            Console.WriteLine($"Unknown attribute {attr.Name}='{attr.Value}'");
        }
    }
}
