using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DropboxUpload;

namespace ConsoleApp
{
    class DropboxAPI
    {
        static void Main(string[] args)
        {
            MainAsync(args);

            // Deprecated, using windows forms instead

            Console.ReadLine();
        }

        static async void MainAsync(string[] args)
        {
            Uploader testUpload = new Uploader();
            await testUpload.UploadVideoFile(@"E: \Users\Nathaniel\Videos\Sample Videos\Bear.wmv", "ITSABEAR.wmv");
        }

        public static async void UploadVideo()
        {

        }
    }
}
