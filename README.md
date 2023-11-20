# Async Await

async-await
-	Lập trình bất đồng bộ asynchronous là kĩ thuật lập trình tạo ra ứng dụng có khả năng chạy đa luồng(multi thread)
-	Khoá truy cập tới đối tượng và từ khoá lock:
Code: namespace Async_Await
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
        static void Main(string[] args)
        {
            DoSomeThing(5, "Abc", ConsoleColor.Red);
            Console.WriteLine("Hello, World!");
        }
    }
}
-	Lập trình đồng bộ asynchronous là lập trình chạy đơn luồng. Với lập trình đồng bộ asynchronous khi ứng dụng có nhiều tác vụ thì các tác vụ được viết code theo thứ tự và khi thi hành code thì các tác vụ sẽ chạy lần lượt theo thứ tự(tác vụ trước phải hoàn thành thì tác vụ sau mới được thực hiện )
Code: namespace Async_Await
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
        static void Main(string[] args)
        {
            // asynchronous 

            DoSomeThing(6, "T1", ConsoleColor.Magenta);

            DoSomeThing(10, "T2", ConsoleColor.Green);

            DoSomeThing(4, "T3", ConsoleColor.Yellow);

            Console.WriteLine("Hello, World!");

        }
    }
}
-	Tạo tác vụ với Task: một đối tượng lớp Task có biểu diễn tác vụ, có thể khai báo tác vụ Task, để khởi tạo tác vụ Task dùng toán tử new và có thể truyền tham số khởi tạo như Action(tương ứng với Delegate không có tham số và không cần trả về giá trị)
-	Async/await sử dụng như sau: khi khai báo một phương thức trở thành phương thức bất đồng bộ thì khai báo sử dụng từ khoá async và từ khoá await bên trong phương thức theo sau là tên tác vụ 
Đọc Cái link bên dưới:
https://viblo.asia/p/lap-trinh-bat-dong-bo-trong-c-DZrGNDoWkVB
