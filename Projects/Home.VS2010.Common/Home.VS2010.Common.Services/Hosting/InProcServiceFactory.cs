// -----------------------------------------------------------------------
// <copyright file="InProcServiceFactory.cs" company="Home">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using Resources;

    /// <summary>
    /// A factory that creates channels of different types that are used by clients designed to streamline and automate in-proc hosting.
    /// </summary>
    public static class InProcServiceFactory
    {
        /// <summary>
        /// Base address used by the hosted services.
        /// </summary>
        private static readonly string BaseAddress = Strings.InProcServiceBaseAddress + Guid.NewGuid();

        /// <summary>
        /// Binding element that specify the protocols, transports, and message encoders used by the hosted services.
        /// </summary>
        private static readonly Binding Binding;

        /// <summary>
        /// A collection of types and service host/endpoint address pair values.
        /// </summary>
        private static Dictionary<Type, HostEndpointPair> serviceHosts = new Dictionary<Type, HostEndpointPair>();

        /// <summary>
        /// Initializes static members of the InProcServiceFactory class.
        /// </summary>
        static InProcServiceFactory()
        {
            Binding = new NetNamedPipeBinding { TransactionFlow = true };

            AppDomain.CurrentDomain.ProcessExit += delegate
                                                   {
                                                       foreach (HostEndpointPair hostEndpointPair in serviceHosts.Values)
                                                       {
                                                           hostEndpointPair.ServiceHost.Close();
                                                       }
                                                   };
        }

        /// <summary>
        /// Creates a channel of a specified service contract type.
        /// </summary>
        /// <typeparam name="I">The type of the service contract.</typeparam>
        /// <typeparam name="S">The type of the implemented service contract.</typeparam>
        /// <returns>The channel created by the factory.</returns>
        public static I CreateChannel<I, S>()
            where I : class
            where S : class, I
        {
            HostEndpointPair hostAddressPair = GetHostEndpointPair<I, S>();

            return ChannelFactory<I>.CreateChannel(Binding, hostAddressPair.EndpointAddress);
        }

        /// <summary>
        /// Closes a channel of a specified service contract type.
        /// </summary>
        /// <typeparam name="I">>The type of the service contract.</typeparam>
        /// <param name="channel">The channel to be closed by the factory.</param>
        public static void CloseChannel<I>(I channel)
            where I : class
        {
            (channel as ICommunicationObject).Close();
        }

        /// <summary>
        /// Gets a service host / endpoint address pair of a specified service contract type.
        /// </summary>
        /// <typeparam name="I">The type of the service contract.</typeparam>
        /// <typeparam name="S">The type of the implemented service contract.</typeparam>
        /// <returns>A service host/endpoint address pair.</returns>
        private static HostEndpointPair GetHostEndpointPair<I, S>()
            where I : class
            where S : class, I
        {
            HostEndpointPair hostAddressPair;
            Type serviceType = typeof(S);

            if (serviceHosts.ContainsKey(serviceType))
            {
                hostAddressPair = serviceHosts[serviceType];
            }
            else
            {
                ServiceHost<S> serviceHost = new ServiceHost<S>(new Uri(BaseAddress));
                EndpointAddress endpointAddress = new EndpointAddress(BaseAddress + Guid.NewGuid());

                hostAddressPair = new HostEndpointPair(serviceHost, endpointAddress);
                serviceHosts.Add(serviceType, hostAddressPair);

                serviceHost.AddServiceEndpoint(typeof(I), Binding, endpointAddress.Uri);
                serviceHost.Open();
            }

            return hostAddressPair;
        }

        /// <summary>
        /// Defines a ServiceHost/EndpointAddress pair.
        /// </summary>
        private struct HostEndpointPair
        {
            /// <summary>
            /// The service host associated with the endpoint address.
            /// </summary>
            public readonly ServiceHost ServiceHost;

            /// <summary>
            /// The endpoint address associated with the service host.
            /// </summary>
            public readonly EndpointAddress EndpointAddress;

            /// <summary>
            /// Initializes a new instance of the HostEndpointPair struct.
            /// </summary>
            /// <param name="serviceHost">The service host associated with the endpoint address.</param>
            /// <param name="endpointAddress">The endpoint address associated with the service host.</param>
            public HostEndpointPair(ServiceHost serviceHost, EndpointAddress endpointAddress)
            {
                this.ServiceHost = serviceHost;
                this.EndpointAddress = endpointAddress;
            }
        }
    }
}
