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
			for (int i = 0; i < ground_sprites.Count; i++)
			{
				batch.Draw(collision_sprites[i].texture,
					   origin: new Vector2(collision_sprites[i].texture.Width / 2, collision_sprites[i].texture.Height / 2),
					   position: pos,
					   rotation: collision_sprites[i].rot,
					   scale: collision_sprites[i].scale,
					   layerDepth: collision_sprites[i].layer
					  );
			}
			for (int i = 0; i < collision_sprites.Count; i++)
			{
				batch.Draw(collision_sprites[i].texture,
					   origin: new Vector2(collision_sprites[i].texture.Width / 2, collision_sprites[i].texture.Height / 2),
					   position: pos,
					   rotation: collision_sprites[i].rot,
					   scale: collision_sprites[i].scale,
					   layerDepth: collision_sprites[i].layer
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
