//-----------------------------------------------------------------------
// <copyright file="CommunicationWrapper.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Hosting
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <typeparam name="I">The type of the service contract.</typeparam>
    /// <typeparam name="S">The type of the implemented service contract.</typeparam>
    public abstract class CommunicationWrapper<I, S> : ICommunicationObject, IDisposable
        where I : class
        where S : class, I
    {
        /// <summary>
        /// Initializes a new instance of the CommunicationWrapper class.
        /// </summary>
        protected CommunicationWrapper()
        {
            this.Proxy = InProcServiceFactory.CreateChannel<I, S>();
        }

        /// <summary>
        /// Occurs when the communication object completes its transition from the closing state into the closed state.
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        /// Occurs when the communication object first enters the closing state.
        /// </summary>
        public event EventHandler Closing;

        /// <summary>
        /// Occurs when the communication object first enters the faulted state.
        /// </summary>
        public event EventHandler Faulted;

        /// <summary>
        /// Occurs when the communication object completes its transition from the opening state into the opened state.
        /// </summary>
        public event EventHandler Opened;

        /// <summary>
        /// Occurs when the communication object first enters the opening state.
        /// </summary>
        public event EventHandler Opening;

        /// <summary>
        /// Gets the current state of the communication-oriented object.
        /// </summary>
        public CommunicationState State
        {
            get 
            {
                return (this.Proxy as ICommunicationObject).State;
            }
        }

        /// <summary>
        /// Gets the communication-oriented object exposed as a proxy.
        /// </summary>
        protected I Proxy
        {
            get;
            private set;
        }

        /// <summary>
        /// Causes a communication object to transition from its current state into the closed state.
        /// </summary>
        void ICommunicationObject.Close()
        {
            (this.Proxy as ICommunicationObject).Close();
        }

        /// <summary>
        /// Causes a communication object to transition immediately from its current state into the closed state.
        /// </summary>
        public void Abort()
        {
            (this.Proxy as ICommunicationObject).Abort();
        }

        /// <summary>
        /// Begins an asynchronous operation to close a communication object with a specified timeout.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous close operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous close operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous close operation.</returns>
        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return (this.Proxy as ICommunicationObject).BeginClose(timeout, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to close a communication object.
        /// </summary>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous close operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous close operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous close operation.</returns>
        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return (this.Proxy as ICommunicationObject).BeginClose(callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to open a communication object within a specified interval of time.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous open operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous open operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous open operation.</returns>
        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return (this.Proxy as ICommunicationObject).BeginOpen(timeout, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to open a communication object.
        /// </summary>
        /// <param name="callback">The System.AsyncCallback delegate that receives notification of the completion of the asynchronous open operation.</param>
        /// <param name="state">An object, specified by the application, that contains state information associated with the asynchronous open operation.</param>
        /// <returns>The System.IAsyncResult that references the asynchronous open operation.</returns>
        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return (this.Proxy as ICommunicationObject).BeginOpen(callback, state);
        }

        /// <summary>
        /// Causes a communication object to transition from its current state into the closed state.
        /// </summary>
        public void Close()
        {
            InProcServiceFactory.CloseChannel<I>(this.Proxy);
        }

        /// <summary>
        /// Causes a communication object to transition from its current state into the closed state.
        /// </summary>
        /// <param name="timeout">The System.Timespan that specifies how long the send operation has to complete before timing out.</param>
        public void Close(TimeSpan timeout)
        {
            InProcServiceFactory.CloseChannel<I>(this.Proxy, timeout);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }

        /// <summary>
        /// Completes an asynchronous operation to close a communication object.
        /// </summary>
        /// <param name="result">The System.IAsyncResult that is returned by a call to the System.ServiceModel.ICommunicationObject.BeginClose() method.</param>
        public void EndClose(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Completes an asynchronous operation to open a communication object.
        /// </summary>
        /// <param name="result">The System.IAsyncResult that is returned by a call to the System.ServiceModel.ICommunicationObject.BeginOpen() method.</param>
        public void EndOpen(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Causes a communication object to transition from the created state into the opened state within a specified interval of time.
        /// </summary>
        /// <param name="timeout">The System.ServiceModel.ICommunicationObject was unable to be opened and has entered the System.ServiceModel.CommunicationState.Faulted state.</param>
        public void Open(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Causes a communication object to transition from the created state into the opened state.
        /// </summary>
        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}
