﻿using GamersCommunity.Core.Rabbit;
using Microsoft.Extensions.Options;
using Serilog;

namespace Sample.Consumer
{
    /// <summary>
    /// Concrete RabbitMQ consumer for the sample microservice.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Inherits from <see cref="BasicServiceConsumer"/> and specifies the queue to consume from.
    /// </para>
    /// <para>
    /// This consumer will listen on the queue <c>"sample_queue"</c> and use the provided
    /// <see cref="TableRouter"/> to dispatch incoming messages to the appropriate table service.
    /// </para>
    /// </remarks>
    /// <remarks>
    /// Initializes a new instance of the <see cref="SampleServiceConsumer"/> class.
    /// </remarks>
    /// <param name="otps">RabbitMQ settings injected from configuration.</param>
    /// <param name="tableRouter">Router responsible for message dispatch.</param>
    /// <param name="logger">Application logger (Serilog).</param>
    public class SampleServiceConsumer(IOptions<RabbitMQSettings> otps, TableRouter tableRouter, ILogger logger) : BasicServiceConsumer(otps, tableRouter, logger)
    {
        /// <summary>
        /// Gets or sets the queue name this consumer will listen on.
        /// Default value is <c>"sample_queue"</c>.
        /// </summary>
        public override string QUEUE { get; set; } = "sample_queue";
    }
}
