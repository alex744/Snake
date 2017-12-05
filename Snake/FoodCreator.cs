using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodCreator
    {
        private char sym;
        private int mapWidht;
        private int mapHeight;
        private Random random;

        public FoodCreator(int mapWidht, int mapHeight, char sym)
        {
            this.sym = sym;
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeight;
            this.random = new Random();
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(2, mapHeight - 2);

            return new Point(x, y, sym);
        }
    }
}
