using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Codelyzer.Analysis.Model
{
    public class ProjectWorkspace
    {
        [JsonProperty("version", Order = 1)] 
        public string Version { get; set; } = "1.0";

        [JsonProperty("generated-by", Order = 2)]
        public string GeneratedBy { get; set; }

        [JsonProperty("workspace-name", Order = 3)]
        public string ProjectName { get; }
        
        [JsonProperty("workspace-root-path", Order = 4)]
        public string ProjectRootPath { get; }

        [JsonProperty("source-files", Order = 5)]
        public UstList<string> SourceFiles;

        [JsonProperty("errors-found", Order = 6)]
        public int BuildErrorsCount { get; set; }

        [JsonProperty("target-framework", Order = 7)]
        public string TargetFramework { get; set; }

        [JsonProperty("target-frameworks", Order = 8)]
        public List<string> TargetFrameworks { get; set; }

        [JsonProperty("external-references", Order = 9)]
        public ExternalReferences ExternalReferences { get; set; }

        [JsonProperty("source-file-results", Order = 10)]
        public UstList<RootUstNode> SourceFileResults;

        [JsonProperty("workspace-path", Order = 11)]
        public string ProjectFilePath { get; }
        
        [JsonProperty("build-errors", Order = 12)]
        public List<String> BuildErrors { get; set; }

        [JsonProperty("project-guid", Order = 13)]
        public string ProjectGuid { get; set; }
        [JsonProperty("project-type", Order = 14)]
        public string ProjectType { get; set; }

        public ProjectWorkspace(string projectFilePath)
        {
            SourceFiles = new UstList<string>();
            ProjectFilePath = projectFilePath;
            ProjectRootPath = Path.GetDirectoryName(projectFilePath);
            ProjectName = Path.GetFileNameWithoutExtension(projectFilePath);
            SourceFileResults = new UstList<RootUstNode>();
            GeneratedBy = "Auto generated by the Codelyzer  on: " + 
                          DateTime.Now.ToString("dddd, dd MMMM yyyy") ;
        }

        public bool IsBuildFailed()
        {
            return this.BuildErrorsCount > 0 && (this.SourceFileResults == null || this.SourceFileResults.Count == 0);
        }
    }
}
