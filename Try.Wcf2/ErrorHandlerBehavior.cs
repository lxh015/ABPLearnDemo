using Castle.Core.Logging;
using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Triage.Server
{
    /// <summary>
    /// Being a custom EndpointBehavior added to the WCF services to provide custom error handling functionality.
    /// Namely, logging error so it doesn't get ignored.
    /// </summary>
    public class ErrorHandlerBehavior : IEndpointBehavior, IErrorHandler
    {
        /// <summary>
        /// Backing store for <paramref name="Logger"/>.
        /// </summary>
        /// <remarks>Defaults to a NullLogger, so that this component can safely be used even if logging has not been configured.</remarks>
        private ILogger logger = Castle.Core.Logging.NullLogger.Instance;

        /// <summary>
        /// Gets or sets a component for providing logging functionality.
        /// </summary>
        public ILogger Logger
        {
            get { return this.logger; }
            set { this.logger = value; }
        }

        /// <summary>
        /// Handles an exception.
        /// </summary>
        /// <param name="error">Exception to be handled</param>
        /// <returns>Indication of whether it is safe for WCF to continue using state associated with the failed request.</returns>
        public bool HandleError(Exception error)
        {
            // Just log the error, umkay?
            this.Logger.Error("Unhandled exception occurred", error);
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // Add ourself to the collection of error handlers.
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(this);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}