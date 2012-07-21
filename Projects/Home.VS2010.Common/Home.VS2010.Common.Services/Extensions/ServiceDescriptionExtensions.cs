//-----------------------------------------------------------------------
// <copyright file="ServiceDescriptionExtensions.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Extensions
{
    using System.ServiceModel;
    using System.ServiceModel.Description;

    /// <summary>
    /// System.ServiceModel.Description.ServiceDescription extension methods.
    /// </summary>
    public static class ServiceDescriptionExtensions
    {
        /// <summary>
        /// Enables the service to impersonates the client in all its operations setting the level of caller impersonation to required.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        public static void ImpersonateAll(this ServiceDescription serviceDescription)
        {
            foreach (ServiceEndpoint serviceEndpoint in serviceDescription.Endpoints)
            {
                if (serviceEndpoint.Contract.Name == typeof(IMetadataExchange).Name)
                {
                    continue;
                }

                foreach (OperationDescription operationDescription in serviceEndpoint.Contract.Operations)
                {
                    OperationBehaviorAttribute operationBehaviorAttribute = operationDescription.Behaviors.Find<OperationBehaviorAttribute>();
                    operationBehaviorAttribute.Impersonation = ImpersonationOption.Required;
                }
            }
        }
    }
}
