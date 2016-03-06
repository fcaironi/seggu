﻿using System;

namespace Seggu.Service.ViewModels
{
    public class PolicyVM : ParseViewModel
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public int FeeAmount { get; set; }
        public string ClientName { get; set; }
        public string CompanyName { get; set; }
        public DateVM StartDate { get; set; }
        public DateVM EndDate { get; set; }
        public long ClientId { get; set; }
    }
}