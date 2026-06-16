namespace DTOLayer.Dtos.PlcDtos.PlcMachineDtos
{
    public class PlcMachineDto
    {
        public int RecId { get; set; }
        public string Name { get; set; } = ""; // "Kağıt Makinesi 1"
        public string IpAddress { get; set; } = "";
        public int Rack { get; set; }
        public int Slot { get; set; }
        public string CpuType { get; set; } = ""; // "S71200", "S71500"
        public bool IsActive { get; set; } = true;




    }
}
