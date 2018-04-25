using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Dropbox;
using MediaToolkit;
using MediaToolkit.Options;
using MediaToolkit.Model;

namespace DropboxUpload
{
    public class Uploader
    {
        public Uploader()
        {

        }

        private DropboxClient client;

        public Action<string> getProgress()
        {
            return client.Progress;
        }

        public async Task UploadVideoFile(string sourcePath, string newPath)
        {
            Console.WriteLine("Starting upload");

            // Create a new dropbox client
            client = new DropboxClient(Credentials.key, Credentials.secret);

            // Create a request to upload a file
            UploadFileRequest req = new UploadFileRequest(newPath);

            Console.WriteLine("Request created...");

            // Create a stream which pulls the data from the file on our computer that we want to upload
            FileStream stream = new FileStream(sourcePath, FileMode.Open);

            Console.WriteLine("Stream created...");

            Console.WriteLine("Uploading file...");

            // Start the upload
            PutFileResult res = await client.UploadFileAsync(req, stream, Credentials.apiKey);

            Console.WriteLine("Upload finished");

        }

        public string getVideoThumbnail( string filePath )
        {

            Directory.CreateDirectory(Path.GetTempPath() + "musicteacherapp");

            var inputFile = new MediaFile { Filename = filePath };
            var outputFile = new MediaFile { Filename = Path.GetTempPath() + @"musicteacherapp\" + Path.GetFileNameWithoutExtension(filePath) + ".jpg" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                // Saves a thumbnail frame
                var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(1) };
                engine.GetThumbnail(inputFile, outputFile, options);
            }

            return outputFile.Filename;
        }
    }
}
