using DTOLayer.Dtos.PlcDtos.PlcMachineDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AquaBusinessTrackingWebUI.Models
{
    public class PlcMachineTagEditViewModel
    {
        public PlcMachineDto Entity { get; set; }

        public List<SelectListItem> Machines { get; set; } = new();
    }
}
