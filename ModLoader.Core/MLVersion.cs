namespace ModLoader.Core
{
    // MLVersion is used both in ModLoaderLibrary and ModLoader.
    public static class MLVersion
    {
        public static readonly string Major = "0";
        public static readonly string Minor = "1";
        public static readonly string Revision = "0";
        public new static string ToString()
        {
            return Major + "." + Minor + "." + Revision;
        }
    }
}