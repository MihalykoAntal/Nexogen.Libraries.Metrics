﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexogen.Libraries.Metrics.Prometheus.AspCore
{
    public static class PrometheusExtensions
    {
        /// <summary>
        /// Configure DI for using the Prometheus Metrics library.
        /// </summary>
        /// <param name="services"></param>
        public static void AddPrometheus(this IServiceCollection services)
        {
            var prometheus = new PrometheusMetrics();

            services.AddSingleton<IMetrics>(prometheus);
            services.AddSingleton<IExposable>(prometheus);

            services.AddSingleton<HttpMetrics, HttpMetrics>();
        }

        /// <summary>
        /// Add Prometheus Metrics support to the application.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UsePrometheus(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpMetricsMiddleware>();
        }
    }
}
