namespace Hometask_modul_3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(CountFrom1To10);
            Thread thread2 = new Thread(CountFrom10To1);
            thread1.Start();
            thread1.Join();
            thread2.Start();

        }

        static void CountFrom1To10()
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }

        static void CountFrom10To1()
        {
            for (int i = 10; i >= 1; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine(i);
            }
        }
    }
}
