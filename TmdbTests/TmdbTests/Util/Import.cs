using System.Collections;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using TmdbData;

namespace TmdbTests.Util
{
    public class Import
    {
        public static Movie Movie;
        public AlternativeTitles AlternativeTitles;

        public static Movie GetMovie(string fileName)
        {
            Movie = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(fileName));
            return Movie;
        }

        public static IEnumerable MovieDataTestCases
        {
            get
            {
                var cultureCodePaths =
                    Directory.GetDirectories(Directory.GetCurrentDirectory() + "/ExternalData/Movies/");

                foreach (string dir in cultureCodePaths)
                {
                    var fileList = Directory.GetFiles(dir);
                    foreach (string file in fileList)
                    {
                        string[] cultureCodes = file.Split('\\');
                        string cultureCode = cultureCodes[cultureCodes.Length - 2];
                        var cultureCodes1 = cultureCode.Split('/');
                        var cultureCode1 = cultureCodes1[cultureCodes1.Length - 1];
                        yield return new TestCaseData(GetMovie(file), cultureCode1).SetName(
                            "Should Get Correct Movie Data For : " + Movie.title + " - " + cultureCode1);
                    }
                }
            }
        }
    }
}