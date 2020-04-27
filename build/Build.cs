using System;
using System.Collections.Generic;
using System.Globalization;
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
    public static int Main()
    {
        var autoForBranch = Environment.GetEnvironmentVariable("autoForBranch");
        if (autoForBranch == "master")
        {
            return Execute<Build>(x => x.DefaultMaster);
        }
        else if (autoForBranch == "develop")
        {
            return Execute<Build>(x => x.DefaultDevelop);
        }
        else if (autoForBranch == "preview")
        {
            return Execute<Build>(x => x.DefaultPreview);
        }
        else
        {
            return Execute<Build>(x => x.Default);
        }
    }

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;

    AbsolutePath ProjectPath => SourceDirectory / "MatBlazor" / "MatBlazor.csproj";

    AbsolutePath ProjectDemoServerAppPath =>
        SourceDirectory / "MatBlazor.Demo.ServerApp" / "MatBlazor.Demo.ServerApp.csproj";

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    AbsolutePath PackageArtifactsDDirectory => ArtifactsDirectory / "package";

    AbsolutePath DemoServerAppArtifactsDDirectory => ArtifactsDirectory / "Demo.ServerApp";

    string GITHUB_RUN_NUMBER => Environment.GetEnvironmentVariable("GITHUB_RUN_NUMBER");
    string NUGET_API_KEY => Environment.GetEnvironmentVariable("NUGET_API_KEY");

    readonly DateTime TimeStamp = DateTime.Now;

    static string GetBranchName(string v)
    {
        var str1 = "refs/heads/";
        if (v.StartsWith(str1))
        {
            return v.Remove(0, str1.Length);
        }

        return v;
    }


    string BranchName
    {
        get { return GetBranchName(GitRepository.Branch); }
    }


    string VersionSuffix
    {
        get
        {
            var branchPrefix =
                new string(BranchName.Select(i => (Char.IsDigit(i) || Char.IsLetter(i)) ? i : '-').ToArray());

            if (GITHUB_RUN_NUMBER == null)
            {
                var buildVersion1 =
                    ((int) (TimeStamp.ToUniversalTime() - new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                        .TotalDays).ToString("0000");
                var buildVersion2 =
                    (TimeStamp.ToUniversalTime() - TimeStamp.ToUniversalTime().Date).TotalSeconds.ToString("00000");
                return branchPrefix + "-" + "build" + "-" + buildVersion1 + "-" + buildVersion2;
            }

            if (string.Equals(BranchName, "master", StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return branchPrefix + "-" + int.Parse(GITHUB_RUN_NUMBER).ToString("0000");
        }
    }


    [PathExecutable(@"ssh")] readonly Tool SSH;
    [PathExecutable(@"scp")] readonly Tool SCP;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            // EnsureCleanDirectory(ArtifactsDirectory);
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
                .SetProjectFile(Solution.Path)
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
                    .SetOutputDirectory(PackageArtifactsDDirectory)
                    .SetVersionSuffix(VersionSuffix)
            );
        });


    Target Publish => _ => _
        .DependsOn(Pack)
        .Executes(() =>
        {
            var targetPath = Directory.GetFiles(PackageArtifactsDDirectory, "*.nupkg")
                .OrderByDescending(i => i)
                .FirstOrDefault();

            DotNetNuGetPush(_ => _
                .SetSource("https://api.nuget.org/v3/index.json")
                .SetApiKey(NUGET_API_KEY)
                .SetTargetPath(targetPath));
        });


    Target Deploy => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetPublish(s => s
                .SetProject(ProjectDemoServerAppPath)
                .SetNoBuild(InvokedTargets.Contains(Compile))
                .SetConfiguration(Configuration)
                .SetVersionSuffix(VersionSuffix)
                .EnableNoRestore()
                .SetOutput(DemoServerAppArtifactsDDirectory)
            );


            SCP($"-r {DemoServerAppArtifactsDDirectory}/* root@srv5.samprof.com:/var/host/www.matblazor.com/web/");

            SSH($"root@srv5.samprof.com sudo systemctl restart www.matblazor.com.service");
        });

    Target Default => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
        });

    Target DefaultMaster => _ => _
        .DependsOn(Compile, Publish, Deploy)
        .Executes(() =>
        {
        });


    Target DefaultDevelop => _ => _
        .DependsOn(Compile, Publish)
        .Executes(() =>
        {
        });


    Target DefaultPreview => _ => _
        .DependsOn(Compile, Publish)
        .Executes(() =>
        {
        });
}