using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Identity
{
    //TODO: Make constructors internal to ensure that it's called by only from IdentityUser?

    /// <summary>
    /// Represents a login and its associated provider for a user.
    /// </summary>
    public class IdentityUserLogin : Entity
    {
        /// <summary>
        /// Gets or sets the of the primary key of the user associated with this login.
        /// </summary>
        public virtual string UserId { get; protected set; }

        /// <summary>
        /// Gets or sets the login provider for the login (e.g. facebook, google)
        /// </summary>
        public virtual string LoginProvider { get; protected set; }

        /// <summary>
        /// Gets or sets the unique provider identifier for this login.
        /// </summary>
        public virtual string ProviderKey { get; protected set; }

        /// <summary>
        /// Gets or sets the friendly name used in a UI for this login.
        /// </summary>
        public virtual string ProviderDisplayName { get; protected set; }

        protected IdentityUserLogin()
        {
            
        }

        public IdentityUserLogin([NotNull] string userId, [NotNull] string loginProvider, [NotNull] string providerKey, string providerDisplayName)
        {
            Check.NotNull(userId, nameof(userId));
            Check.NotNull(loginProvider, nameof(loginProvider));
            Check.NotNull(providerKey, nameof(providerKey));

            UserId = userId;
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
            ProviderDisplayName = providerDisplayName;
        }

        public IdentityUserLogin(string userId, UserLoginInfo login)
        {
            Check.NotNull(userId, nameof(userId));
            Check.NotNull(login, nameof(login));

            UserId = userId;
            LoginProvider = login.LoginProvider;
            ProviderKey = login.ProviderKey;
            ProviderDisplayName = login.ProviderDisplayName;
        }

        public UserLoginInfo ToUserLoginInfo()
        {
            return new UserLoginInfo(LoginProvider, ProviderKey, ProviderDisplayName);
        }
    }
}