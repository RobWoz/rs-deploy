using System;
using Rs.Commands;
using Rs.Verbs;

namespace Rs
{
    class Program
    {
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
                Console.WriteLine("Upload file");
                new UploadFileVerb(uploadFileSubOptions).Process();
            }
        }
    }
}
