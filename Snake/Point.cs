using System;

namespace Snake
{
    public class Point
    {
        private int x;
        private int y;
        public char sym;

        public Point() { }

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }

        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    x = x - offset;
                    break;
                case Direction.Right:
                    x = x + offset;
                    break;
                case Direction.Up:
                    y = y - offset;
                    break;
                case Direction.Down:
                    y = y + offset;
                    break;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public override string ToString()
        {
            return $"{x}, {y}, {sym}";
        }

        public void Clear()
        {
            sym = ' ';
            this.Draw();
        }

        public bool IsHit(Point p)
        {
            return this.x == p.x && this.y == p.y;
        }
    }
}
