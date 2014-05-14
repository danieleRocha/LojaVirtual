using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Apresentacao.Helpers
{
    public static class Redirect
    {
        public static RedirectToRouteResult WithRouteValue(
            this RedirectToRouteResult result,
            string key,
            object value)
        {
            if (value == null)
                throw new ArgumentException("value cannot be null");

            result.RouteValues.Add(key, value);

            return result;
        }

        public static RedirectToRouteResult WithRouteValue<T>(
            this RedirectToRouteResult result,
            string key,
            IEnumerable<T> values)
        {
            if (result.RouteValues.Keys.Any(k => k.StartsWith(key + "[")))
                throw new ArgumentException("Key already exists in collection");

            if (values == null)
                throw new ArgumentNullException("values cannot be null");

            var valuesList = values.ToList();

            for (int i = 0; i < valuesList.Count; i++)
            {
                result.RouteValues.Add(String.Format("{0}[{1}]", key, i), valuesList[i]);
            }

            return result;
        }
    }
}