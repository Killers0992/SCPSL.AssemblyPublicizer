using BepInEx.AssemblyPublicizer;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

await Host.CreateDefaultBuilder()
    .RunCommandLineApplicationAsync<AppCommand>(args);

[Command(Description = "Runs assembly publicizer.")]
public class AppCommand
{
    [Required]
    [Option(Description = "Assemblies to publicize.")]
    public string Assemblies { get; set; } = null;

    public string SLReferencesPath => Environment.GetEnvironmentVariable("SL_REFERENCES");

    public async Task<int> OnExecute(IConsole console)
    {
        try
        {
            string[] assembliesToPublicize = Assemblies.Split(",");

            List<string> publicized = new List<string>();

            foreach(var assemblyName in assembliesToPublicize)
            {
                string targetPath = Path.Combine(SLReferencesPath, assemblyName);

                if (!File.Exists(targetPath)) continue;

                string publicizePath = Path.Combine(SLReferencesPath, Path.GetFileName(assemblyName) + "-Publicized.dll");

                AssemblyPublicizer.Publicize(targetPath, publicizePath);

                Console.WriteLine($"Publicized {assemblyName} -> {publicizePath}");
            }
            return 0;
        }
        catch (Exception ex)
        {
            console.WriteLine(ex);
            return 1;
        }
    }
}