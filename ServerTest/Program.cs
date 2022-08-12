using System.Net;
using System.Net.Sockets;

var code = "code123";
var ip = IPAddress.Parse("5.63.157.232");
var port = 160;

var server = new TcpListener(ip, port);

while (true)
{
    Console.WriteLine("Wait..");

    server.Start();

    var client = server.AcceptTcpClient();
    var stream = client.GetStream();

    var reader = new StreamReader(stream);
    var msg = reader.ReadLine();

    if (!msg.Contains(code))
    {
        Console.WriteLine("error");
        return;
    }

    Console.WriteLine(msg);
}