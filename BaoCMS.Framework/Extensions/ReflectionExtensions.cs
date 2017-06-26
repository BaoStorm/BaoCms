using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BaoCMS.Framework.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool HasProperty(this object obj, string name)
        {
            return obj.GetType().GetRuntimeProperty(name) != null;
        }

        public static bool HasValue(this object obj, string name)
        {
            var currentProperty = obj.GetType().GetRuntimeProperty(name);
            if (currentProperty == null)
                return false;
            var caurrentValue = currentProperty.GetValue(obj);
            var defaultValue = Activator.CreateInstance(obj.GetType()).GetType().GetRuntimeProperty(name).GetValue(obj);
            return caurrentValue != defaultValue;
        }

        public static void SetValue(this object obj, string name, object value)
        {
            obj.GetType().GetRuntimeProperty(name).SetValue(obj, value);
        }

        public static IEnumerable<T> GetImplementationsOf<T>(this Assembly assembly)
        {
            var result = new List<T>();

            var types = assembly.GetTypes()
                .Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && typeof(T).IsAssignableFrom(t))
                .ToList();

            foreach (var type in types)
            {
                var instance = (T)Activator.CreateInstance(type);
                result.Add(instance);
            }

            return result;
        }

        public static IEnumerable<T> GetImplementationsOf<T>(this IEnumerable<Assembly> assemblies)
        {
            var result = new List<T>();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && typeof(T).IsAssignableFrom(t))
                    .ToList();

                foreach (var type in types)
                {
                    var instance = (T)Activator.CreateInstance(type);
                    result.Add(instance);
                }
            }

            return result;
        }

        public static IEnumerable<Assembly> GetRuntimeAssemblies()
        {
            var result = new List<Assembly>();
            var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
            var assemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId);
            foreach (var assemblyName in assemblyNames)
            {
                var assembly = Assembly.Load(assemblyName);
                result.Add(assembly);
            }
            return result;
        }
    }
}
