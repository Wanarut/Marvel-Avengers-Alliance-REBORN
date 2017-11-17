using Marvel_Avengers_Alliance_REBORN.States;
using System;

namespace Marvel_Avengers_Alliance_REBORN
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var MainGame = new MAAGame();
            using (var games = new BattleState())
                games.Run();
        }
    }
}
