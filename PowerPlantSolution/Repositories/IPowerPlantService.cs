using PowerPlantSolution.DataModels;

namespace PowerPlantSolution.Repositories
{
    public interface IPowerPlantService
    {
        public IEnumerable<PowerPlantOutput> GetPowerProducePlan(PowerPlantInputDetail powerPlantInputDetail);
    }
}
