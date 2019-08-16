// This file is part of the TA.Usno.Extractor project
// Copyright © -2019 Tigra Astronomy, all rights reserved.

using CommandLine;

namespace TA.Usno.Extractor {
    class ExtractorOptions
        {
        [Option(shortName:'s', longName:"SourceDirectory", Required = true, HelpText = "Specify the source directory where archives are located.")]
        public string SourcePath { get; set; }

        [Option(shortName: 'd', longName: "DestinationDirectory", HelpText = "Specify the destination directory for extracted files.")]
        public string DestinationPath { get; set; }

        [Option(longName:"DeleteArchives", Default = false, HelpText = "Deletes each archive after a successful extraction.")]
        public bool DeleteArchives { get; set; }
        }
    }