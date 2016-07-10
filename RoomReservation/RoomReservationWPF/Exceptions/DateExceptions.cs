namespace RoomReservationWPF.Exceptions
{
    using System;


    public class DateExceptions : ApplicationException
    {
        public DateExceptions(string message) : base(message)
        {
        }

        public DateExceptions(string message, int minDate) : this(message)
        {
            this.MinDate = minDate;
        }

        public DateExceptions(string message, int minDate, int maxDate) : this(message)
        {
            this.MinDate = minDate;
            this.MaxDate = maxDate;
        }

        public int MinDate { get; set; }
        public int MaxDate { get; set; }

    }
}
