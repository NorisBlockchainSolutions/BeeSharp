#nullable enable
using System;
using System.Collections.Generic;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents
{
    public static class DirectorRegistry
    {
        private static readonly Dictionary<Type, object> Directors;

        static DirectorRegistry()
        {
            Directors = new Dictionary<Type, object>();
        }

        public static void AddDirector(Type directorType, object director)
        {
            if (Directors.ContainsKey(directorType))
                throw new ArgumentException($"Registry already contains a director of type {directorType}!");
            
            Directors.Add(directorType, director);
        }

        public static object GetDirector(Type directorType)
        {
            if(!Directors.ContainsKey(directorType))
                throw new ArgumentException($"Registry does not contain a director of type {directorType}!");

            return Directors[directorType];
        }
    }
}