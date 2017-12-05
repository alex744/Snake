using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Walls
    {
        private List<Figure> walList;

        public Walls(int mapWidth, int mapHeight)
        {
            walList = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            walList.Add(upLine);
            walList.Add(downLine);
            walList.Add(leftLine);
            walList.Add(rightLine);
        }

        public bool IsHit(Figure figure)
        {
            foreach (var wall in walList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            foreach (var wall in walList)
            {
                wall.Draw();
            }
        }
    }
}
