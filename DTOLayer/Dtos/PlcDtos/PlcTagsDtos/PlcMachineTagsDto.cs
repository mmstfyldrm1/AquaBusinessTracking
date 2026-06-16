namespace DTOLayer.Dtos.PlcDtos.PlcTagsDtos
{
    public class PlcMachineTagsDto
    {
        public int RecId { get; set; }
        public string TagName { get; set; } = ""; // "Paper_Uretim_Ton"
        public string DisplayName { get; set; } = ""; // "Üretim (ton)"
        public string Unit { get; set; } = ""; // "ton", "kW", "saat"
        public string Group { get; set; } = ""; // "PaperOnReel", "Power"
        public string DataAddress { get; set; } = ""; // "DB1.DBD0"
        public string DataType { get; set; } = ""; // "Real", "Word", "Bit"
        public bool IsActive { get; set; } = true;

        // hangi makineye ait
        public int MachineId { get; set; }

        public string? MachineName { get; set; }

    }
}
