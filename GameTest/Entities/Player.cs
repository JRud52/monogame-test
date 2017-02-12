using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameTest
{
	public class Player : Sprite
	{
		int speed = 10;

		public Player (ContentManager content, SpriteBatch batch, string texture, 
					  Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2)) 
			: base(content, batch, texture,  pos, rot, scale)
		{
			
		}
	}
}
