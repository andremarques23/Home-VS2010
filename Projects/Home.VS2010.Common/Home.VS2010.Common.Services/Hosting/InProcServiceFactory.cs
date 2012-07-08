//-----------------------------------------------------------------------
// <copyright file="InProcServiceFactory.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using Duplex;
    using Extensions;
    using Resources;

    /// <summary>
    /// A factory that creates channels of different types that are used by clients designed to streamline and automate in-process hosting.
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
        /// A collection of types and throttling configurations values.
        /// </summary>
        private static Dictionary<Type, ServiceThrottlingBehavior> serviceThrottlingBehaviors = new Dictionary<Type, ServiceThrottlingBehavior>();

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
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static I CreateChannel<I, S>()
            where I : class
            where S : class, I
        {
            HostEndpointPair hostAddressPair = GetHostEndpointPair<I, S>();

            return ChannelFactory<I>.CreateChannel(Binding, hostAddressPair.EndpointAddress);
        }

        /// <summary>
        /// Creates a channel of a specified service contract type.
        /// </summary>
        /// <typeparam name="I">The type of the service contract.</typeparam>
        /// <typeparam name="S">The type of the implemented service contract.</typeparam>
        /// <typeparam name="C">The callback that implements the service instance.</typeparam>
        /// <param name="callbackObject">The callback object that implements the service instance.</param>
        /// <returns>The channel created by the factory.</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static I CreateChannel<I, S, C>(C callbackObject)
            where I : class
            where S : class, I
        {
            InstanceContext<C> instanceContext = new InstanceContext<C>(callbackObject);

            return CreateChannel<I, S, C>(instanceContext);
        }

        /// <summary>
        /// Creates a channel of a specified service contract type.
        /// </summary>
        /// <typeparam name="I">The type of the service contract.</typeparam>
        /// <typeparam name="S">The type of the implemented service contract.</typeparam>
        /// <typeparam name="C">The callback that implements the service instance.</typeparam>
        /// <param name="instanceContext">The context information for the service instance.</param>
        /// <returns>The channel created by the factory.</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static I CreateChannel<I, S, C>(InstanceContext<C> instanceContext)
            where I : class
            where S : class, I
        {
            HostEndpointPair hostAddressPair = GetHostEndpointPair<I, S>();

            return DuplexChannelFactory<I, C>.CreateChannel(instanceContext, Binding, hostAddressPair.EndpointAddress);
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
        /// Closes a channel of a specified service contract type.
        /// </summary>
        /// <typeparam name="I">>The type of the service contract.</typeparam>
        /// <param name="channel">The channel to be closed by the factory.</param>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        public static void CloseChannel<I>(I channel, TimeSpan timeout)
            where I : class
        {
            (channel as ICommunicationObject).Close(timeout);
        }

        /// <summary>
        /// Sets run-time throughput settings to the largest possible values of an System.Int32.
        /// This method should only be called before a service instance is created.
        /// </summary>
        /// <typeparam name="S">The service type.</typeparam>
        public static void MaxOutThrottle<S>()
        {
            SetThrottle<S>(int.MaxValue, int.MaxValue, int.MaxValue);
        }

        /// <summary>
        /// Sets run-time throughput settings for service performance tunning. 
        /// This method should only be called before a service instance is created.
        /// </summary>
        /// <typeparam name="S">The service type.</typeparam>
        /// <param name="serviceThrottlingBehavior">System.ServiceModel.Description.ServiceThrottlingBehavior containing the settings.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void SetThrottle<S>(ServiceThrottlingBehavior serviceThrottlingBehavior)
        {
            serviceThrottlingBehaviors[typeof(S)] = serviceThrottlingBehavior;
        }

        /// <summary>
        /// Sets run-time throughput settings for service performance tunning.
        /// This method should only be called before a service instance is created.
        /// </summary>
        /// <typeparam name="S">The service type.</typeparam>
        /// <param name="maxConcurrentCalls">The maximum number of messages actively processing across a System.ServiceModel.ServiceHost.</param>
        /// <param name="maxConcurrentInstances">The maximum number of System.ServiceModel.InstanceContext objects in the service that can execute at one time.</param>
        /// <param name="maxConcurrentSessions">The maximum number of sessions a System.ServiceModel.ServiceHost object can accept at one time.</param>
        public static void SetThrottle<S>(int maxConcurrentCalls, int maxConcurrentInstances, int maxConcurrentSessions)
        {
            ServiceThrottlingBehavior serviceThrottlingBehavior = new ServiceThrottlingBehavior
                                                                  {
                                                                      MaxConcurrentCalls = maxConcurrentCalls,
                                                                      MaxConcurrentInstances = maxConcurrentCalls,
                                                                      MaxConcurrentSessions = maxConcurrentSessions
                                                                  };

            SetThrottle<S>(serviceThrottlingBehavior);
        }

        /// <summary>
        /// Gets a service host/endpoint address pair of a specified service contract type. If the collection of types
        /// and pairs does not already contain the service type, a service host instance is created for the type.
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
                if (serviceThrottlingBehaviors.ContainsKey(serviceType))
                {
                    serviceHost.SetThrottle(serviceThrottlingBehaviors[serviceType]);
                }

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
