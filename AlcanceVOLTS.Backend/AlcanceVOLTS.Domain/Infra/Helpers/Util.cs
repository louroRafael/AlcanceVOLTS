using System.Security.Cryptography;
using System.Reflection;
using System.Text;
using System.Linq;

namespace AlcanceVOLTS.Domain.Infra.Helpers
{
    public static class Util
    {
        #region Cryptography
        public static string ToMD5(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var result = new StringBuilder();
            var bytes = new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString("X2"));

            var teste = result.ToString();

            return result.ToString();
        }

        #endregion

        #region Reflection

        public static List<Type> GetTypesOf(this Assembly assembly, Type baseType) => assembly
            .GetTypes()
            .Where(type =>
                type.BaseType != null
                && (
                    (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == baseType)) // -> Generics, ex: CrudRepository<>
                    || (baseType.IsAssignableFrom(type) && !type.IsAbstract) // -> Non generics, ex: Repository
                )
            .ToList();

        #endregion

        #region String

        public static string ToTitleCase(this string input)
        {
            var words = input.ToLower().Split(" ");

            for(var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var titleCaseWord = word[0].ToString().ToUpper() + word.Substring(1);
                words[i] = titleCaseWord;
            }

            return String.Join(" ", words);
        }

        #endregion String
    }
}
