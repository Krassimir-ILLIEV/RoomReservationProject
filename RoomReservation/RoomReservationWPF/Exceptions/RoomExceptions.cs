namespace RoomReservationWPF.Exceptions
{
    using System;

    public class RoomExceptions : ApplicationException
    {
        // Constructors
        public RoomExceptions(string message) : base(message)
        {

        }
        public RoomExceptions(string message, int capacity) : this(message)
        {
            this.Capacity = capacity;
        }
        // Properties
        public int Capacity { get; private set; }

    }
}
