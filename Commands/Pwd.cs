using GlyphOS.Resources;

namespace GlyphOS
{
    public static class Pwd
    {
        public static void Execute()
        {
            Logger.Info(Env.CurrentPath);
        }
    }
}
