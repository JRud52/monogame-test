using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameTest
{
	public class Hud
	{
		SpriteBatch batch;
		SpriteFont font;
		GraphicsDeviceManager graphics;

		public Hud(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch batch)
		{
			this.batch = batch;
			this.graphics = graphics;
			font = content.Load<SpriteFont>("fonts/hud_font");
		}

		public void Draw()
		{
			batch.DrawString(font, "Hello World", new Vector2(graphics.GraphicsDevice.Viewport.Width - 110, 10),
			                 Color.Black, 0, default(Vector2), 1, SpriteEffects.None, 1.0f);
		}
			
	}
}
