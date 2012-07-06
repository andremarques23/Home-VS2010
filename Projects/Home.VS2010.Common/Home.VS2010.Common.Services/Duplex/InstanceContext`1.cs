//-----------------------------------------------------------------------
// <copyright file="InstanceContext.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Duplex
{
    using System.ServiceModel;

    /// <summary>
    /// Represents the context information for a service instance.
    /// </summary>
    /// <typeparam name="T">The callback object that implements the service instance.</typeparam>
    public class InstanceContext<T>
    {
        /// <summary>
        /// Initializes a new instance of the InstanceContext class.
        /// </summary>
        /// <param name="callbackInstance">The callback that implements the service instance.</param>
        public InstanceContext(T callbackInstance)
        {
            this.Context = new InstanceContext(callbackInstance);
        }

        /// <summary>
        /// Gets the context information for a service instance.
        /// </summary>
        public InstanceContext Context
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the instance of the service for the instance context.
        /// </summary>
        public T ServiceInstance
        {
            get
            {
                return (T)this.Context.GetServiceInstance();
            }
        }

        /// <summary>
        /// Releases the service instance.
        /// </summary>
        public void ReleaseServiceInstance()
        {
            this.Context.ReleaseServiceInstance();
        }
    }
}
