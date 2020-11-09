﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace ApiRETS.App_Start
{
    public class AccessPolicyCors: Attribute, ICorsPolicyProvider
    {
        
        

        public async Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corsRequestContext = request.GetCorsRequestContext();
            var originRequest = corsRequestContext.Origin;
            if (await IsOriginFromCustomer(originRequest))
            {
                var policy = new CorsPolicy
                {
                    AllowAnyHeader = true,
                    AllowAnyMethod = true
                };

                policy.Origins.Add(originRequest);
                //policy.Origins.Add("http://localhost:60751/api/Cliente");
                return policy;
            }
            return null;
        }

        private async Task<bool> IsOriginFromCustomer(string originRequest)
        {
            return true;
        }
    }
}