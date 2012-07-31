// -----------------------------------------------------------------------
// <copyright file="ServiceHostFactory.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Hosting
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    /// <summary>
    /// Factory that provides instances of ServiceHost in managed hosting environments where the host instance is created dynamically in response to incoming messages.
    /// </summary>
    /// <typeparam name="T">The type of the hosted service.</typeparam>
    public class ServiceHostFactory<T> : ServiceHostFactory
    {
        /// <summary>
        /// Creates a ServiceHost for a specified type of service with a specific base address.
        /// </summary>
        /// <param name="serviceType">Specifies the type of service to host.</param>
        /// <param name="baseAddresses">The array of type System.Uri that contains the base addresses for the service hosted.</param>
        /// <returns>A ServiceHost for the type of service specified with a specific base address.</returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new ServiceHost<T>(baseAddresses);
        }
    }
}
