using System.Net;
using System.Net.Sockets;
using System.Text;

TcpListener server = null;

int port = 160;
try
{
    IPAddress localAddr = IPAddress.Parse("5.63.157.232");
    server = new TcpListener(localAddr, port);

    // запуск слушателя
    server.Start();

    while (true)
    {
        Console.WriteLine("Ожидание подключений... ");

        // получаем входящее подключение
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Подключен клиент. Выполнение запроса...");

        // получаем сетевой поток для чтения и записи
        NetworkStream stream = client.GetStream();

        // сообщение для отправки клиенту
        string response = "Привет мир";
        // преобразуем сообщение в массив байтов
        byte[] data = Encoding.UTF8.GetBytes(response);

        // отправка сообщения
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Отправлено сообщение: {0}", response);
        // закрываем поток
        stream.Close();
        // закрываем подключение
        client.Close();
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    if (server != null)
        server.Stop();
}