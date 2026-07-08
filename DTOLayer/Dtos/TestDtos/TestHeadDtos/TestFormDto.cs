namespace DTOLayer.Dtos.TestDtos.TestHeadDtos
{
    public class TestFormDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public string TestDepartmentName { get; set; }

        public int AppUserId { get; set; }

        public int DepartmentId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int ShiftId { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public TestDetailFormDto Detail { get; set; } = new();
    }

    public class TestDetailFormDto
    {
        public int RecId { get; set; }
        public decimal? InletFlowRate { get; set; } // m³/h
        public decimal? InletDryMatterPercent { get; set; } // % DM
        public decimal? PolyelectrolyteConcentration { get; set; } // %
        public decimal? PolyelectrolyteFlowRate { get; set; } // m³/h
        public int? BowlSpeed { get; set; } // rpm
        public int? ActualTorque { get; set; } // %
        public int? ActualDifferentialSpeed { get; set; }
        public int? CentrateWeirLevel { get; set; } // mm
        public decimal? CakeDryMatterPercent { get; set; } // % DM
        public int? CentrateTSS { get; set; } // mg/lt
        public decimal? PolyelectrolyteConsumption { get; set; } // kg/ton DM
        public int? BowlTorque { get; set; } // %
        public int? Vibration { get; set; } // mm/sn
        public int? EnergyConsumption { get; set; } // kW/h
        public decimal? EnergyConsumptionPerFeed { get; set; } // kW/m³
        public int TestHeaderId { get; set; }
        public Int16? InUse { get; set; }
        public int? DeletedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
