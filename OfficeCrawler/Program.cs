using System;

namespace OfficeCrawler {
    public static class Program {
        [STAThread]
        static void Main() {
            using (var game = new OfficeCrawler())
                game.Run();
        }
    }
}
