//-----------------------------------------------------------------------
// <copyright file="ServiceValidations.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------
namespace Home.VS2010.Common.Services.Validation
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using Resources;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class ServiceValidations
    {
        public static void ValidateCallbackContractForType<T, C>()
            where T : class
        {
            Type contractType = typeof(T);
            Type callbackType = typeof(C);

            object[] attributes = contractType.GetCustomAttributes(typeof(ServiceContractAttribute), false);
            if (attributes.Length == 0)
            {
                throw new InvalidOperationException(string.Format(Strings.TypeNotDefineServiceContract, contractType.Name));
            }

            ServiceContractAttribute serviceContractAttribute = attributes.Single() as ServiceContractAttribute;
            if (serviceContractAttribute.CallbackContract != callbackType)
            {
                throw new InvalidOperationException(string.Format(Strings.TypeNotDefineCallbackContract, callbackType.Name, contractType.Name));
            }
        }

        public static void ValidateServiceContractForType<T>()
        {
            Type contractType = typeof(T);

            object[] customAttributes = contractType.GetCustomAttributes(typeof(ServiceContractAttribute), false);
            if (customAttributes.Length == 0)
            {
                throw new InvalidOperationException(string.Format(Strings.TypeNotDefineServiceContract, contractType.Name));
            }
        }
    }
}
