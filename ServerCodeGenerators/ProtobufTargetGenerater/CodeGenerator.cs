using ProtobufCodeGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtobufTargetGenerater
{
    internal class CodeGenerator
    {
        static string GenBatchFileName = "gen_packet.bat";
        internal static void Generate()
        {
            // .proto 파일로 protoc 실행시키기
            MakeProtobufTarget();
        }

        internal static void MakeProtobufTarget()
        {
            DirectoryInfo SolutionDirInfo = PathManager.TryGetSolutionDirectoryInfo();
            Environment.CurrentDirectory = Path.Combine(SolutionDirInfo.FullName, "protoc-3.19.4-win64", "bin");
            var ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + Path.Combine(Environment.CurrentDirectory, GenBatchFileName));
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            var Process = System.Diagnostics.Process.Start(ProcessInfo);

            Process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            Process.BeginOutputReadLine();

            Process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            Process.BeginErrorReadLine();

            Process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", Process.ExitCode);
            Process.Close();
        }
    }
}
