﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Coach : Member
    { 
        public CoachType Type { get; set; }
        public Guid CoachTypeId { get; set; }
    }
}
