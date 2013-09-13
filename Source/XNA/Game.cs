using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Claret
{
	public class GameArgs
    {
		public bool SkipSplash { get; set; }
    }

	public class Game
	{
		private GraphicsDevice m_Device;
		private GraphicsAdapter m_Adapter;
		private bool m_Quit;
		private Color			m_ClearColour;

		public Game( )
		{
			PresentationParameters Presentation =
				new PresentationParameters( );
			m_Adapter = GraphicsAdapter.DefaultAdapter;

			Presentation.MultiSampleCount = 4;
			Presentation.BackBufferWidth = m_Adapter.CurrentDisplayMode.Width;
			Presentation.BackBufferHeight =
				m_Adapter.CurrentDisplayMode.Height;
			Presentation.BackBufferFormat = SurfaceFormat.Color;
#if DEBUG
			System.Diagnostics.Debug.WriteLine( "" );
			System.Diagnostics.Debug.WriteLine(
                "----------------------------" );
			System.Diagnostics.Debug.WriteLine(
                "Graphics Adapter Information" );
			System.Diagnostics.Debug.WriteLine(
                "----------------------------" );
            System.Diagnostics.Debug.WriteLine( "\tName: " +
				m_Adapter.DeviceName );
			System.Diagnostics.Debug.WriteLine( "\tID: " +
				m_Adapter.DeviceId );
			System.Diagnostics.Debug.WriteLine( "\tSub-System ID: " +
				m_Adapter.SubSystemId );
			System.Diagnostics.Debug.WriteLine( "\tVendor: " +
				m_Adapter.VendorId );
			System.Diagnostics.Debug.WriteLine( "\tDescription: " +
                m_Adapter.Description.ToString( ) );
			System.Diagnostics.Debug.WriteLine( "\tSupported Resolutions: " );
			foreach( DisplayMode Mode in m_Adapter.SupportedDisplayModes )
            {
				System.Diagnostics.Debug.WriteLine( "\t\t" +
					Mode.Width + "x" + Mode.Height );
            }
			System.Diagnostics.Debug.WriteLine( "\tCurrent Resolution: " +
				m_Adapter.CurrentDisplayMode.Width.ToString( ) + "x" +
                m_Adapter.CurrentDisplayMode.Height.ToString( ) );
#endif

			m_Device = new GraphicsDevice( m_Adapter, GraphicsProfile.HiDef,
				Presentation );
		}

		public int Initialise( GameArgs p_Args )
		{
			m_Quit = false;
			m_ClearColour = new Color( 0.25f, 0.0f, 0.0f );
#if DEBUG
			System.Diagnostics.Debug.WriteLine( "" );
			System.Diagnostics.Debug.WriteLine( "--------------" );
			System.Diagnostics.Debug.WriteLine( "Game Arguments" );
			System.Diagnostics.Debug.WriteLine( "--------------" );

			if( p_Args.SkipSplash )
            {
				System.Diagnostics.Debug.WriteLine(
					"\t* Disabling splash screen" );
			}
			else
            {
				System.Diagnostics.Debug.WriteLine( "\t* Enabling splash screen" );
            }
			System.Diagnostics.Debug.WriteLine( "" );
#endif
			return 1;
		}

		private void Update( )
		{
		}

		private void Render( )
		{
			m_Device.Clear( m_ClearColour );
			m_Device.Present( );
		}

		public void Execute( )
		{
			while( !m_Quit )
			{
				this.Update( );
				this.Render( );
			}
		}
	}
}
