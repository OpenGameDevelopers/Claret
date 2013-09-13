using Microsoft.Xna.Framework;
namespace Claret
{
	public class GameEntity
    {
		public GameEntity( ref string p_Name )
		{
			// Hash the string to create the entity's ID
		}

		public virtual int Initialise( )
        {
			return 1;
        }

		public virtual void Update( ulong p_TimeStep )
        {
        }

		public Vector3 Position
        {
			get
            {
				return m_Position;
            }
			set
            {
				m_Position = value;
            }
        }

		private int m_ID;
		private Vector3 m_Position;
    }
}
