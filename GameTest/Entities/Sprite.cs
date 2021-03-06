﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameTest
{
	/// <summary>
	/// Basic static sprite implementation. No animation. 
	/// </summary>
	/// <remarks>
	/// TODO: add collision logic.
	/// </remarks>
	 
	// TODO add collision logic.

	public class Sprite
	{
		public Texture2D texture { get; set; }
		public Vector2 pos { get; set; }
		public float rot { get; set; }
		public Vector2 scale { get; set; }
		public float layer { get; set; }
		//public bool collidable { get; set; }

		readonly SpriteBatch batch;

		public Sprite(ContentManager content, SpriteBatch batch, string textureFile, 
		              Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2))
		{
			texture = content.Load<Texture2D>(textureFile);

			if (scale == default(Vector2))
			{
				scale = new Vector2(1, 1);
			}

			this.batch = batch;

			this.pos = pos;
			this.rot = rot;
			this.scale = scale;
		}

		public void Draw()
		{
			batch.Draw(texture,
					   origin: new Vector2(texture.Width / 2, texture.Height / 2),
					   position: pos,
					   rotation: rot,
					   scale: scale,
					   layerDepth: layer
			          );
		}
	}
}
