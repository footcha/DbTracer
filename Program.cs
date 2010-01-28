/* $Archive: RD Prague/DatabaseUpdater/source/Rdigest.Cz.DatabaseUpdater/Program.cs$
 * $Header: Program.cs: Revision: 2: Author: pkozele: Date: Wednesday, September 30, 2009 3:08:55 AM$
 * Reader's Digest Prague, Czech Republic
 *
 * $Log$
 * pkozele - Wednesday, September 30, 2009 3:08:55 AM
 * Added transaction.
 * pkozele - Tuesday, September 29, 2009 11:29:21 PM
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using Plossum.CommandLine;
using Rdigest.CZ.DatabaseUpdater.ScriptsTableAdapters;

namespace Rdigest.Cz.DatabaseUpdater
{
    [CommandLineManager(IsCaseSensitive = false,
        EnabledOptionStyles = OptionStyles.Windows,
        Description = "Continuous integration of database schema changes.")]
    [CommandLineOptionGroup("commands", Name = "Commands",
       Require = OptionGroupRequirement.ExactlyOne)]
    [CommandLineOptionGroup("options", Name = "Options")]
    class Options
    {
        [CommandLineOption(
            Name = "install",
            Aliases = "i",
            Description = "install database schema necessary for saving information about installed scripts",
            BoolFunction = BoolFunction.TrueIfPresent,
            GroupId = "commands"
            )]
        public bool Install;

        [CommandLineOption(
            Name = "update",
            Description = "update the database",
            Aliases = "u",
            BoolFunction = BoolFunction.TrueIfPresent,
            GroupId = "commands"
        )]
        public bool Update;

        [CommandLineOption(
            Name = "no_execute",
            Aliases = "nexec",
            Description =
                "do not execute files only update information about scripts. You can use it to add already installed scripts",
            BoolFunction = BoolFunction.TrueIfPresent,
            GroupId = "commands"
            )]
        public bool NoExecute;


        [CommandLineOption(
            Name = "help",
            Aliases = "h,?",
            Description =
                "show this help",
            BoolFunction = BoolFunction.TrueIfPresent,
            GroupId = "commands"
            )]
        public Boolean Help;

        [CommandLineOption(
            Name = "connection",
            Description = "connection string to connect to datatabase",
            Aliases = "c",
            RequireExplicitAssignment = false,
            MaxOccurs = 1,
            MinOccurs = 1,
            GroupId = "options"
            )]
        public string Connection;

        [CommandLineOption(
            Name = "dir",
            Aliases = "d",
            Description = "path containing update sql scripts",
            RequireExplicitAssignment = true,
            GroupId = "options"
            )]
        public string Directory = ".";
    }

    public class Program
    {
        public enum ExitCode { OK = 0, UnknownError = 1, SqlError = 2 }

        string ScriptsDirectory;
        Scripts.ScriptsDataTable installedScripts;
        bool IsNoExecute;
        private readonly Options options;
        protected CommandLineParser parser;
        private ScriptsTableAdapter da;

        Scripts.ScriptsDataTable InstalledScripts
        {
            get
            {
                if (installedScripts == null) installedScripts = GetInstalledScriptsList();
                return installedScripts;
            }
        }

        protected static string[] FixArguments(string[] args)
        {
            var args2 = new string[args.Length + 1];
            args2[0] = "Bugfix";
            for (var i = 0; i < args.Length; ++i) args2[i + 1] = args[i].Replace(" ", @"\ ");

            return args2;
        }

        public Program()
        {
            options = new Options();
            parser = new CommandLineParser(options);
        }

        static int Main(String[] args)
        {
            var program = new Program();
            program.ShowHeader();
            try
            {
                args = FixArguments(args);
                program.parser.Parse(args);
                program.ReadConfigurations();

                try
                {
                    program.Connection = new SqlConnection(program.options.Connection);
                    program.Connection.Open();
                }
                catch (Exception e)
                {
                    ShowError("Some errors occured during establishing connection. Check parameter [/connection]");
                    ShowError(e.Message);
                    program.ShowHelp();
                    return (int)ExitCode.SqlError;
                }
                program.Transaction = program.Connection.BeginTransaction();

                var exitCode = ExitCode.OK;
                var options = program.options;
                if (options.Help)
                {
                    program.ShowHelp();
                }
                else if (options.Update) exitCode = program.Update();
                else if (options.Install) exitCode = program.Install();

                program.Transaction.Commit();
                return (int)exitCode;
            }
            catch (SqlException e)
            {
                ShowError(e.Message);
                try
                {
                    if (program.Transaction != null) program.Transaction.Rollback();
                }
                catch (Exception ex) { ShowError(ex); }
                return (int)ExitCode.SqlError;
            }
            catch (Exception e)
            {
                ShowError(e);
                return (int)ExitCode.UnknownError;
            }
        }

        private ExitCode Update()
        {
            ShowInfo("Searching for update scripts...");
            var scriptsFolderInfo = new DirectoryInfo(ScriptsDirectory);
            var counter = 0;
            foreach (var scriptFile in scriptsFolderInfo.GetFiles("*.sql"))
            {
                var hash = GetFileHash(scriptFile.FullName);
                if (IsUpdateScriptInstalled(scriptFile.Name, hash)) continue;

                var errorMessage = String.Empty;
                if (!IsNoExecute)
                {
                    ShowInfo("Installing script [{0}]...", scriptFile.Name);
                    ExecuteTSQLScript(scriptFile.FullName);
                    ShowInfo("Installed.");
                }
                else ShowInfo("Script [{0}] already installed...Skipping", scriptFile.Name);

                SaveUpdateScriptInfo(scriptFile.Name, hash, errorMessage);
                counter++;
            }
            if (counter == 0)
            {
                ShowInfo("No scripts found to install.");
                return ExitCode.OK;
            }

            var totalInstalled = counter;
            ShowInfo("{0} script{1} {2}.", totalInstalled, totalInstalled > 1 ? "s" : "", IsNoExecute ? "added" : "installed");
            return ExitCode.OK;
        }

        private ExitCode Install()
        {
            ShowInfo("Installing DatabaseUpdater to database...");
            var assembly = GetType().Assembly;
            var resourceName = string.Format("{0}.{1}", assembly.GetName().Name, InstallScriptName);
            var stream = assembly.GetManifestResourceStream(resourceName);
            var tmpFilePath = Path.Combine(Path.GetTempPath(), resourceName + new Random().Next());
            var fileStream = File.Create(tmpFilePath);
            var writer = new StreamWriter(fileStream);
            writer.Write(new StreamReader(stream).ReadToEnd());
            writer.Close();
            try
            {
                ExecuteTSQLScript(tmpFilePath);
            }
            catch (Exception)
            {
                ShowError("Some errors occured during instaling DatabaseUpdater. Maybe DatabaseUpdater is already installed.");
                throw;
            }
            finally
            {
                try { new FileInfo(tmpFilePath).Delete(); }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception) { }
                // ReSharper restore EmptyGeneralCatchClause
            }
            ShowInfo("Done");

            return 0;
        }

        void ReadConfigurations()
        {
            IsNoExecute = options.NoExecute;
            ScriptsDirectory = string.IsNullOrEmpty(options.Directory)
                               ? "."
                               : options.Directory;

            if (!Directory.Exists(ScriptsDirectory))
            {
                throw new ArgumentException(String.Format("'{0}' doesn't exist.", ScriptsDirectory));
            }

            if (!options.Update && !options.Install) ShowHelp();
        }

        protected void ShowHelp()
        {
            try
            {

                if (parser.HasErrors) Console.WriteLine(parser.UsageInfo.GetErrorsAsString(ConsoleWidth));
                Console.WriteLine(parser.UsageInfo.GetOptionsAsString(20, ConsoleWidth - 20));
            }
            catch (Exception e) { ShowError(e); }
        }

        protected void ShowHeader()
        {
            Console.WriteLine(parser.UsageInfo.GetHeaderAsString(ConsoleWidth));
            Console.WriteLine(parser.UsageInfo.ApplicationDescription);
            Console.WriteLine();
        }

        public static void ShowError(Exception e)
        {
            ShowError(e.Message);
            ShowError(e.StackTrace);
        }

        public static void ShowError(string text)
        {
            Console.Error.WriteLine("[Error] " + text);
        }

        public static void ShowInfo(string text)
        {
            ShowInfo("{0}", text);
        }

        public static void ShowInfo(string format, params object[] text)
        {
            Console.WriteLine("[Info] " + format, text);
        }

        Boolean IsUpdateScriptInstalled(String scriptName, byte[] hash)
        {
            var result = false;
            var strHash = Convert.ToBase64String(hash);
            foreach (DataRow row in InstalledScripts.Rows)
            {
                if (Convert.ToString(row["ScriptName"]).Equals(scriptName) && strHash.Equals(Convert.ToBase64String((byte[])row["Hash"])))
                {
                    result = true;
                }
            }
            return result;
        }

        void ExecuteTSQLScript(String filePath)
        {

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var sql = new StringBuilder();
                    while (!sr.EndOfStream)
                    {
                        var s = sr.ReadLine();
                        if (s != null && s.ToUpper().Trim().Equals("GO"))
                        {
                            break;
                        }
                        sql.AppendLine(s);
                    }
                    if (sql.ToString().Trim() == String.Empty) continue;
                    var cmd = Connection.CreateCommand();
                    cmd.Transaction = Transaction;
                    cmd.CommandText = sql.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void SaveUpdateScriptInfo(String fileName, byte[] hash, String errorMessage)
        {
            installedScripts.Rows.Add(null, fileName, hash, DateTime.Now, errorMessage);
            da.Update((Scripts.ScriptsDataTable)installedScripts.GetChanges(DataRowState.Added));
            installedScripts.AcceptChanges();
        }

        Scripts.ScriptsDataTable GetInstalledScriptsList()
        {
            da = new ScriptsTableAdapter
                     {
                         Connection = Connection,
                         Transaction = Transaction
                     };

            return da.GetData();
        }

        private SqlConnection Connection;
        private SqlTransaction Transaction;
        private const string InstallScriptName = "install.sql";
        private const int ConsoleWidth = 78;

        static byte[] GetFileHash(String filePath)
        {
            SHA512 hashService = new SHA512Managed();
            var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var reader = new BinaryReader(fs);
            hashService.ComputeHash(reader.ReadBytes((Int32)fs.Length));
            return hashService.Hash;
        }
    }
}