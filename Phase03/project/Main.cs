using Newtonsoft.Json;
using project;
using System.Net;

namespace Project
{
    class App
    {
        public static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            Output output = new Output();
            new RunProgram().Run(fileReader, output);
        }
    }
}