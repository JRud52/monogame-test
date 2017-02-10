using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
	public class Player : Sprite
	{
		public Player (Texture2D texture, 
					  Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2)) 
			: base( graphics, texture,  pos, rot, scale )
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

			if (pos.X > graphics.Viewport.Width - size.X)
				pos.X = graphics.Viewport.Width - size.X;
			if (pos.X < 0)
				pos.X = 0;
			if (pos.Y > graphics.Viewport.Height - size.Y)
				pos.Y = graphics.Viewport.Height - size.Y;
			if (pos.Y < 0)
				pos.Y = 0;
		}
	}
}
