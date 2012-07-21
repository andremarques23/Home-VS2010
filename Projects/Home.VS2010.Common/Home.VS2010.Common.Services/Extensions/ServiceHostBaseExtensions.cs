//-----------------------------------------------------------------------
// <copyright file="ServiceHostBaseExtensions.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Extensions
{
    using System.ServiceModel;

    /// <summary>
    /// System.ServiceModel.ServiceHostBase extension methods.
    /// </summary>
    public static class ServiceHostBaseExtensions
    {
        /// <summary>
        /// Enable the hosted service to perform impersonation for all the operations that it supports.
        /// </summary>
        /// <param name="serviceHostBase">The service host.</param>
        public static void ImpersonateAll(this ServiceHostBase serviceHostBase)
        {
            serviceHostBase.Authorization.ImpersonateCallerForAllOperations = true;
            serviceHostBase.Description.ImpersonateAll();
        }
    }
}
