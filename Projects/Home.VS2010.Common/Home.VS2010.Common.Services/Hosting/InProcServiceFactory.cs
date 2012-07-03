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
    /// TODO: Update summary.
    /// </summary>
    public static class InProcServiceFactory
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static readonly string BaseAddress = Strings.InProcServiceBaseAddress + Guid.NewGuid();

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static readonly Binding Binding;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static Dictionary<Type, KeyValuePair<ServiceHost, EndpointAddress>> serviceHosts = new Dictionary<Type, KeyValuePair<ServiceHost, EndpointAddress>>();

        /// <summary>
        /// Initializes static members of the <see cref="InProcServiceFactory" /> class.
        /// </summary>
        static InProcServiceFactory()
        {
            Binding = new NetNamedPipeBinding { TransactionFlow = true };

            AppDomain.CurrentDomain.ProcessExit += delegate
                                                   {
                                                       foreach (KeyValuePair<ServiceHost, EndpointAddress> item in serviceHosts.Values)
                                                       {
                                                           item.Key.Close();
                                                       }
                                                   };
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <typeparam name="I">The type of the service contract.</typeparam>
        /// <typeparam name="S">The type of the implemented service contract.</typeparam>
        /// <returns>The channel of type <see cref="I" /> created by the factory.</returns>
        public static I CreateChannel<I, S>()
            where I : class
            where S : class, I
        {
            KeyValuePair<ServiceHost, EndpointAddress> hostAddressPair = GetHostAddressPair<I, S>();

            return ChannelFactory<I>.CreateChannel(Binding, hostAddressPair.Value);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <typeparam name="I">>The type of the service contract.</typeparam>
        /// <param name="channel">The channel of type <see cref="I" /> to be closed by the factory.</param>
        public static void CloseChannel<I>(I channel)
            where I : class
        {
            (channel as ICommunicationObject).Close();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <typeparam name="I">The type of the service contract.</typeparam>
        /// <typeparam name="S">The type of the implemented service contract.</typeparam>
        /// <returns>A service host/ endpoint address pair.</returns>
        private static KeyValuePair<ServiceHost, EndpointAddress> GetHostAddressPair<I, S>()
            where I : class
            where S : class, I
        {
            KeyValuePair<ServiceHost, EndpointAddress> hostAddressPair;
            Type serviceType = typeof(S);

            if (serviceHosts.ContainsKey(serviceType))
            {
                hostAddressPair = serviceHosts[serviceType];
            }
            else
            {
                ServiceHost<S> serviceHost = new ServiceHost<S>(new Uri(BaseAddress));
                EndpointAddress endpointAddress = new EndpointAddress(BaseAddress + serviceType.Name);

                hostAddressPair = new KeyValuePair<ServiceHost, EndpointAddress>(serviceHost, endpointAddress);
                serviceHosts.Add(serviceType, hostAddressPair);

                serviceHost.AddServiceEndpoint(typeof(I), Binding, endpointAddress.Uri);
                serviceHost.Open();
            }

            return hostAddressPair;
        }
    }
}
