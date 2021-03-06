using System;
using System.Collections.Generic;
using EasyNetQ;
using EasyNetQ.DI;
using JetBrains.Annotations;
using NSubstitute;
using RabbitMQ.Client;

namespace Orange.TestTask.RestQueueService.UnitTests
{
    [UsedImplicitly]
    public class MockBuilder : IDisposable
    {
        private readonly IBasicProperties _basicProperties = new BasicProperties();
        private readonly IBus _bus;
        private readonly Stack<IModel> _channelPool = new Stack<IModel>();
        private readonly List<IModel> _channels = new List<IModel>();
        private readonly IConnection _connection = Substitute.For<IAutorecoveringConnection>();
        private readonly IConnectionFactory _connectionFactory = Substitute.For<IConnectionFactory>();
        private readonly List<string> _consumerQueueNames = new List<string>();
        private readonly List<AsyncDefaultBasicConsumer> _consumers = new List<AsyncDefaultBasicConsumer>();

        public MockBuilder() : this(register => { })
        {
        }

        public MockBuilder(Action<IServiceRegister> registerServices) : this("host=localhost", registerServices)
        {
        }

        public MockBuilder(string connectionString) : this(connectionString, register => { })
        {
        }

        public MockBuilder(string connectionString, Action<IServiceRegister> registerServices)
        {
            for (var i = 0; i < 10; i++)
                _channelPool.Push(Substitute.For<IModel, IRecoverable>());

            _connectionFactory.CreateConnection(Arg.Any<IList<AmqpTcpEndpoint>>()).Returns(_connection);
            _connection.IsOpen.Returns(true);
            _connection.Endpoint.Returns(new AmqpTcpEndpoint("localhost"));

            _connection.CreateModel().Returns(i =>
            {
                var channel = _channelPool.Pop();
                _channels.Add(channel);
                channel.CreateBasicProperties().Returns(_basicProperties);
                channel.IsOpen.Returns(true);
                channel.BasicConsume(null, false, null, true, false, null, null)
                    .ReturnsForAnyArgs(consumeInvocation =>
                    {
                        var queueName = (string)consumeInvocation[0];
                        var consumerTag = (string)consumeInvocation[2];
                        var consumer = (AsyncDefaultBasicConsumer)consumeInvocation[6];

                        ConsumerQueueNames.Add(queueName);
                        consumer.HandleBasicConsumeOk(consumerTag);
                        _consumers.Add(consumer);
                        return string.Empty;
                    });
                channel.QueueDeclare(null, true, false, false, null)
                    .ReturnsForAnyArgs(queueDeclareInvocation =>
                    {
                        var queueName = (string)queueDeclareInvocation[0];
                        return new QueueDeclareOk(queueName, 0, 0);
                    });

                return channel;
            });

            _bus = RabbitHutch.CreateBus(connectionString, x =>
            {
                registerServices(x);
                x.Register(_connectionFactory);
            });
        }

        public IPubSub PubSub => _bus.PubSub;

        public IRpc Rpc => _bus.Rpc;

        public ISendReceive SendReceive => _bus.SendReceive;

        public IScheduler Scheduler => _bus.Scheduler;

        public IConnectionFactory ConnectionFactory => _connectionFactory;

        public IConnection Connection => _connection;

        public List<IModel> Channels => _channels;

        public List<AsyncDefaultBasicConsumer> Consumers => _consumers;

        public IBus Bus => _bus;

        public IServiceResolver ServiceProvider => _bus.Advanced.Container;

        public IModel NextModel => _channelPool.Peek();

        public IEventBus EventBus => ServiceProvider.Resolve<IEventBus>();

        public IPersistentConnection PersistentConnection => ServiceProvider.Resolve<IPersistentConnection>();

        public List<string> ConsumerQueueNames => _consumerQueueNames;

        public void Dispose() => _bus.Dispose();
    }
}
