using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UDS.Net.Forms.Models
{
    /// <summary>
    /// This is one option for authorizing acitivity within packets, but would be better as middleware since the rules are fairly simple
    /// </summary>
    public class AuthorizedPageModel : PageModel
    {
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        public AuthorizedPageModel(IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base()
        {
            AuthorizationService = authorizationService;
            UserManager = userManager;
        }
    }
}

