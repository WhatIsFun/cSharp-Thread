using System.ComponentModel;

namespace cSharp_Threads
{
    internal class Program
    {
        static int someValue = 10;
        static bool isLocked = false;  
        static async Task Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(doSomeWork));
            thread.IsBackground = true; // To use BackGround thread
            thread.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread: {0}", i);
                Thread.Sleep(10);
            }
            thread.Join(); // Join use here to not stop the doSomeWork thread from debugging.
            Console.WriteLine("Main Block");

            //Thread thread1 = new Thread(incrementVariable);
            //Thread thread2 = new Thread(incrementVariable);
            //thread1.Start();
            //thread2.Start();
            //thread1.Join();
            //thread2.Join();
            //Console.WriteLine(someValue);

            int result = await add(2,3);
            Console.WriteLine(result);
            Console.WriteLine("Hello");
        }

        public static void doSomeWork()
        {
            for(int i = 0;i < 10; i++)
            {
                Console.WriteLine("Worker: {0}", i);
                Thread.Sleep(100);
            }
        }
        public static void incrementVariable()
        {
            if (!isLocked)
            {
                isLocked = true;
                for (int i = 0; i <= 100; i++)
                {
                    someValue++;
                }
                isLocked = false;
            }
        }
        public static async Task<int> add(int a,int b)
        {
            // await Task.Delay(5000);
            return a + b;
        }
    }
}