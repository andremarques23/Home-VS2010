// -----------------------------------------------------------------------
// <copyright file="ProxyWrapper.cs" company="Home">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Home.VS2010.Common.Services.Hosting
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <typeparam name="I">The type of the service contract.</typeparam>
    /// <typeparam name="S">The type of the implemented service contract.</typeparam>
    public class ProxyWrapper<I, S>
        where I : class
        where S : class, I
    {
    }
}
