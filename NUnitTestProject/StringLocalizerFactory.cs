using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NUnitTestProject
{
    class StringLocalizerFactory : IStringLocalizerFactory
    {
        public IStringLocalizer Create(Type resourceSource)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            var type = typeof(LocService);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }
    }
}
