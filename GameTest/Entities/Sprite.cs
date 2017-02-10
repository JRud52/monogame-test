using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
	public class Sprite
	{
		public Texture2D texture;
		public Vector2 pos;
		public float rot;
		public Vector2 scale;
		//public Vector2 size;
		//int speed = 5;
		GraphicsDevice graphics;

		/*
		public Sprite(GraphicsDevice graphics, Vector2 size, Color color, 
		              Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2))
		{
			if (scale == default(Vector2))
			{
				scale = new Vector2(1, 1);
			}
			this.size = size;
			this.pos = pos;
			this.rot = rot;
			this.scale = scale;
			this.graphics = graphics;

			int area = (int)(size.X * size.Y);

			Color[] colorData = new Color[area];
			for (int i = 0; i < area; i++)
				colorData[i] = color;

			texture = new Texture2D(graphics, (int)(size.X), (int)(size.Y));
			texture.SetData(colorData);
		}
		*/

		public Sprite(String textureFile, 
		              Vector2 pos = default(Vector2), float rot = 0.0f, Vector2 scale = default(Vector2))
		{
			texture = Content.Load<Texture2D>(textureFile);

			this.pos = pos;
			this.rot = rot;
			this.scale = scale;
		}


	}
}
