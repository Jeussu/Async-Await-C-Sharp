namespace Async_Await
{
    internal class Program
    {
        static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ...Start");
                Console.ResetColor();
            }


            for (int i = 1; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} {i,2}");
                    Console.ResetColor();
                }


                Thread.Sleep(1000);
            }

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ...End");
                Console.ResetColor();
            }

        }
        // asynchronous(multi thread)
        static async Task Task2()
        {
            Task t2 = new Task(
            () =>
        {

            DoSomeThing(10, "T2", ConsoleColor.Green);
        });
            t2.Start();
            await t2;
            //t2.Wait();
            Console.WriteLine("T2 finished");
        }

        static async Task Task3()
        {
            Task t3 = new Task(
                (object ob) =>
                {
                    string tentacvu = (string)ob;
                    DoSomeThing(4, tentacvu, ConsoleColor.Yellow);
                }
                , "T3");
            t3.Start();
            await t3;
            Console.WriteLine("T3 finished");
        }

        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(
        () =>
        {
            DoSomeThing(10, "T4", ConsoleColor.Green);
            return "Return from t4";
        }
        ); // () => {return string;}
            t4.Start();
            var kq = await t4;
            Console.WriteLine("t4 finished");
            return kq;
        }

        static async Task<string> Task5()
        {
            Task<string> t5 = new Task<string>(
                    (object ob) =>
                    {
                        string t = (string)ob;
                        DoSomeThing(4, t, ConsoleColor.Yellow);
                        return $"Return from {t}";
                    }
                    , "T5"); // () => {return string;}

            t5.Start();
            string kq = await t5;
            return kq;
        }

        static async Task<string> GetWeb(string url)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Start to download");
            HttpResponseMessage kq = await httpClient.GetAsync(url);
            Console.WriteLine("Start to reading content");
            string content = await kq.Content.ReadAsStringAsync();
            Console.WriteLine("Finished");
            return content;
        }

        // async/await
        static async Task Main(string[] args)
        {
            // asynchronous 
            // Task<T>
            //Task<string> t4 = Task4();
            //Task<string> t5 = Task5();

            var task = GetWeb("Https://facebook.com");
            DoSomeThing(6, "T1", ConsoleColor.Magenta); // other Thread

            var content = await task;
            //var kq4 = await t4;
            //var kq5 = await t5;

            //Console.WriteLine(kq4);
            //Console.WriteLine(kq5);

            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}