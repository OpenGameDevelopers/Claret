using System;

namespace Claret
{
    static class ClaretMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main( string[ ] p_Args )
        {
			Game TheGame = new Game( );
			GameArgs Args = new GameArgs( );
			Args.SkipSplash = false;
#if DEBUG
			for( int i = 0; i < p_Args.Length; ++i )
            {
				if( p_Args[ i ].ToLower( ) == "skipsplash" )
                {
					Args.SkipSplash = true;
                }
            }
#endif

			if( TheGame.Initialise( Args ) == 0 )
            {
				return;
            }

			TheGame.Execute( );
        }
    }
}
