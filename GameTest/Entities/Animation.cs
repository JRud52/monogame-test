using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameTest
{
	public class Animation
	{
		readonly List<Rectangle> frames;
		int currentFrame;
		double timeIntoFrame;
		public int duration { get; set; }
		bool isPlaying;

		/// <summary>
		/// Spritesheets must be laid out so that an animation is on a single row. 
		/// Multiple animations can be on a single row, but an animation cannot be
		/// split up across rows. 
		/// ----------------------------------------------------------------------
		/// FIX THIS LATER TO MAKE IT MORE GENERIC
		/// </summary>
		/// <param name="start">Start.</param>
		/// <param name="size">Size.</param>
		/// <param name="numFrames">Number frames.</param>
		/// <param name="duration">Duration.</param>
		public Animation(Vector2 start, Vector2 size, int numFrames, int duration)
		{
			frames = new List<Rectangle>();

			for (int i = 0; i < numFrames; i++)
			{
				frames.Add(new Rectangle((int)start.X + i * (int)size.X, (int)start.Y, (int)size.X, (int)size.Y));
			}

			this.duration = duration;
			currentFrame = 0;
			timeIntoFrame = 0;
			isPlaying = false;
		}

		public void Play()
		{
			isPlaying = true;
		}

		public void Stop()
		{
			isPlaying = false;
		}

		public void Reset()
		{
			currentFrame = 0;
		}

		public Rectangle Update(GameTime gameTime)
		{
			if (isPlaying)
			{
				timeIntoFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
				if (timeIntoFrame >= duration)
				{
					currentFrame++;
					timeIntoFrame = 0;
				}

				if (currentFrame >= frames.Count)
				{
					currentFrame = 0;
					timeIntoFrame = 0;
				}

			}
			else {
				timeIntoFrame = 0;
				currentFrame = 0;
			}
			return frames[currentFrame];
		}
	}
}
