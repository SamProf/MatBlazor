using System;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Default);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;

    AbsolutePath ProjectPath => SourceDirectory / "MatBlazor" / "MatBlazor.csproj";

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    AbsolutePath PackageDirectory => ArtifactsDirectory / "package";


    string TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");


    string VersionSuffix => GitRepository.Branch + "-" + TimeStamp;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Clean, Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(ProjectPath)
                .SetConfiguration(Configuration)
                .SetVersionSuffix(VersionSuffix)
                .EnableNoRestore());
        });

    Target Pack => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetPack(_ => _
                    .SetProject(ProjectPath)
                    .SetNoBuild(InvokedTargets.Contains(Compile))
                    .SetConfiguration(Configuration)
                    .SetOutputDirectory(PackageDirectory)
                    .SetVersionSuffix(VersionSuffix)
                //.SetPackageReleaseNotes(GetNuGetReleaseNotes(ChangelogFile, GitRepository)));
            );
        });


    Target Publish => _ => _
        .DependsOn(Pack)
        .Executes(() =>
        {
            var targetPath = Directory.GetFiles(PackageDirectory, "*.nupkg").OrderByDescending(i => i).FirstOrDefault();


            DotNetNuGetPush(_ => _
                .SetSource("https://api.nuget.org/v3/index.json")
                .SetApiKey(Environment.GetEnvironmentVariable("NUGET_KEY"))
                .SetTargetPath(targetPath));
        });

    Target Default => _ => _
        .DependsOn(Publish);
}