//-----------------------------------------------------------------------
// <copyright file="DuplexChannelFactory.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Duplex
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;

    /// <summary>
    /// Provides the means to create and manage duplex channels of different types that are used by clients to send and receive messages to and from service endpoints.
    /// </summary>
    /// <typeparam name="T">The type of channel produced by the channel factory.</typeparam>
    /// <typeparam name="C">The callback object that implements the service instance.</typeparam>
    public class DuplexChannelFactory<T, C> : DuplexChannelFactory<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service</param>
        public DuplexChannelFactory(InstanceContext<C> instanceContext)
            : base(instanceContext.Context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service</param>
        /// <param name="serviceEndpoint">The System.ServiceModel.Description.ServiceEndpoint to which channels produced by the factory connect.</param>
        public DuplexChannelFactory(InstanceContext<C> instanceContext, ServiceEndpoint serviceEndpoint)
            : base(instanceContext.Context, serviceEndpoint)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        public DuplexChannelFactory(InstanceContext<C> instanceContext, string endpointConfigurationName)
            : base(instanceContext.Context, endpointConfigurationName)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        /// <param name="endpointRemoteAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        public DuplexChannelFactory(InstanceContext<C> instanceContext, string endpointConfigurationName, EndpointAddress endpointRemoteAddress)
            : base(instanceContext.Context, endpointConfigurationName, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        public DuplexChannelFactory(InstanceContext<C> instanceContext, Binding binding)
            : base(instanceContext.Context, binding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="endpointRemoteAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        public DuplexChannelFactory(InstanceContext<C> instanceContext, Binding binding, EndpointAddress endpointRemoteAddress)
            : base(instanceContext.Context, binding, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="remoteAddress">The remote address that provides the location of the service.</param>
        public DuplexChannelFactory(InstanceContext<C> instanceContext, Binding binding, string remoteAddress)
            : base(instanceContext.Context, binding, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        public DuplexChannelFactory(C callbackObject)
            : base(callbackObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="serviceEndpoint">The System.ServiceModel.Description.ServiceEndpoint to which channels produced by the factory connect.</param>
        public DuplexChannelFactory(C callbackObject, ServiceEndpoint serviceEndpoint)
            : base(callbackObject, serviceEndpoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        public DuplexChannelFactory(C callbackObject, string endpointConfigurationName)
            : base(callbackObject, endpointConfigurationName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        /// <param name="endpointRemoteAddress">>The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        public DuplexChannelFactory(C callbackObject, string endpointConfigurationName, EndpointAddress endpointRemoteAddress)
            : base(callbackObject, endpointConfigurationName, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        public DuplexChannelFactory(C callbackObject, Binding binding)
            : base(callbackObject, binding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="endpointRemoteAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        public DuplexChannelFactory(C callbackObject, Binding binding, EndpointAddress endpointRemoteAddress)
            : base(callbackObject, binding, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="remoteAddress">The remote address that provides the location of the service.</param>
        public DuplexChannelFactory(C callbackObject, Binding binding, string remoteAddress)
            : base(callbackObject, binding, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackInstanceType">The System.Type that provides the callback instance that the client uses to listen for messages from the connected service.</param>
        public DuplexChannelFactory(Type callbackInstanceType)
            : base(callbackInstanceType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackInstanceType">The System.Type that provides the callback instance that the client uses to listen for messages from the connected service.</param>
        /// <param name="serviceEndpoint">The System.ServiceModel.Description.ServiceEndpoint to which channels produced by the factory connect.</param>
        public DuplexChannelFactory(Type callbackInstanceType, ServiceEndpoint serviceEndpoint)
            : base(callbackInstanceType, serviceEndpoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackInstanceType">The System.Type that provides the callback instance that the client uses to listen for messages from the connected service.</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        public DuplexChannelFactory(Type callbackInstanceType, string endpointConfigurationName)
            : base(callbackInstanceType, endpointConfigurationName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackInstanceType">The System.Type that provides the callback instance that the client uses to listen for messages from the connected service.</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        /// <param name="endpointRemoteAddress">>The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        public DuplexChannelFactory(Type callbackInstanceType, string endpointConfigurationName, EndpointAddress endpointRemoteAddress)
            : base(callbackInstanceType, endpointConfigurationName, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackInstanceType">The System.Type that provides the callback instance that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        public DuplexChannelFactory(Type callbackInstanceType, Binding binding)
            : base(callbackInstanceType, binding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackInstanceType">The System.Type that provides the callback instance that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="endpointRemoteAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        public DuplexChannelFactory(Type callbackInstanceType, Binding binding, EndpointAddress endpointRemoteAddress)
            : base(callbackInstanceType, binding, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexChannelFactory class.
        /// </summary>
        /// <param name="callbackInstanceType">The System.Type that provides the callback instance that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="remoteAddress">The remote address that provides the location of the service.</param>
        public DuplexChannelFactory(Type callbackInstanceType, Binding binding, string remoteAddress)
            : base(callbackInstanceType, binding, remoteAddress)
        {
        }

        /// <summary>
        /// Creates a duplex channel between a service and a callback instance on the client.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service.</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        /// <returns>A channel of type T, the generic parameter for the factory, between the client and service.</returns>
        public static T CreateChannel(InstanceContext<C> instanceContext, string endpointConfigurationName)
        {
            return DuplexChannelFactory<T>.CreateChannel(instanceContext.Context, endpointConfigurationName);
        }

        /// <summary>
        /// Creates a duplex channel between a service and a callback instance on the client.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="endpointAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        /// <returns>A channel of type T, the generic parameter for the factory, between the client and service.</returns>
        public static T CreateChannel(InstanceContext<C> instanceContext, Binding binding, EndpointAddress endpointAddress)
        {
            return DuplexChannelFactory<T>.CreateChannel(instanceContext.Context, binding, endpointAddress);
        }

        /// <summary>
        /// Creates a duplex channel between a service and a callback instance on the client.
        /// </summary>
        /// <param name="instanceContext">The System.ServiceModel.InstanceContext that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="endpointAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        /// <param name="via">The System.Uri that contains the transport address to which the message is sent.</param>
        /// <returns>A channel of type T, the generic parameter for the factory, between the client and service.</returns>
        public static T CreateChannel(InstanceContext<C> instanceContext, Binding binding, EndpointAddress endpointAddress, Uri via)
        {
            return DuplexChannelFactory<T>.CreateChannel(instanceContext.Context, binding, endpointAddress, via);
        }

        /// <summary>
        /// Creates a duplex channel between a service and a callback instance on the client.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="endpointConfigurationName">The name used for the endpoint configuration.</param>
        /// <returns>A channel of type T, the generic parameter for the factory, between the client and service.</returns>
        public static T CreateChannel(C callbackObject, string endpointConfigurationName)
        {
            return DuplexChannelFactory<T>.CreateChannel(callbackObject, endpointConfigurationName);
        }

        /// <summary>
        /// Creates a duplex channel between a service and a callback instance on the client.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="endpointAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        /// <returns>A channel of type T, the generic parameter for the factory, between the client and service.</returns>
        public static T CreateChannel(C callbackObject, Binding binding, EndpointAddress endpointAddress)
        {
            return DuplexChannelFactory<T>.CreateChannel(callbackObject, binding, endpointAddress);
        }

        /// <summary>
        /// Creates a duplex channel between a service and a callback instance on the client.
        /// </summary>
        /// <param name="callbackObject">The System.Object that the client uses to listen for messages from the connected service.</param>
        /// <param name="binding">The System.ServiceModel.Channels.Binding used to connect to the service by channels produced by the factory.</param>
        /// <param name="endpointAddress">The System.ServiceModel.EndpointAddress that provides the location of the service.</param>
        /// <param name="via">The System.Uri that contains the transport address to which the message is sent.</param>
        /// <returns>A channel of type T, the generic parameter for the factory, between the client and service.</returns>
        public static T CreateChannel(C callbackObject, Binding binding, EndpointAddress endpointAddress, Uri via)
        {
            return DuplexChannelFactory<T>.CreateChannel(callbackObject, binding, endpointAddress, via);
        }
    }
}
