using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace test_srvc
{
    class Run
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Создадим новый сервер на порту 80
            new Server(120);
        }
    }
}
