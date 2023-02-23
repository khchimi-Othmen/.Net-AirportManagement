﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing,Airbus}
    public class Plane
    {
        //ctor + 2 tab
        public Plane()
        {

        }
        public Plane(int capacity, DateTime manufactureDate, int planeId, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneId = planeId;
            PlaneType = planeType;
        }

        //ctor + 2tab


        //prop + 2tab
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        //prop de navig
        public virtual IList<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "Capacity = "+ Capacity + " , ManufactureDate = "+ ManufactureDate+
                " , PlaneId = "+ PlaneId + " , PlaneType = "+ PlaneType;
        }
    }
}
