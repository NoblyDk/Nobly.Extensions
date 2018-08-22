using System;
using Microsoft.AspNetCore.Builder;

namespace Nobly.Extensions.MaintainCorsHeaders
{
    public static class MaintainCorsHeadersExtensions
    {
        /// <summary>
        /// Ensure all CORS headers remain or else add them back in ...
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMaintainCorsHeaders(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.UseMiddleware<MaintainCorsHeadersMiddleware>();
        }

    }
}
