#pragma warning disable 1591

using System.Threading.Tasks;

namespace Braintree
{
    /// <summary>
    /// Generates client tokens, which are used to authenticate requests clients make directly
    ///   on behalf of merchants
    /// </summary>
    public interface IClientTokenGateway
    {
        string generate(ClientTokenRequest request = null);
        Task<string> generateAsync(ClientTokenRequest request = null);
    }
}
