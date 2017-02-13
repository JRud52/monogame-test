using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameTest
{
	public class Player : Sprite
	{
		public int health { get; set; }
		public int walk_speed { get; set; }
		public int run_speed { get; set; }

		public Player (ContentManager content, SpriteBatch batch, string texture, 
					  Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2)) 
			: base(content, batch, texture,  pos, rot, scale)
		{
			health = 100;
			walk_speed = 3;
			run_speed = 5;
		}
	}
}
