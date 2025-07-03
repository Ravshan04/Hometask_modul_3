namespace Hometask_modul_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Hello);
            thread1.Start();
            Thread thread2 = new Thread(World);
            thread2.Start();
        }

        static void Hello() 
        { 
            for(int i = 1; i<=5; i++)
            {
                Console.WriteLine("Hello");
                Thread.Sleep(500);
            }    
        }
        static void World()
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("World");
            }
        }
    }
}
