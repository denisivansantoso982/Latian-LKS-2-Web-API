//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Latian_LKS_2_Web_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReservationRoom
    {
        public int ID { get; set; }
        public int ReservationID { get; set; }
        public int RoomID { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public int DurationNights { get; set; }
        public int RoomPrice { get; set; }
        public System.DateTime CheckInDateTime { get; set; }
        public System.DateTime CheckOutDateTime { get; set; }
    
        public virtual Reservation Reservation { get; set; }
        public virtual Room Room { get; set; }
    }
}
