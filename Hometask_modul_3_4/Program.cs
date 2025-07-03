namespace Hometask_modul_3_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Thread1);
            Thread thread2 = new Thread(Thread2);
            thread1.Start();
            Thread.Sleep(100);

            thread2.Start();
        }

        static void Thread1()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("=");
                Thread.Sleep(100);
            }
        }

        static void Thread2()
        {
            for (int i = 10; i >= 1; i--)
            {
                Console.Write("=");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
    }
}
