namespace RoomReservationWPF.Exceptions
{
    using System;


    public class DateExeptions : ApplicationException
    {
        public DateExeptions(string message) : base(message)
        {
        }

        public DateExeptions(string message, int minDate) : this(message)
        {
            this.MinDate = minDate;
        }

        public DateExeptions(string message, int minDate, int maxDate) : this(message)
        {
            this.MinDate = minDate;
            this.MaxDate = maxDate;
        }

        public int MinDate { get; set; }
        public int MaxDate { get; set; }

    }
}
