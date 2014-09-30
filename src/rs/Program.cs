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

        static void OnVerb(string verb, object options)
        {
            try
            {
                switch (verb)
                {
                    case VerbNames.UploadFile:
                        UploadFile(options);
                        break;

                    case VerbNames.UploadFolder:
                        UploadFolder(options);
                        break;

                    case VerbNames.CreateDatasources:
                        CreateDatasources(options);
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Unexpected error", ex);
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }
            
        }

        private static void UploadFile(object options)
        {
            var uploadFileSubOptions = (UploadFileSubOptions)options;
            new UploadFileVerb(uploadFileSubOptions, logger).Process(); 
        }

        private static void UploadFolder(object options)
        {
            var uploadFileSubOptions = (UploadFolderSubOptions)options;
            new UploadFolderVerb(uploadFileSubOptions, logger).Process();
        }

        private static void CreateDatasources(object options)
        {
            var createDatasourcesSubOptions = (CreateDatasourcesSubOptions)options;
            new CreateDatasourcesVerb(createDatasourcesSubOptions, logger).Process();
        }
    }
}
