#region License

// --------------------------------------------------
// Copyright © 2003-2011 OKB. All Rights Reserved.
// 
// This software is proprietary information of OKB.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Mono.Collections.Generic;
using com.gargoylesoftware.htmlunit;

using Mono.Cecil;

namespace NHtmlUnit.Generator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Transform();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }


        private static void Transform()
        {
            ReaderParameters parameters = new ReaderParameters(ReadingMode.Immediate);

            string fileName = typeof(WebClient).Assembly.Location;

            Console.WriteLine("Reading {0}.", fileName);

            AssemblyDefinition htmlUnitAssembly =
                AssemblyDefinition.ReadAssembly(fileName, parameters);

            //Iterate through all classes

     

            foreach (var typeDefinition in htmlUnitAssembly.MainModule.Types.Where(x => x.Namespace.StartsWith("com.gargoylesoftware.htmlunit") && x.IsPublic))
            {

                IDictionary<MethodDefinition, MethodDefinition> properties = null;

                Console.WriteLine("\tClass: {0}", typeDefinition.Name);
                //Find all the getters and isses.
                
                var publicMethods = typeDefinition.Methods.Where(x => x.IsPublic);
                if (publicMethods.Count() > 0)
                {
                     properties = new ConcurrentDictionary<MethodDefinition, MethodDefinition>();
                     IEnumerable<MethodDefinition> getters = publicMethods.Where(x => x.Name.StartsWith("get") || x.Name.StartsWith("is") && x.Parameters.Count == 0);
                     IEnumerable<MethodDefinition> setters = publicMethods.Where(x => x.Name.StartsWith("set") && x.Parameters.Count > 0);

                    IList<PropertyDefinition> propertyDefinitions = new Collection<PropertyDefinition>();
                     
                    foreach (var getMethod in getters)
                    {
                        string name = null;
                        name = getMethod.Name.Remove(getMethod.Name.StartsWith("get") ? 2 : 1);
                        MethodDefinition setMethod = setters.FirstOrDefault(x => x.Name.EndsWith(name));
                        properties.Add(new KeyValuePair<MethodDefinition, MethodDefinition>(getMethod, setMethod));
                    }


                    foreach (KeyValuePair<MethodDefinition, MethodDefinition> property in properties)
                    {
                        string name = property.Key.Name.Remove(2);
                        PropertyDefinition definition = new PropertyDefinition(name, PropertyAttributes.HasDefault, property.Key.ReturnType);
                        definition.GetMethod = property.Key;
                        definition.SetMethod = property.Value;
                        propertyDefinitions.Add(definition);

                    }

                    foreach(var prop in propertyDefinitions)
                        typeDefinition.Properties.Add(prop);

                    /* Console.WriteLine("\t\tGetters && Isses: ");
                     foreach (
                         var methodDefinition in
                             publicMethods.Where(
                                 x => x.Name.StartsWith("get") || x.Name.StartsWith("is") && x.Parameters.Count == 0))
                     {
                         Console.WriteLine("\t\t\t{0}", methodDefinition.Name);
                     }
                    
                     Console.WriteLine("\t\tSetters: ");
                     foreach (
                         var methodDefinition in
                             publicMethods.Where(x => x.Name.StartsWith("set") && x.Parameters.Count > 0))
                     {
                         Console.WriteLine("\t\t\t{0}", methodDefinition.Name);
                     }
                     * */
                }

                

            }
        }
    }
}