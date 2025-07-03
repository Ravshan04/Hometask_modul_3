using System;
using System.IO;
using System.Threading;

class Program
{
    static readonly object writeLock = new object();
    static string[] inputFiles = { "file1.txt", "file2.txt", "file3.txt" };
    static string outputFile = "merged.txt";

    static void Main()
    {
        Console.Clear();

        // Fayllarni yaratish va to‘ldirish
        CreateFiles();

        // Yakuniy faylni tozalab qo‘yamiz
        File.WriteAllText(outputFile, "");

        // Har bir thread fayl o‘qib, `merged.txt` ga yozadi
        Thread t1 = new Thread(() => ReadAndWrite(inputFiles[0]));
        Thread t2 = new Thread(() => ReadAndWrite(inputFiles[1]));
        Thread t3 = new Thread(() => ReadAndWrite(inputFiles[2]));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("Barcha fayllar merged.txt fayliga yozildi.");
    }

    static void CreateFiles()
    {
        for (int i = 0; i < inputFiles.Length; i++)
        {
            using (StreamWriter writer = new StreamWriter(inputFiles[i]))
            {
                for (int j = 1; j <= 10; j++)
                {
                    writer.WriteLine($"[{inputFiles[i]}] Ma'lumot {j}");
                }
            }
        }
    }

    static void ReadAndWrite(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            lock (writeLock)
            {
                File.AppendAllText(outputFile, line + Environment.NewLine);
                Console.WriteLine($"{fileName} → merged.txt : {line}");
            }

            Thread.Sleep(100);
        }
    }
}
