using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace TA.Usno.Extractor
    {
    internal class ExtractorApplication
        {
        private const int SignalExtractionFailed = -2;
        private const int SignalSuccess = 0;
        private const int SignalInvalidOptions = -1;
        private readonly string[] commandLineArguments;
        readonly List<string> errorMessages = new List<string>();
        private ExtractorOptions options = new ExtractorOptions();

        public ExtractorApplication(string[] args)
            {
            commandLineArguments = args;
            }

        public async Task Run()
            {
            var caseInsensitiveParser = new Parser(with =>
                {
                with.CaseSensitive = false;
                with.IgnoreUnknownArguments = false;
                with.HelpWriter = Console.Out;
                with.AutoVersion = true;
                with.AutoHelp = true;
                });

            try
                {
                var result = caseInsensitiveParser.ParseArguments<ExtractorOptions>(commandLineArguments);
                result
                    .WithParsed(options => this.options = options)
                    .WithNotParsed(errors => errors.ToList().ForEach(e => errorMessages.Add(e.ToString())));
                }
            catch (Exception ex)
                {
                errorMessages.Add(ex.Message);
                }

            if (errorMessages.Any())
                Environment.Exit(SignalInvalidOptions);

            var exitCode = await PerformUnzip(options);
            Environment.Exit(exitCode);
            }

        private async Task<int> PerformUnzip(ExtractorOptions options)
            {
            try
                {
                var sourceFiles = EnumerateSourceFiles(options.SourcePath);
                await UnzipFiles(sourceFiles);
                return SignalSuccess;
                }
            catch (Exception ex)
                {
                errorMessages.Add(ex.Message);
                return SignalExtractionFailed;
                }
            }

        private async Task UnzipFiles(IEnumerable<string> sourceFiles)
            {
            var destination = options.DestinationPath ?? options.SourcePath ?? ".";
            var destinationDirectory = Path.GetFullPath(destination);
            int count = 0;
            foreach (var file in sourceFiles)
                {
                await ExtractOne(file, destinationDirectory);
                ++count;
                }
            Console.WriteLine($"Processed {count} source files.");
            }

        /*
         * We expect teh Zip archive to contain:
         * ddd.zip {ddd = south-offset declination, SCP=0, NCP=180
         *      ddd {directory}
         *          bddd0.acc   {accelerator files}
         *          bddd0.cat   {astrometric catalogue data}
         *          bddd1.acc   {accelerator files}
         *          bddd1.cat   {astrometric catalogue data}
         *          ...
         *          bddd9.acc   {accelerator files}
         *          bddd9.cat   {astrometric catalogue data}
         *          *.
         */
        private async Task ExtractOne(string zipName, string destinationDirectory)
            {
            await using (var zipStream = new FileStream(zipName, FileMode.Open))
                {
                var zip = new System.IO.Compression.ZipArchive(zipStream, ZipArchiveMode.Read);
                Console.WriteLine($"Extracting {zipName}, {zip.Entries.Count} entries");
                zip.ExtractToDirectory(destinationDirectory);
                Console.WriteLine($"Finished {zipName}");
                }
            }

        private IEnumerable<string> EnumerateSourceFiles(string sourcePath)
            {
            var fullyQualifiedSourceDirectory = Path.GetFullPath(sourcePath);

            if (!Path.EndsInDirectorySeparator(fullyQualifiedSourceDirectory))
                throw new ArgumentException("The specified source path is not a valid directory name");

            var zipFiles =
                Directory.EnumerateFiles(fullyQualifiedSourceDirectory, "*.zip", SearchOption.TopDirectoryOnly);
            return zipFiles;
            }
        }
    }
