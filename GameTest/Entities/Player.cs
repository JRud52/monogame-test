using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameTest
{
	public class Player : Sprite
	{
		int speed = 3;

		public Player (ContentManager content, string texture, 
					  Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2)) 
			: base(content, texture,  pos, rot, scale )
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
