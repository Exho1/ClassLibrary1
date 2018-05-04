using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Sharing;
using Dropbox.Api.Sharing.Routes;

using MediaToolkit;
using MediaToolkit.Options;
using MediaToolkit.Model;

namespace DropboxUpload
{
    public class Uploader
    {
        private HttpClient webClient;
        private DropboxClient client;

        private string uploadFrom;
        private string fileName;

        private float uploadProgress = 0f;

        private string[] validExtensions =
            {
                // Common enough video extensions
                ".mov", ".avi", ".mov", ".qt", ".wmv", ".flv", ".mp4", ".m4v", ".mpg", ".mpeg", ".m4v", 

                // And some audio extensions
                ".mp3", ".m4a", ".aac", ".oga", ".wav", ".mp2"
            };


        /// <summary>
        /// The Uploader class creates a Dropbox Client which communicates via their V2 API to upload files to the shared folder
        /// </summary>
        public Uploader()
        {

            webClient = new HttpClient(new WebRequestHandler { ReadWriteTimeout = 10 * 1000 })
            {
                Timeout = TimeSpan.FromMinutes(.05)
            };

            client = new DropboxClient(Credentials.apiKey);
        }

        /// <summary>
        /// Uploads a video file to Dropbox
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="newPath"></param>
        /// <returns></returns>
        public async Task<string> UploadVideoFile(string sourcePath, string newPath)
        {

            string toBeUploadedExt = Path.GetExtension(sourcePath).ToLower();

            if (!validExtensions.Contains(toBeUploadedExt))
            {
                Console.WriteLine("Denied upload. File extension: " + toBeUploadedExt + " is not on the white list");
                return "Upload Denied";
            }

            string newURL = await ChunkUpload(newPath, sourcePath);

            return newURL;
        }

        public float getProgress()
        {
            return uploadProgress;
        }

        public string[] getValidExtensions()
        {
            return validExtensions;
        }

        public override string ToString()
        {
            return "Dropbox Uploader: Src:" + uploadFrom + ", File:" + fileName;
        }

        private async Task<string> createSharedURL(string newFileName, FileMetadata m)
        {
            // Create a new API call to get all the shared links
            ListSharedLinksArg arg = new ListSharedLinksArg();
            ListSharedLinksResult sharedResult = await client.Sharing.ListSharedLinksAsync(arg);

            // Returns a list of all shared links in the dropbox
            IList<SharedLinkMetadata> allSharedLinks = sharedResult.Links;

            for (int i = 0; i < allSharedLinks.Count; i++)
            {
                // Checks if we already have a shared link for this file
                if (allSharedLinks[i].Name.ToLower() == newFileName.ToLower())
                {
                    Console.WriteLine("URL already exists for file upload");
                    return allSharedLinks[i].Url;
                }
            }

            // Create a new shared link for that dropbox file
            CreateSharedLinkWithSettingsArg createSharedLinkArg = new CreateSharedLinkWithSettingsArg(m.PathLower);

            try
            {
                // Get the metadata
                SharedLinkMetadata data = await client.Sharing.CreateSharedLinkWithSettingsAsync(createSharedLinkArg);

                Console.WriteLine("URL: " + data.Url);
                return data.Url;
            }
            catch (Exception e)
            {
                // This code should never hit because we already check if it exists earlier but better safe than sorry
                Console.WriteLine("Url already exists (unreachable code here)");
                return e.Message;
            }

        }

        private async Task<string> ChunkUpload(string newFileName, string sourcePath)
        {
            Console.WriteLine("Chunk upload file...");

            uploadFrom = sourcePath;
            fileName = newFileName;

            // Uploads 500kb at a time
            const int chunkSize = 512 * 1024;

            FileStream stream;

            using (stream = new FileStream(sourcePath, FileMode.Open))
            {
                int numChunks = (int)Math.Ceiling((double)stream.Length / chunkSize);

                byte[] buffer = new byte[chunkSize];
                string sessionId = null;

                for (var idx = 0; idx < numChunks; idx++)
                {
                    Console.WriteLine("Start uploading chunk {0}/{1}", idx, numChunks);
                    var byteRead = stream.Read(buffer, 0, chunkSize);

                    uploadProgress = (idx * 1.0f / numChunks);

                    using (MemoryStream memStream = new MemoryStream(buffer, 0, byteRead))
                    {
                        if (idx == 0)
                        {
                            var result = await client.Files.UploadSessionStartAsync(body: memStream);
                            sessionId = result.SessionId;
                        }

                        else
                        {
                            UploadSessionCursor cursor = new UploadSessionCursor(sessionId, (ulong)(chunkSize * idx));

                            FileMetadata meta = new FileMetadata("null", "null", DateTime.Today, DateTime.Today, "2aba38830", 0);

                            if (idx == numChunks - 1)
                            {
                                meta = await client.Files.UploadSessionFinishAsync(cursor, new CommitInfo("/" + newFileName), memStream);

                                return await createSharedURL(newFileName, meta);

                               // Console.WriteLine("File can be found at : " + f);
                            }

                            else
                            {
                                await client.Files.UploadSessionAppendV2Async(cursor, body: memStream);
                            }

                        }
                    }
                }
            }

            return "null";
        }

        public string getVideoThumbnail(string filePath)
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
