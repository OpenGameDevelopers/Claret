#ifndef ___MAINMENUSTATE_HPP__
#define ___MAINMENUSTATE_HPP__

#include <System/DataTypes.hpp>
#include <Game/GameState.hpp>

namespace Claret
{
	class MainMenuState : public ZED::Game::GameState
	{
	public:
		MainMenuState( );
		virtual ~MainMenuState( );

		virtual ZED_UINT32 Enter( );
		virtual void Update( const ZED_UINT64 p_DeltaTime );
		virtual void Render( );
		virtual ZED_UINT32 Exit( );

		virtual ZED_CHAR8 *GetName( ) const;
	private:
	};
}


#endif // ___MAINMENUSTATE_HPP__

