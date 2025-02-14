using GitVersion.Configuration;
using GitVersion.Logging;

namespace GitVersion;

public class Arguments
{
    public AuthenticationInfo Authentication = new();

    public string? ConfigFile;
    public GitVersionConfiguration? OverrideConfig;
    public bool ShowConfig;

    public string? TargetPath;

    public bool UpdateWixVersionFile;

    public string? TargetUrl;
    public string? TargetBranch;
    public string? CommitId;
    public string? ClonePath;

    public bool Init;
    public bool Diag;
    public bool IsVersion;
    public bool IsHelp;

    public bool NoFetch;
    public bool NoCache;
    public bool NoNormalize;

    public string? LogFilePath;
    public string? ShowVariable;
    public string? OutputFile;
    public ISet<OutputType> Output = new HashSet<OutputType>();
    public Verbosity Verbosity = Verbosity.Normal;

    public bool UpdateProjectFiles;
    public bool UpdateAssemblyInfo;
    public bool EnsureAssemblyInfo;
    public ISet<string> UpdateAssemblyInfoFileName = new HashSet<string>();

    public GitVersionOptions ToOptions()
    {
        var gitVersionOptions = new GitVersionOptions
        {
            AssemblyInfo =
            {
                UpdateProjectFiles = UpdateProjectFiles,
                UpdateAssemblyInfo = UpdateAssemblyInfo,
                EnsureAssemblyInfo = EnsureAssemblyInfo,
                Files = UpdateAssemblyInfoFileName
            },

            Authentication =
            {
                Username = this.Authentication.Username,
                Password = this.Authentication.Password,
                Token = this.Authentication.Token
            },

            ConfigInfo =
            {
                ConfigFile = ConfigFile,
                OverrideConfig = OverrideConfig,
                ShowConfig = ShowConfig
            },

            RepositoryInfo =
            {
                TargetUrl = TargetUrl,
                TargetBranch = TargetBranch,
                CommitId = CommitId,
                ClonePath = ClonePath
            },

            Settings =
            {
                NoFetch = NoFetch,
                NoCache = NoCache,
                NoNormalize = NoNormalize
            },

            WixInfo =
            {
                ShouldUpdate = UpdateWixVersionFile
            },

            Init = Init,
            Diag = Diag,
            IsVersion = IsVersion,
            IsHelp = IsHelp,

            LogFilePath = LogFilePath,
            ShowVariable = ShowVariable,
            Verbosity = Verbosity,
            Output = Output,
            OutputFile = OutputFile
        };

        var workingDirectory = this.TargetPath?.TrimEnd('/', '\\');
        if (workingDirectory != null)
        {
            gitVersionOptions.WorkingDirectory = workingDirectory;
        }

        return gitVersionOptions;
    }
}
