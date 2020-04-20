using RJTX.Ogre.Mesh.IO.Components;
using RJTX.Ogre.Mesh.Models;
using System;
using System.IO;
using System.Linq;

namespace OgreXMLConvertToDedicatedVerticies
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args.FirstOrDefault();

            if (!File.Exists(filename))
            {
                Console.WriteLine("\n\nFile does not exist.\n\nThe only command line argument must be the mesh xml to convert\n\n Press any key to exit.\n\n");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n\nFile detected.\n\nBegin parsing mesh xml.\n\nCtrl-C to exit.\n\n");

            Loader loader = new Loader();
            Mesh mesh = loader.Load(filename);

            if (mesh is null)
            {
                throw new ApplicationException("Mesh was null");
            }
            if (mesh.SubMeshes.Length > 1)
            {
                throw new ArgumentException("Currently only mesh files with a single submesh are supported.");
            }

            Mesh dedicatedMesh = SharedVertConverter.Convert(mesh);

            Console.WriteLine("Press any key to convert your mesh xml to a dedicated verticies version.");
            Console.ReadKey();

            // First backup the old file.
            string backupFile = $"{filename}.BACKUP";
            bool makeBackup = true;
            if (File.Exists(backupFile))
            {
                ConsoleKey response;
                do
                {
                    Console.WriteLine("Backupfile already exists.");
                    Console.WriteLine("\tSkip making backup? (S)");
                    Console.WriteLine("\tOverwrite the existing backup? (O)");
                    Console.WriteLine("\tExit the application? (E)");
                    response = Console.ReadKey(false).Key;
                    Console.WriteLine();
                }
                while (response != ConsoleKey.S && response != ConsoleKey.O && response != ConsoleKey.E);

                bool overwrite = response == ConsoleKey.O;
                bool exit = response == ConsoleKey.E;
                if (exit)
                {
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                    return;
                }
                makeBackup = overwrite; // This will also handle if they pressed S.
            }
            if (makeBackup)
            {
                string backup = $"{filename}.BACKUP";
                Console.WriteLine($"Creating backup file ${backup}");
                File.Copy(filename, backup, true);
            }
            else
            {
                Console.WriteLine("Skipping creation of backup file.");
            }

            Writer writer = new Writer();

            try
            {
                writer.Write(dedicatedMesh, filename);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR!!!\n");
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Finished writing mesh xml. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
