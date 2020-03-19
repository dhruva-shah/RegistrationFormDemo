//using System.Collections;
//using System.Globalization;
//using System.Linq;
//using System.Reflection;
//using System.Resources;
//using System.Threading;

//namespace MHS.P4.Language
//{

//    public static class GetResources
//    {
//        /// <summary>
//        ///     ResourceHelper
//        /// </summary>
//        /// <param name="resourceName">i.e. "Namespace.ResourceFileName"</param>
//        /// <param name="assembly">i.e. GetType().Assembly if working on the local assembly</param>

//        private static ResourceManager ResourceManager
//        {
//            get
//            {
//                var type = typeof(Locale);
//                var context = System.Web.HttpContext.Current;
//                string path = context.Request.Path;
//                Thread.CurrentThread.CurrentCulture = new CultureInfo(GetCurrentCulture());
//                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(GetCurrentCulture());
//                return new ResourceManager("MHS.P4.Language.Locale", type.GetTypeInfo().Assembly);
//            }
//        }


//        public static string GetResourceName(string value)
//        {
//            DictionaryEntry entry = ResourceManager
//                                        .GetResourceSet(Thread.CurrentThread.CurrentCulture, true, true)
//                                        .OfType<DictionaryEntry>().FirstOrDefault(dictionaryEntry => dictionaryEntry.Value.ToString() == value);
//            return entry.Key.ToString();
//        }

//        public static string GetResourceValue(string name)
//        {
//            string value = ResourceManager.GetString(name);
//            return !string.IsNullOrEmpty(value) ? value : name;
//        }

//        private static string GetCurrentCulture()
//        {
//            return "en-CA";
//        }
//    }
//}

