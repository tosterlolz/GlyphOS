using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Exit
    {
        public static void Execute()
        {
            Logger.Info("Shutting down...");
            Cosmos.System.Power.Shutdown();
        }
    }
}
