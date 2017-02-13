using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace GameTest
{
	public class LevelManager
	{
		readonly SpriteBatch batch;
		readonly GraphicsDeviceManager graphics;

		List<Sprite> ground_sprites;
		List<Sprite> collision_sprites;
		List<Sprite> foreground_sprites;

		readonly Player player;

		Vector2 pos;
		int speed;

		public LevelManager(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch batch, Player player)
		{
			this.batch = batch;
			this.graphics = graphics;
			this.player = player;

			ground_sprites = new List<Sprite>();
			collision_sprites = new List<Sprite>();
			foreground_sprites = new List<Sprite>();

			var house = new Sprite(content, batch, "sprites/house",
									  new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2));
			house.layer = 0.3f;
			collision_sprites.Add(house);
		}

		public void Draw()
		{
			foreach (var sprite in ground_sprites)
			{
				batch.Draw(sprite.texture,
					   origin: new Vector2(sprite.texture.Width / 2, sprite.texture.Height / 2),
					   position: pos,
					   rotation: sprite.rot,
					   scale: sprite.scale,
					   layerDepth: sprite.layer
					  );
			}
			foreach (var sprite in collision_sprites)
			{
				batch.Draw(sprite.texture,
					   origin: new Vector2(sprite.texture.Width / 2, sprite.texture.Height / 2),
					   position: pos,
					   rotation: sprite.rot,
					   scale: sprite.scale,
					   layerDepth: sprite.layer
					  );
			}


		}

		public void updatePos()
		{
			KeyboardState state = Keyboard.GetState();

			if (state.IsKeyDown(Keys.LeftShift) || state.IsKeyDown(Keys.RightShift))
				speed = player.run_speed;
			else 
				speed = player.walk_speed;
			if (state.IsKeyDown(Keys.A))
				pos.X += speed;
			if (state.IsKeyDown(Keys.D))
				pos.X -= speed;
			if (state.IsKeyDown(Keys.W))
				pos.Y += speed;
			if (state.IsKeyDown(Keys.S))
				pos.Y -= speed;
		}
	}
}
