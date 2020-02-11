using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.CustomPolicyProvider
{
    public class CustomAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public CustomAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
        {

        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            throw new NotImplementedException();
        }
    }
}
