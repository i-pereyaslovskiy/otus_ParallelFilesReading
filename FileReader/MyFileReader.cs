using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otus_ParallelFilesReading.FileReader
{
    internal class MyFileReader
    {
        private int _spaceCount;
        public int SpaceCount { get { return _spaceCount; } }

        public Task CountAllSpacesAsync(string path)
        {
            return Task.Run(() =>
            {
                string readText = File.ReadAllText(path, Encoding.Default);
                Interlocked.Add(ref _spaceCount, readText.ToCharArray().Count(i => i == ' '));
            });
        }


    }
}
