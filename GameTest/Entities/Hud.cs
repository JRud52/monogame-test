using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameTest
{
	public class Hud
	{
		readonly SpriteBatch batch;
		readonly SpriteFont font;
		readonly GraphicsDeviceManager graphics;
		readonly Player player;

		public Hud(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch batch, Player player)
		{
			this.batch = batch;
			this.graphics = graphics;
			this.player = player;
			font = content.Load<SpriteFont>("fonts/hud_font");
		}

		public void Draw()
		{
			batch.DrawString(font, "Health: " + player.health, new Vector2(graphics.GraphicsDevice.Viewport.Width - 110, 10),
			                 Color.Black, 0, default(Vector2), 1, SpriteEffects.None, 1.0f);
		}
			
	}
}
