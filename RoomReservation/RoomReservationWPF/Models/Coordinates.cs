namespace RoomReservation.Models
{
    public struct Coordinates
    {
        private int x;
        private int y;
        //private static readonly int[] O = { 0, 0 };

        public Coordinates(int xCoordinage, int yCoordinate)
            : this()
        {
            this.X = xCoordinage;
            this.Y = yCoordinate;
        }

        public int X
        {
            get { return this.x; }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            set
            {

                this.y = value;
            }
        }
    }
}