//-----------------------------------------------------------------------
// <copyright file="ServiceHost{T}.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Hosting
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// Provides a typed host for services.
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
        /// Initializes a new instance of the System.ServiceModel.ServiceHost class with 
        /// the type of service and its base addresses specified.
        /// </summary>
        /// <param name="baseAddresses">An array of type System.Uri that contains the base addresses for the hosted service.</param>
        public ServiceHost(params Uri[] baseAddresses)
            : base(typeof(T), baseAddresses)
        {
        }
    }
}
