using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Sitecore.Feature.VideoReviews.Extensions
{
    public static class XmlExtensions
    {
        /// <summary>
        /// Gets the element by xname passed, method checks for null condition and returns the element value on a successfull
        /// try parse. If the parse is unsuccessful, this returns the default value passed
        /// </summary>
        /// <typeparam name="T">type of datatype</typeparam>
        /// <param name="this">xelement from which the elemen needs to be found</param>
        /// <param name="elementName">name of the x element</param>
        /// <param name="mapper">pass the type of parsing to be performed. example
        /// pass int.TryParse, float.TryParse etc</param>
        /// <param name="defaultValue">In case parsing fails pass a default value, for example "-1/string.Empty/" etc</param>
        /// <returns></returns>
        public static T GetElementValue<T>(this XElement @this, XName elementName, TryParseMapper<T> mapper, T defaultValue) where T : struct
        {
            string valueToConvert = @this.GetElementValueAsString(elementName);
            T result;

            if (mapper(valueToConvert, out result))
                return result;

            return defaultValue;
        }

        /// <summary>
        /// Gets the value of the element as string
        /// </summary>
        /// <param name="this"></param>
        /// <param name="elementName">element name</param>
        /// <returns>element value</returns>
        public static string GetElementValueAsString(this XElement @this, XName elementName)
        {
            if (@this != null)
            {
                return @this.Element(elementName) == null ? string.Empty : @this.Element(elementName).Value;
            }
            return string.Empty;
        }

        public static Uri GetElementValueAsUri(this XElement @this, XName elementName)
        {
            Uri returnValue = null;
            string elementValue = @this.GetElementValueAsString(elementName);
            if (!string.IsNullOrWhiteSpace(elementValue))
            {
                Uri.TryCreate(elementValue, UriKind.Absolute, out returnValue);
            }
            return returnValue;
        }

        public delegate bool TryParseMapper<T>(string value, out T result);
    }
}