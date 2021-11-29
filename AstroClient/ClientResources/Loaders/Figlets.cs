namespace AstroClient.ClientResources.Loaders
{
    using CheetosConsole;

    internal static class Figlets
    {
        private static FigletFont _Larry3D;

        internal static FigletFont Larry3D
        {
            get
            {
                if (_Larry3D == null) return _Larry3D = FigletFont.LoadFromAssembly("Larry3D.flf");
                return _Larry3D;
            }
        }
    }
}