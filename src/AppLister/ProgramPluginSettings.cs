﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace AppLister
{
    public class ProgramPluginSettings
    {
        public DateTime LastIndexTime { get; set; }

        public List<ProgramSource> ProgramSources { get; set; } = new();

        //public List<DisabledProgramSource> DisabledProgramSources { get; set; } = new List<DisabledProgramSource>();

        public List<string> ProgramSuffixes { get; set; } = new List<string>() { "bat", "appref-ms", "exe", "lnk", "url" };

        public bool EnableStartMenuSource { get; set; } = true;

        public bool EnableDesktopSource { get; set; } = true;

        public bool EnableRegistrySource { get; set; } = true;

        public bool EnablePathEnvironmentVariableSource { get; set; } = true;

        public double MinScoreThreshold { get; set; } = 0.75;

        internal const char SuffixSeparator = ';';
    }
}
