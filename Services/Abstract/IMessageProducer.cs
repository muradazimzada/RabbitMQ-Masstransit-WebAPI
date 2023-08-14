namespace RabbitMQ_Masstransit_WebAPI.Services.Abstract
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message);
    }
}
