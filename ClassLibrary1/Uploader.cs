using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Dropbox;

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
    }
}
