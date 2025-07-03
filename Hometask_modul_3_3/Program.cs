namespace Hometask_modul_3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Print1);
            Thread thread2 = new Thread(Print2);
            Thread thread3 = new Thread(Print3);

            thread2.Start();
            thread1.Start();
            thread3.Start();
        }
        static void Print1()
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine('*');
                Thread.Sleep(100);
            }
        }

        static void Print2()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine('#');
                Thread.Sleep(200);
            }
        }

        static void Print3()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine('@');
                Thread.Sleep(50);
            }
        }
    }
}
