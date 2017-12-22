namespace Pdc.System
{
    /// <summary>
    /// Defines a mechanism for retrieving a client object; that is, an object that can send data to other objects.
    /// </summary>
    public interface IClientProvider
    {
        /// <summary>
        /// Gets the default client object.
        /// </summary>
        /// <returns>
        /// A client object of type <see cref="IClient"/>.-or-
        ///           <see langword="null"/> if there is no client object of type <see cref="IClient"/>.
        /// </returns>
        IClient GetClient();
    }
}