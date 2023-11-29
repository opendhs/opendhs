﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opensalus.Shared.Extensions
{
    public static class OpensalusEnv
    {
        public static void SetWebRoot() {
            Environment.SetEnvironmentVariable("WEBROOT", Path.Combine(Environment.CurrentDirectory, "wwwroot"));
        }
        public static string GetWebRoot()
        {
            var webRootPath = Environment.GetEnvironmentVariable("WEBROOT");
            if (string.IsNullOrEmpty(webRootPath))
            {
                throw new ArgumentNullException("WEBROOT Environment Variable");
            }
            return webRootPath;
        }
    }
}
