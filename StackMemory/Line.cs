using System;

namespace MDFT.StackMemory
{
	public class Line
	{
		public int X1 = 0;
		public int X2 = 0;
		public int Y1 = 0;
		public int Y2 = 0;

		public Line(int x1, int y1, int x2, int y2)
		{
			this.X1 = x1;
			this.Y1 = y1;
			this.X2 = x2;
			this.Y2 = y2;
		}
	}
}
