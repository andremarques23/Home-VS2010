//-----------------------------------------------------------------------
// <copyright file="ServiceHostExtensions.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Extensions
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Resources;

    /// <summary>
    /// System.ServiceModel.ServiceHost extension methods.
    /// </summary>
    public static class ServiceHostExtensions
    {
        /// <summary>
        /// Sets run-time throughput settings for service performance tunning.
        /// </summary>
        /// <param name="serviceHost">The service host.</param>
        /// <param name="serviceThrottlingBehavior">System.ServiceModel.Description.ServiceThrottlingBehavior containing the settings.</param>
        /// <param name="overrideConfiguration">Overrides values at configuration file. The default is false.</param>
        public static void SetThrottle(this ServiceHost serviceHost, ServiceThrottlingBehavior serviceThrottlingBehavior, bool overrideConfiguration = false)
        {
            if (serviceHost.State == CommunicationState.Opened)
            {
                throw new InvalidOperationException(Strings.HostAlreadyOpened);
            }

            ServiceThrottlingBehavior currentThrottlingBehavior = serviceHost.Description.Behaviors.Find<ServiceThrottlingBehavior>();
            if (currentThrottlingBehavior == null)
            {
                serviceHost.Description.Behaviors.Add(serviceThrottlingBehavior);
                return;
            }

            if (overrideConfiguration)
            {
                serviceHost.Description.Behaviors.Remove(currentThrottlingBehavior);
                serviceHost.Description.Behaviors.Add(serviceThrottlingBehavior);
            }
        }

        /// <summary>
        /// Sets run-time throughput settings that enable you to tune service performance.
        /// </summary>
        /// <param name="serviceHost">The service host.</param>
        /// <param name="maxConcurrentCalls">The maximum number of messages actively processing across a System.ServiceModel.ServiceHost.</param>
        /// <param name="maxConcurrentInstances">The maximum number of System.ServiceModel.InstanceContext objects in the service that can execute at one time.</param>
        /// <param name="maxConcurrentSessions">The maximum number of sessions a System.ServiceModel.ServiceHost object can accept at one time.</param>
        public static void SetThrottle(this ServiceHost serviceHost, int maxConcurrentCalls, int maxConcurrentInstances, int maxConcurrentSessions)
        {
            ServiceThrottlingBehavior serviceThrottlingBehavior = new ServiceThrottlingBehavior
                                                                  {
                                                                      MaxConcurrentCalls = maxConcurrentCalls,
                                                                      MaxConcurrentInstances = maxConcurrentCalls,
                                                                      MaxConcurrentSessions = maxConcurrentSessions
                                                                  };

            serviceHost.SetThrottle(serviceThrottlingBehavior);
        }
    }
}
