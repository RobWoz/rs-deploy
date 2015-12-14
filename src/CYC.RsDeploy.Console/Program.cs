using System;
using CYC.RsDeploy.Console.Commands;
using CYC.RsDeploy.Console.Verbs;
using NLog;

namespace CYC.RsDeploy.Console
{
    class Program
    {
        private static Logger logger = LogManager.GetLogger("rs");

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
                logger.Error(ex);
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
