using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trajectory_console
{
	/// <summary>
	/// Physics simulator for object trajectory.
	/// </summary>
	class Program
	{
		/// <summary>
		/// Effect of gravity in m/s
		/// </summary>
		public const float gravity = 9.8f;

		/// <summary>
		/// Main entry point for the application.
		/// </summary>
		/// <param name="args">command line arguments.</param>
		static void Main(string[] args)
		{
			//Welcome message
			Console.WriteLine("Welcome to the physics simulator for object trajectory.");
			Console.WriteLine(
				"This will calculate the" +
				"maximum height of the shell and " +
				"the distance it will travel");

			//Prompt for input
			Console.Write("Initial angle in degrees: ");
			float theta = AngleHelper.ToRadians(float.Parse(Console.ReadLine()));

			Console.Write("Initial speed: ");
			var speed = float.Parse(Console.ReadLine());
			float vox = speed * (float)Math.Cos(theta);
			float voy = speed * (float)Math.Sin(theta);

			//Calculate variables

			//Time to apex
			float time = voy / gravity;

			//Height at apex
			float height = (float)Math.Pow(voy, 2) / (2 * gravity);

			//distance horizontally, assuming elevations are equal
			float distance = vox * 2 * time;

			//print values
			Console.WriteLine("\nHeight at apex: " + height);
			Console.WriteLine("Distance travelled: " + distance);

			Console.ReadKey(true);
		}
	}

	/// <summary>
	/// Helps with angle conversions
	/// </summary>
	public static class AngleHelper
	{
		/// <summary>
		/// Converts the passed in value to radians.
		/// </summary>
		/// <param name="val">angle in degrees.</param>
		/// <returns>angle in radians</returns>
		public static float ToRadians(this float val)
		{
			return (float)(Math.PI / 180) * val;
		}
	}
}
