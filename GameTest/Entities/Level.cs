using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameTest
{
	public class Level
	{
		Sprite[] sprites;
		Vector2 pos;
		int speed = 10;

		public Level()
		{
			sprites[0] = new Sprite(Content, spriteBatch, "sprites/house",
							   new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2));
			sprites[0].layer = 0.3f;
		}

		public void Draw()
		{

		}

		public void updatePos()
		{

			if (Keyboard.GetState().IsKeyDown(Keys.A))
				pos.X -= speed;
			if (Keyboard.GetState().IsKeyDown(Keys.D))
				pos.X += speed;
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				pos.Y -= speed;
			if (Keyboard.GetState().IsKeyDown(Keys.S))
				pos.Y += speed;
		}
	}
}
