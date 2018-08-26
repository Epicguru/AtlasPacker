using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;

using TInput = System.String;
using TOutput = System.String;

namespace AtlasPacker
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to import a file from disk into the specified type, TImport.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentImporter attribute to specify the correct file
    /// extension, display name, and default processor for this importer.
    /// </summary>

    [ContentImporter(".atlas", DisplayName = "Texture Atlas Importer", DefaultProcessor = "AtlasProcessor")]
    public class AtlasImporter : ContentImporter<AtlasDec>
    {

        public override AtlasDec Import(string filename, ContentImporterContext context)
        {
            // TODO: process the input object, and return the modified data.
            string fileName = Path.GetFileNameWithoutExtension(filename).Trim();
            string parentDir = Path.GetDirectoryName(filename);

            // Look for a folder with the same name as this file...
            string folder = Path.Combine(parentDir, fileName);
            bool exists = Directory.Exists(folder);
            if (!exists)
            {
                throw new Exception("Failed to import the atlas, adjacent source folder '" + folder + "' was not found!");
            }

            string search = "*.png";
            var found = Directory.EnumerateFiles(folder, search, SearchOption.AllDirectories);
            var files = found.ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                var f = files[i];
                context.AddDependency(f);
            }
            AtlasDec dec = new AtlasDec(folder, fileName, files);

            context.Logger.LogMessage("Imported atlas with " + files.Length + " files.");

            return dec;
        }

    }

}
