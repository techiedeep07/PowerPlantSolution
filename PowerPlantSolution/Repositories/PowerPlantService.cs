using PowerPlantSolution.DataModels;

namespace PowerPlantSolution.Repositories
{
    public class PowerPlantService : IPowerPlantService
    {
        public IEnumerable<PowerPlantOutput> GetPowerProducePlan(PowerPlantInputDetail powerPlantInputDetail)
        {
            List<PowerPlantOutput> powerPlantOutputs = new List<PowerPlantOutput>();
            // to-do
            return powerPlantOutputs;
        }
    }
}
