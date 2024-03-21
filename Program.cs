using otus_ParallelFilesReading.FileReader;
using System.Diagnostics;

MyFileReader reader = new MyFileReader();
Stopwatch stopwatch = new Stopwatch();

var files = Directory.GetFiles("../../../FileStorage");

stopwatch.Start();

List<Task> tasks = new List<Task>();
foreach (var filePath in files)
  tasks.Add(Task.Run( async ()=> await reader.CountAllSpacesAsync(filePath)));

await Task.WhenAll(tasks);

stopwatch.Stop();

Console.WriteLine($"Whitespaces count:{reader.SpaceCount}, Duration: {stopwatch.ElapsedMilliseconds} ms.");

Console.ReadKey();