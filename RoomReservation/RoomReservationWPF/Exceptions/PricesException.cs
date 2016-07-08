namespace RoomReservationWPF.Exceptions
{
    using System;

    public class PricesException : ApplicationException
    {
        //Fields

        //Constructors
        public PricesException(string message, int price) : base(message)
            {
            this.Price = price;
            }
        //Properties
        public int Price
        {
            get;
            private set;
        }
    }
}
