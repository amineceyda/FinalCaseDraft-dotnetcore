using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using SiteManangmentAPI.Web.Configurations;
using System;
using System.Text;

namespace SiteManangmentAPI.Web.Services
{
    public class RabbitMQService
    {
        private readonly IOptions<RabbitMQConfiguration> _config;

        public RabbitMQService(IOptions<RabbitMQConfiguration> config)
        {
            _config = config;
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _config.Value.Hostname,
                UserName = _config.Value.Username,
                Password = _config.Value.Password
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _config.Value.QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: _config.Value.QueueName,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"[x] Sent '{message}'");
            }
        }
    }
}
