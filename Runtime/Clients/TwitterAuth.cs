// ***********************************************************************
// 文件名：         TwitterAuth.cs
// 创建日期：       2024/12/31
// 功能说明：
// 作者：           NekoPunch!
// ***********************************************************************

using Cdm.Authentication.OAuth2;

namespace Cdm.Authentication.Clients
{
    public class TwitterAuth : AuthorizationCodeFlowWithPkce
    {
        public override string authorizationUrl => "https://twitter.com/i/oauth2/authorize";
        public override string accessTokenUrl => "https://api.x.com/2/oauth2/token";
        public string userInfoUrl => "https://api.x.com/2/users/me";

        public string CodeVerifier => _codeVerifier;
        
        public TwitterAuth(Configuration configuration) : base(configuration)
        {
        }
    }
}