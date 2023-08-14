using RabbitMQ.Client;
using RabbitMQ_Masstransit_WebAPI.Services.Abstract;
using System.Text;
using System.Text.Json;

namespace RabbitMQ_Masstransit_WebAPI.Services.Concrete
{
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
               
            };

            var con = factory.CreateConnection();

            using var channel = con.CreateModel();


            channel.QueueDeclare("booking", durable: false, exclusive:false, false);

           
            var jsonString = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "booking", body: body);

        }
    }
}
