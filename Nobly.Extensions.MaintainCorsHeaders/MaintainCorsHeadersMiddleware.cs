﻿using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Nobly.Extensions.MaintainCorsHeaders
{
    public class MaintainCorsHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        static MaintainCorsHeadersMiddleware()
        {
           
        }

        public MaintainCorsHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }
       
        public async Task Invoke(HttpContext httpContext) {
            // Find and hold onto any CORS related headers ...
            var corsHeaders = new HeaderDictionary();
            foreach (var pair in httpContext.Response.Headers) {
                if (!pair.Key.StartsWith("access-control-", StringComparison.OrdinalIgnoreCase))
                {
                    continue; // Not CORS related
                } 
                corsHeaders[pair.Key] = pair.Value;
            }

            // Bind to the OnStarting event so that we can make sure these CORS headers are still included going to the client
            httpContext.Response.OnStarting(o => {
                var ctx     = (HttpContext)o;
                var headers = ctx.Response.Headers;
                // Ensure all CORS headers remain or else add them back in ...
                foreach (var pair in corsHeaders) {
                    if (headers.ContainsKey(pair.Key))
                    {
                        continue; // Still there!
                    } 
                    headers.Add(pair.Key, pair.Value);
                }
                return Task.CompletedTask;
            }, httpContext);

            // Call the pipeline ...
            await _next(httpContext);
        }
    }
}