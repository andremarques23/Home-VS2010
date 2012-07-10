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
    using Resources;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class BindingValidations
    {
        public static void ValidateReliabilityEnabled(ServiceEndpoint serviceEndpoint)
        {
            Binding binding = serviceEndpoint.Binding;

            if (binding is NetNamedPipeBinding)
            {
                return;
            }

            if (binding is WSDualHttpBinding)
            {
                return;
            }

            if (binding is NetTcpBinding)
            {
                NetTcpBinding netTcpBinding = binding as NetTcpBinding;
                if (netTcpBinding.ReliableSession.Enabled)
                {
                    return;
                }
            }

            if (binding is WSHttpBindingBase)
            {
                WSHttpBindingBase wsHttpBindingBase = binding as WSHttpBindingBase;
                if (wsHttpBindingBase.ReliableSession.Enabled)
                {
                    return;
                }
            }

            throw new InvalidOperationException(Strings.ReliabilityNotSuportedOrDisabled);
        }

        public static void ValidateTransactionFlowEnabled(ServiceEndpoint serviceEndpoint)
        { 
        }

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
