using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

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
		readonly double m_MicrosecondsTick = 1000000D/Stopwatch.Frequency;

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
			Presentation.DepthStencilFormat = DepthFormat.Depth24Stencil8;
			Presentation.RenderTargetUsage = RenderTargetUsage.DiscardContents;
#if DEBUG
			Presentation.PresentationInterval = PresentInterval.Immediate;
#endif

            #region Debug Information
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
					Mode.Width + "x" + Mode.Height + "\t[TS] " +
                    Mode.TitleSafeArea.X + "," + Mode.TitleSafeArea.Y + " " +
                    Mode.TitleSafeArea.Width + "x" +
                    Mode.TitleSafeArea.Height );
            }
			System.Diagnostics.Debug.WriteLine( "\tCurrent Resolution: " +
				m_Adapter.CurrentDisplayMode.Width + "x" +
                m_Adapter.CurrentDisplayMode.Height + " [TS] " +
                m_Adapter.CurrentDisplayMode.TitleSafeArea.X + "," +
                m_Adapter.CurrentDisplayMode.TitleSafeArea.Y + " " +
                m_Adapter.CurrentDisplayMode.TitleSafeArea.Width + "x" +
                m_Adapter.CurrentDisplayMode.TitleSafeArea.Height );
#endif
            #endregion

            m_Device = new GraphicsDevice( m_Adapter, GraphicsProfile.HiDef,
				Presentation );
		}

		public int Initialise( GameArgs p_Args )
		{
			m_Quit = false;
			m_ClearColour = new Color( 0.25f, 0.0f, 0.0f );

            #region Debug Information
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
			#endregion

            return 1;
		}

		private void Update( ulong p_ElapsedTime )
		{
		}

		private void Render( )
		{
			m_Device.Clear( m_ClearColour );
			m_Device.Present( );
		}

		public void Execute( )
		{
			Stopwatch Timer = new Stopwatch( );
			Timer.Start( );
			ulong OldTime =
                ( ulong )( Timer.ElapsedTicks * m_MicrosecondsTick );
			ulong ElapsedTime = 0;
			ulong Accumulator = 0;
			ulong TimeStep = 16667;
#if DEBUG
			ulong FrameTime = OldTime;
			ulong FrameRate = 0;
#endif
			
			while( !m_Quit )
			{
				ulong NewTime =
                    ( ulong )( Timer.ElapsedTicks * m_MicrosecondsTick );
				ulong DeltaTime = NewTime - OldTime;

				if( DeltaTime > 250000 )
                {
					DeltaTime = 250000;
                }

				OldTime = NewTime;

				Accumulator += DeltaTime;

				while( Accumulator >= TimeStep )
                {
					this.Update( TimeStep );
					ElapsedTime += TimeStep;
					Accumulator -= TimeStep;
                }
				this.Render( );
#if DEBUG
				++FrameRate;

				if( ( NewTime - FrameTime ) > 1000000 )
                {
					Debug.WriteLine( "Frames per second: " + FrameRate );
					FrameTime = NewTime;
					FrameRate = 0;
                }
#endif
			}
		}
	}
}
