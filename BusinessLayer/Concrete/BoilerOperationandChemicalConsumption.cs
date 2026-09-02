using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BoilerOperationandChemicalConsumption : GenericManager<DB_BoilerOperationandChemicalConsumption, BoilerOperationandChemicalConsumptionDto, CreateBoilerOperationandChemicalConsumptionDto, UpdateBoilerOperationandChemicalConsumptionDto>, IBoilerOperationandChemicalConsumptionService
    {
        private readonly IBoilerOperationandChemicalConsumptionRepository _boilerRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly IKazanEnergyConsumptionRepository _energyRepository;


        public BoilerOperationandChemicalConsumption(IUnitOfWork uow, IMapper mapper, IBoilerOperationandChemicalConsumptionRepository boilerRepository, IShiftRepository shiftRepository, IKazanEnergyConsumptionRepository energyRepository) : base(uow, mapper)
        {
            _boilerRepository = boilerRepository;
            _shiftRepository = shiftRepository;
            _energyRepository = energyRepository;
        }

        public async Task<List<EnergyConsumptionStatusDto>> GetActiveShiftEnergyStatus()
        {

            var now = DateTime.Now.TimeOfDay;
            var shifts = await _shiftRepository.TGetAll();
            var activeShift = shifts.FirstOrDefault(x =>
                x.ShiftStartHours <= x.ShiftEndHours
                    ? now >= x.ShiftStartHours && now < x.ShiftEndHours
                    : now >= x.ShiftStartHours || now < x.ShiftEndHours
            );

            if (activeShift == null)
                return new List<EnergyConsumptionStatusDto>();

            var energyList = await _energyRepository.GetWithDetails();
            var boilerList = await _boilerRepository.GetWithDetails();

            var activeEnergyList = energyList
                .ToList();

            var activeBoilerList = boilerList
                .Where(x => x.ShiftId == activeShift.RecId && x.ReceiptDate == DateTime.Now.Date)
                .ToList();

            var result = activeEnergyList.Select(energy => new EnergyConsumptionStatusDto
            {
                EnergyConsumptionId = energy.RecId,

                EnergyConsumptionPlace = energy.ConsumptionPlace,

                ShiftId = activeShift.RecId,

                ShiftName = activeShift.ShiftName,

                ReceiptDate = DateTime.Now,

                IsRecorded = activeBoilerList.Any(boiler =>
                    boiler.ConsumptionPlaceId == energy.RecId
                )

            }).ToList();


            return result;
        }

        public async Task<List<BoilerOperationandChemicalConsumptionDto>> GetWithDetails()
        {
            var data = await _boilerRepository.GetWithDetails();
            return _mapper.Map<List<BoilerOperationandChemicalConsumptionDto>>(data);
        }

        public async Task<List<BoilerOperationandChemicalConsumptionDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {
            var entities = await _boilerRepository.GetWithSearchDetails(StartDate, EndDate);
            var dtos = _mapper.Map<List<BoilerOperationandChemicalConsumptionDto>>(entities);
            return dtos;
        }
    }
}
