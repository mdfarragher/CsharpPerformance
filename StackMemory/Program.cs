using System;

namespace MDFT.StackMemory
{
	public class MainClass
	{
		private static void DrawPolygon(Line[] lines)
		{
			// Put breakpoint below this line
		}

		private static void DrawSquare(int x, int y, int w, int h)
		{
			int xw = x + w;
			int yh = y + h;

			Line[] lines = new Line[4];
			lines [0] = new Line (x, y, xw, y);
			lines [1] = new Line (xw, y, xw, yh);
			lines [2] = new Line (xw, yh, x, yh);
			lines [3] = new Line (x, yh, x, y);

			DrawPolygon (lines);
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Going to draw a square...");
			DrawSquare (100, 100, 50, 50);
			Console.WriteLine ("All done!");
		}
	}
}