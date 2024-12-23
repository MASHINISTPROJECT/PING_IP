// импор бибилиотек
using System;
using System.Net.NetworkInformation;
using Serilog;
using Serilog.Core;
using System.Threading;
using System.ComponentModel.Design;
using Serilog.Sinks;

// создание класса
class DOS_TEST
{
    static void Main(string[] args)
    {
        // Конфиг логов
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();
        Log.Debug("Ищем ответ от центрального сервера . . .");
        Log.Information("Введите ip адрес для Пинга");
        string IpAddress = Console.ReadLine();

        Log.Information("Инциализация компонентов . . .");
        Ping pingSender = new Ping();
        PingOptions options = new PingOptions();
        options.DontFragment = true;

        string data = "ааааааааааааааааааааааааааааааааааааа"; // 32 байта
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
        int timeout = 120;

        try
        {
            Log.Information("Отправка пинг запроса . . .");
            PingReply reply = pingSender.Send(IpAddress, timeout, buffer, options);

            if (reply.Status == IPStatus.Success)
            {
                // получаем ответ
                Log.Information($"Ответ от {reply.Address}: время = {reply.RoundtripTime}мс");
                Thread.Sleep(36000); // ожидание 10 минут перед закрытием
            }

        }
        catch (Exception e)
        {
        }
    }
}