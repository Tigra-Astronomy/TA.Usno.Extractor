// This file is part of the TA.Usno.Extractor project
// Copyright © -2019 Tigra Astronomy, all rights reserved.

using CommandLine;

namespace TA.Usno.Extractor {
    class ExtractorOptions
        {
        [Option(shortName:'s', longName:"SourceDirectory", Default = ".")]
        public string SourcePath { get; set; }

        [Option(shortName: 'd', longName: "DestinationDirectory")]
        public string DestinationPath { get; set; }
        }
    }