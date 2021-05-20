using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace test_srvc
{
    class Server
    {
        TcpListener Listener; // Объект, принимающий TCP-клиентов

        // Конструктор
        public Server(int Port)
        {
            // Создаем "слушателя" для указанного порта
            Listener = new TcpListener(IPAddress.Any, Port);
            Listener.Start(); // Запускаем его

            // В бесконечном цикле
            while (true)
            {
                // Принимаем нового клиента
                TcpClient Client = Listener.AcceptTcpClient();
                // Создаем поток
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                // И запускаем этот поток, передавая ему принятого клиента
                Thread.Start(Client);
            }
        }

        // Деструктор
        ~Server()
        {
            // Если "слушатель" был создан
            if (Listener != null)
            {
                // Остановим его
                Listener.Stop();
            }
            Console.Beep();
            Console.WriteLine("Disposed");
        }

        static void ClientThread(Object StateInfo)
        {
            // Просто создаем новый экземпляр класса Client и передаем ему приведенный к классу TcpClient объект StateInfo
            new Client((TcpClient)StateInfo);
        }
    }
}
