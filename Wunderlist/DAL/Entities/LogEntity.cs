﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class LogEntity : IEntity
    {
        public int ID { get; set; }
        public string Log { get; set; }
    }
}
