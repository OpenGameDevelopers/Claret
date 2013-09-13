namespace Claret
{
	public class RenderableEntity : GameEntity
	{
		public RenderableEntity( ref string p_Name ) :
            base( ref p_Name )
        {
        }

		public virtual void Render( )
        {
        }
	}
}