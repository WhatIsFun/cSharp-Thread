namespace cSharp_Threads
{
    internal class Program
    {
        static void Main(string[] args)
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
        }

        public static void doSomeWork()
        {
            for(int i = 0;i < 10; i++)
            {
                Console.WriteLine("Worker: {0}", i);
                Thread.Sleep(100);
            }
        }
    }
}