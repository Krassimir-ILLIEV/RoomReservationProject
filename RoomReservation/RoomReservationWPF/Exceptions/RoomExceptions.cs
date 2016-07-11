namespace RoomReservationWPF.Exceptions
{
    using System;

    public class RoomExceptions : ApplicationException
    {
        // Constructors
        public RoomExceptions(string message) : base(message)
        {
        }

        // Properties
        public int Capacity { get; private set; }
    }
}
