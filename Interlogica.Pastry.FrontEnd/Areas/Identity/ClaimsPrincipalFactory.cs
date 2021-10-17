﻿using Interlogica.Pastry.FrontEnd.Data;
using Interlogica.Pastry.FrontEnd.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Interlogica.Pastry.FrontEnd.Areas.identity
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    {

        private readonly IApiClient _apiClient;
        public ClaimsPrincipalFactory(IApiClient apiClient,UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _apiClient = apiClient;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            if (user.IsAdmin)
            {
                identity.MakeAdmin();
            }
            return identity;
        }

    }
}
