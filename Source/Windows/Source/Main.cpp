#include <windows.h>

INT WINAPI WinMain( HINSTANCE p_ThisInst, HINSTANCE p_PrevInstance,
	LPSTR p_CmdLine, INT p_CmdShow )
{
	::MessageBox( NULL, TEXT( "Working" ), TEXT( "Project Claret" ), MB_OK );
	return 0;
}

