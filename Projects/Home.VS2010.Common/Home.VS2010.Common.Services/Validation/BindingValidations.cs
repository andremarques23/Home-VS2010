//-----------------------------------------------------------------------
// <copyright file="BindingValidations.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Validation
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using Microsoft.CSharp.RuntimeBinder;
    using Resources;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class BindingValidations
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="serviceEndpoint">The service endpoint.</param>
        public static void ValidateReliabilityEnabled(ServiceEndpoint serviceEndpoint)
        {
            if (serviceEndpoint.Binding is NetNamedPipeBinding)
            {
                return;
            }

            if (serviceEndpoint.Binding is WSDualHttpBinding)
            {
                return;
            }

            if (serviceEndpoint.Binding is NetTcpBinding)
            {
                NetTcpBinding netTcpBinding = serviceEndpoint.Binding as NetTcpBinding;
                if (netTcpBinding.ReliableSession.Enabled)
                {
                    return;
                }
            }

            if (serviceEndpoint.Binding is WSHttpBindingBase)
            {
                WSHttpBindingBase wsHttpBindingBase = serviceEndpoint.Binding as WSHttpBindingBase;
                if (wsHttpBindingBase.ReliableSession.Enabled)
                {
                    return;
                }
            }

            throw new InvalidOperationException(Strings.ReliabilityNotSuportedOrDisabled);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="serviceEndpoint">The service endpoint.</param>
        public static void ValidateTransactionFlowEnabled(ServiceEndpoint serviceEndpoint)
        {
            foreach (var operation in serviceEndpoint.Contract.Operations)
            {
                TransactionFlowAttribute transactionFlowAttribute = operation.Behaviors.Find<TransactionFlowAttribute>();
                if (transactionFlowAttribute != null)
                {
                    if (transactionFlowAttribute.Transactions == TransactionFlowOption.Allowed)
                    {
                        try
                        {
                            dynamic binding = serviceEndpoint.Binding;
                            if (!binding.TransactionFlow)
                            {
                                throw new InvalidOperationException(Strings.TransactionFlowNotSupportedOrDisable);
                            }

                            continue;
                        }
                        catch (RuntimeBinderException)
                        {
                            throw new InvalidOperationException(Strings.TransactionFlowNotSupportedOrDisable);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="serviceEndpoint">The service endpoint.</param>
        public static void ValidateOnlyWcfCommunication(ServiceEndpoint serviceEndpoint)
        {
            Binding binding = serviceEndpoint.Binding;
            if (binding is NetMsmqBinding || binding is NetNamedPipeBinding || binding is NetTcpBinding)
            {
                return;
            }

            throw new InvalidOperationException(Strings.OnlyWcfCommunicationRequired);
        }
    }
}
