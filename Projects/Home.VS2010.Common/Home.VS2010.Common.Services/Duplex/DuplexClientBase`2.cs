//-----------------------------------------------------------------------
// <copyright file="DuplexClientBase.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Duplex
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using Home.VS2010.Common.Services.Validation;

    /// <summary>
    /// Used to create a channel to a duplex service and associate that channel with a callback object.
    /// </summary>
    /// <typeparam name="T">The type of the channel to be created.</typeparam>
    /// <typeparam name="C">The callback object that implements the service instance.</typeparam>
    public abstract class DuplexClientBase<T, C> : DuplexClientBase<T>
        where T : class
    {
        /// <summary>
        /// Initializes static members of the DuplexClientBase class.
        /// </summary>
        static DuplexClientBase()
        {
            ServiceValidations.ValidateCallbackContractForType<T, C>();
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="instanceContext">An System.ServiceModel.InstanceContext object that associates the callback object with the channel to the service.</param>
        protected DuplexClientBase(InstanceContext<C> instanceContext)
            : base(instanceContext.Context)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="instanceContext">An System.ServiceModel.InstanceContext object that associates the callback object with the channel to the service.</param>
        /// <param name="serviceEndpoint">The service endpoint.</param>
        protected DuplexClientBase(InstanceContext<C> instanceContext, ServiceEndpoint serviceEndpoint)
            : base(instanceContext.Context, serviceEndpoint)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="instanceContext">An System.ServiceModel.InstanceContext object that associates the callback object with the channel to the service.</param>
        /// <param name="endpointConfigurationName">The name of the client endpoint information in the application configuration file.</param>
        protected DuplexClientBase(InstanceContext<C> instanceContext, string endpointConfigurationName)
            : base(instanceContext.Context, endpointConfigurationName)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="instanceContext">An System.ServiceModel.InstanceContext object that associates the callback object with the channel to the service.</param>
        /// <param name="endpointConfigurationName">The name of the client endpoint information in the application configuration file.</param>
        /// <param name="endpointRemoteAddress">The address of the service endpoint to use.</param>
        protected DuplexClientBase(InstanceContext<C> instanceContext, string endpointConfigurationName, string endpointRemoteAddress)
            : base(instanceContext.Context, endpointConfigurationName, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="instanceContext">An System.ServiceModel.InstanceContext object that associates the callback object with the channel to the service.</param>
        /// <param name="endpointConfigurationName">The name of the client endpoint information in the application configuration file.</param>
        /// <param name="endpointRemoteAddress">The service endpoint address to use.</param>
        protected DuplexClientBase(InstanceContext<C> instanceContext, string endpointConfigurationName, EndpointAddress endpointRemoteAddress)
            : base(instanceContext.Context, endpointConfigurationName, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="instanceContext">An System.ServiceModel.InstanceContext object that associates the callback object with the channel to the service.</param>
        /// <param name="binding">The binding with which to call the service.</param>
        /// <param name="endpointRemoteAddress">The service endpoint address to use.</param>
        protected DuplexClientBase(InstanceContext<C> instanceContext, Binding binding, EndpointAddress endpointRemoteAddress)
            : base(instanceContext.Context, binding, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="callbackInstance">An object used to create the instance context that associates the callback object with the channel to the service.</param>
        protected DuplexClientBase(object callbackInstance)
            : base(callbackInstance)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="callbackInstance">An object used to create the instance context that associates the callback object with the channel to the service.</param>
        /// <param name="serviceEndpoint">The service endpoint.</param>
        protected DuplexClientBase(object callbackInstance, ServiceEndpoint serviceEndpoint)
            : base(callbackInstance, serviceEndpoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="callbackInstance">An object used to create the instance context that associates the callback object with the channel to the service.</param>
        /// <param name="endpointConfigurationName">The name of the client endpoint information in the application configuration file.</param>
        protected DuplexClientBase(object callbackInstance, string endpointConfigurationName)
            : base(callbackInstance, endpointConfigurationName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="callbackInstance">An object used to create the instance context that associates the callback object with the channel to the service.</param>
        /// <param name="endpointConfigurationName">The name of the client endpoint information in the application configuration file.</param>
        /// <param name="endpointRemoteAddress">The address of the service endpoint to use.</param>
        protected DuplexClientBase(object callbackInstance, string endpointConfigurationName, string endpointRemoteAddress)
            : base(callbackInstance, endpointConfigurationName, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="callbackInstance">An object used to create the instance context that associates the callback object with the channel to the service.</param>
        /// <param name="endpointConfigurationName">The name of the client endpoint information in the application configuration file.</param>
        /// <param name="endpointRemoteAddress">The address of the service endpoint to use.</param>
        protected DuplexClientBase(object callbackInstance, string endpointConfigurationName, EndpointAddress endpointRemoteAddress)
            : base(callbackInstance, endpointConfigurationName, endpointRemoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DuplexClientBase class.
        /// </summary>
        /// <param name="callbackInstance">An object used to create the instance context that associates the callback object with the channel to the service.</param>
        /// <param name="binding">The binding with which to call the service.</param>
        /// <param name="endpointRemoteAddress">The service endpoint address to use.</param>
        protected DuplexClientBase(object callbackInstance, Binding binding, EndpointAddress endpointRemoteAddress)
            : base(callbackInstance, binding, endpointRemoteAddress)
        {
        }
    }
}
