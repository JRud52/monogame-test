using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace GameTest
{
	public class AnimSprite
	{
		public Texture2D texture { get; set; }
		public Vector2 pos { get; set; }
		public float rot { get; set; }
		public Vector2 scale { get; set; }
		public float layer { get; set; }
		public Vector2 frameSize;
		//public bool collidable { get; set; }

		public List<Animation> animList;
		public int currentAnim { get; set; }

		readonly SpriteBatch batch;

		public AnimSprite(ContentManager content, SpriteBatch batch, string textureFile, Vector2 frameSize,
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
			this.frameSize = frameSize;
			currentAnim = 0;

			animList = new List<Animation>();
		}

		public void Draw(GameTime gameTime)
		{
			
			batch.Draw(texture,
			           sourceRectangle: animList[currentAnim].Update(gameTime),
					   origin: new Vector2(frameSize.X/2, frameSize.Y/2),
					   position: pos,
					   rotation: rot,
					   scale: scale,
					   layerDepth: layer
					  );
		}
	}
}
