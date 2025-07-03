using System;
using System.Threading;

class Program
{
    static readonly object consoleLock = new object();

    static AutoResetEvent thread1Turn = new AutoResetEvent(true);
    static AutoResetEvent thread2Turn = new AutoResetEvent(false);
    static AutoResetEvent thread3Turn = new AutoResetEvent(false);

    static int maxSteps = 20;
    static int[] steps = { 0, 0, 0 };

    static void Main()
    {
        Console.Clear();

        // Har bir threadga progress chizig‘i boshlab beriladi
        lock (consoleLock)
        {
            Console.SetCursorPosition(0, 0); Console.Write("Thread-1: ");
            Console.SetCursorPosition(0, 1); Console.Write("Thread-2: ");
            Console.SetCursorPosition(0, 2); Console.Write("Thread-3: ");
        }

        // Threadlarni ishga tushuramiz
        Thread t1 = new Thread(() => DoProgress(0, thread1Turn, thread2Turn, ConsoleColor.Cyan));
        Thread t2 = new Thread(() => DoProgress(1, thread2Turn, thread3Turn, ConsoleColor.Yellow));
        Thread t3 = new Thread(() => DoProgress(2, thread3Turn, thread1Turn, ConsoleColor.Green));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        // Yakuniy xabar
        lock (consoleLock)
        {
            Console.SetCursorPosition(0, 4);
            Console.ResetColor();
            Console.WriteLine("✅ Barcha threadlar progressni tugatdi.");
        }
    }

    static void DoProgress(int line, AutoResetEvent myTurn, AutoResetEvent nextTurn, ConsoleColor color)
    {
        while (steps[line] < maxSteps)
        {
            myTurn.WaitOne(); // navbat kelgunga qadar kutadi

            steps[line]++;

            lock (consoleLock)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(10, line); // 10-x dan progress boshlab yoziladi
                Console.Write(new string('=', steps[line]) + ">");
                Console.ResetColor();
            }

            Thread.Sleep(500); // progress sekinlashsin
            nextTurn.Set();    // navbat keyingi threadga beriladi
        }
    }
}
