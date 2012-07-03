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
        private static Dictionary<Type, Tuple<ServiceHost, EndpointAddress>> serviceHosts = new Dictionary<Type, Tuple<ServiceHost, EndpointAddress>>();

        /// <summary>
        /// Initializes static members of the <see cref="InProcServiceFactory" /> class.
        /// </summary>
        static InProcServiceFactory()
        {
            Binding = new NetNamedPipeBinding { TransactionFlow = true };

            AppDomain.CurrentDomain.ProcessExit += delegate
                                                   {
                                                       foreach (Tuple<ServiceHost, EndpointAddress> item in serviceHosts.Values)
                                                       {
                                                           item.Item1.Close();
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
            EndpointAddress endpointAddress = GetAddress<I, S>();

            return ChannelFactory<I>.CreateChannel(Binding, endpointAddress);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <typeparam name="I">>The type of the service contract.</typeparam>
        /// <param name="channel">The channel of type <see cref="I" /> to be closed by the factory.</param>
        public static void CloseChannel<I>(I channel)
            where I : class
        {
            ICommunicationObject channelProxy = channel as ICommunicationObject;
            channelProxy.Close();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <typeparam name="I">The type of the service contract.</typeparam>
        /// <typeparam name="S">The type of the implemented service contract.</typeparam>
        /// <returns>The endpoint address for the given implemented service and contract types.</returns>
        private static EndpointAddress GetAddress<I, S>()
            where I : class
            where S : class, I
        {
            return new EndpointAddress(string.Empty);
        }
    }
}
