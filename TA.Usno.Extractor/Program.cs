using System;
using System.Threading.Tasks;

namespace TA.Usno.Extractor
    {
    class Program
        {
        static async Task Main(string[] args)
            {
            var application = new ExtractorApplication(args);
            await application.Run();
            }
        }
    }
