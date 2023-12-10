using Oswatech.Debugging;

namespace Oswatech
{
    public class OswatechConsts
    {
        public const string LocalizationSourceName = "Oswatech";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "08db2551d6eb43b0a1dc1c4a6f349b7f";
    }
}
