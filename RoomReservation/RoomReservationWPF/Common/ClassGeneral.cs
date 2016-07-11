using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RoomReservationWPF.Common
{
    public class ClassGeneral
    {
        public static T GetEnumByName<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
    }
}
