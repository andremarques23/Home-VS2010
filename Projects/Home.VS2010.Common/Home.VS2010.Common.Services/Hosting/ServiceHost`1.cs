//-----------------------------------------------------------------------
// <copyright file="ServiceHost.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Hosting
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using Resources;

    /// <summary>
    /// Provides a host for services.
    /// </summary>
    /// <typeparam name="T">The type of hosted service.</typeparam>
    public class ServiceHost<T> : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the ServiceHost class.
        /// </summary>
        public ServiceHost()
            : base(typeof(T))
        {
        }

        /// <summary>
        /// Initializes a new instance of the ServiceHost class with the type of service and its base addresses specified.
        /// </summary>
        /// <param name="baseAddresses">An array of type System.Uri that contains the base addresses for the hosted service.</param>
        public ServiceHost(params Uri[] baseAddresses)
            : base(typeof(T), baseAddresses)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ServiceHost class with the instance of the service specified.
        /// </summary>
        /// <param name="singletonInstance">The instance of the hosted service.</param>
        public ServiceHost(T singletonInstance)
            : base(singletonInstance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ServiceHost class with the instance of the service and its base addresses specified.
        /// </summary>
        /// <param name="singletonInstance">The instance of the hosted service.</param>
        /// <param name="baseAddresses">An array of type System.Uri that contains the base addresses for the hosted service.</param>
        public ServiceHost(T singletonInstance, params Uri[] baseAddresses)
            : base(singletonInstance, baseAddresses)
        {
        }

        /// <summary>
        /// Gets a value indicating whether any endpoint from the service description implements the IMetadataExchange service contract.
        /// </summary>
        public bool HasMetadaExchangeEndpoint
        {
            get
            {
                return this.Description.Endpoints.Any(endpoint => endpoint.Contract.ContractType == typeof(IMetadataExchange));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether general unhandled execution exceptions are to be converted into and sent as a fault message.
        /// Set this to true only during development to troubleshoot a service.     
        /// </summary>
        public bool IncludeExceptionDetailInFaults
        {
            get
            {
                ServiceBehaviorAttribute serviceBehavior = this.Description.Behaviors.Find<ServiceBehaviorAttribute>();
                return serviceBehavior.IncludeExceptionDetailInFaults;
            }

            set
            {
                if (this.State == CommunicationState.Opened)
                {
                    throw new InvalidOperationException(Strings.HostAlreadyOpened);
                }

                ServiceBehaviorAttribute serviceBehavior = this.Description.Behaviors.Find<ServiceBehaviorAttribute>();
                serviceBehavior.IncludeExceptionDetailInFaults = value;
            }
        }

        /// <summary>
        /// Enables the publication of service metadata and associated information.
        /// </summary>
        /// <param name="getEnabled">Indicates whether to publish service metadata for retrieval using an GET request.</param>
        public void EnableMetadataExchange(bool getEnabled = true)
        {
            if (this.State == CommunicationState.Opened)
            {
                throw new InvalidOperationException(Strings.HostAlreadyOpened);
            }

            ServiceMetadataBehavior serviceMetadataBehavior = this.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (serviceMetadataBehavior == null)
            {
                serviceMetadataBehavior = new ServiceMetadataBehavior();

                if (this.BaseAddresses.Any(uri => uri.Scheme == "http"))
                {
                    serviceMetadataBehavior.HttpGetEnabled = getEnabled;
                }

                if (this.BaseAddresses.Any(uri => uri.Scheme == "https"))
                {
                    serviceMetadataBehavior.HttpsGetEnabled = getEnabled;
                }

                this.Description.Behaviors.Add(serviceMetadataBehavior);
            }

            this.AddMetadaExchangeEndpoints();
        }

        /// <summary>
        /// Adds a metadata exchange service endpoint for each base address used by the hosted service.
        /// </summary>
        protected void AddMetadaExchangeEndpoints()
        {
            foreach (Uri baseAddress in this.BaseAddresses)
            {
                Binding binding = null;

                switch (baseAddress.Scheme)
                {
                    case "net.tcp":
                        binding = MetadataExchangeBindings.CreateMexTcpBinding();
                        break;
                    case "net.pipe":
                        binding = MetadataExchangeBindings.CreateMexNamedPipeBinding();
                        break;
                    case "http":
                        binding = MetadataExchangeBindings.CreateMexHttpBinding();
                        break;
                    case "https":
                        binding = MetadataExchangeBindings.CreateMexHttpsBinding();
                        break;
                    default:
                        break;
                }

                if (binding != null)
                {
                    this.AddServiceEndpoint(typeof(IMetadataExchange), binding, "Mex");
                }
            }
        }
    }
}