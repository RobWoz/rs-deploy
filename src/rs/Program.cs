using System;
using CYC.Logging.Interface;
using CYC.Logging.NLog;
using Rs.Commands;
using Rs.Verbs;

namespace Rs
{
    class Program
    {
        private static ILogger logger = new Logger("rs");

        static void Main(string[] args)
        {
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options, OnVerb))
            {
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }
        }

        static void OnVerb(string verb, object subOptions)
        {
            if (verb == VerbNames.UploadFile)
            {
                var uploadFileSubOptions = (UploadFileSubOptions)subOptions;
                new UploadFileVerb(uploadFileSubOptions, logger).Process();
            }
        }
    }
}
