namespace OpenBroker.Models;
public class KeyPack
{
    /// <summary>
    /// appkey
    /// </summary>
    public string AppKey { get; set; } = string.Empty;

    /// <summary>
    /// secret
    /// </summary>
    public string SecretKey { get; set; } = string.Empty;

    /// <summary>
    /// Access Token : for restful api
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Access Token Expiration Date
    /// </summary>
    public DateTime? AccessTokenExpired { get; set; }

    /// <summary>
    /// Access Token : for Websocket(optional)
    /// </summary>
    public string WebsocketCode { get; set; } = string.Empty;

}
