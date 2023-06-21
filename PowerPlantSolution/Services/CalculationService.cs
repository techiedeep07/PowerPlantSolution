using PowerPlantSolution.DataModels;

namespace PowerPlantSolution.Services
{
    public static class CalculationService
    {
        /// <summary>
        /// Calculate Cost and Actual Power of Plant
        /// </summary>
        /// <param name="powerPlantInputDetail"></param>
        /// <returns></returns>
        public static IEnumerable<PowerPlantDetail> CalculateCostAndActualPower(this PowerPlantInputDetail powerPlantInputDetail)
        {
            IList<PowerPlantDetail> powerPlantDetails = new List<PowerPlantDetail>();
            foreach (var plant in powerPlantInputDetail.PowerPlanDetails)
            {
                plant.PActual = GetActualPMax(plant, powerPlantInputDetail.FuelDetail);
                plant.FuelCost = GetFuelPrice(plant, powerPlantInputDetail.FuelDetail);
                powerPlantDetails.Add(plant);
            }
            return powerPlantDetails;
        }

        /// <summary>
        /// Calcuate Fuel Price for Power Plant
        /// </summary>
        /// <param name="powerPlantDetail"></param>
        /// <param name="fuelDetail"></param>
        /// <returns></returns>
        private static decimal GetFuelPrice(this PowerPlantDetail powerPlantDetail, FuelDetail fuelDetail)
        {
            decimal fuelCost = 0;
            if (powerPlantDetail != null)
            {
                switch (powerPlantDetail.PlantType)
                {
                    case PlantType.WindTurbine:
                        fuelCost = 0.0M;
                        break;
                    case PlantType.Gasfired:
                        fuelCost = fuelDetail.Gas / powerPlantDetail.Efficiency;
                        break;
                    case PlantType.TurboJet:
                        fuelCost = fuelDetail.Kerosine / powerPlantDetail.Efficiency;
                        break;
                }
            }
            return fuelCost;
        }

        /// <summary>
        /// Calcuate Actual Power for Power Plant
        /// </summary>
        /// <param name="powerPlantDetail"></param>
        /// <param name="fuelDetail"></param>
        /// <returns></returns>
        private static decimal GetActualPMax(this PowerPlantDetail powerPlantDetail, FuelDetail fuelDetail)
        {
            if (powerPlantDetail.PlantType != PlantType.WindTurbine)
                return powerPlantDetail.PMax;
            return powerPlantDetail.PMax / 100.0M * fuelDetail.Wind;
        }

        /// <summary>
        /// Order the Power Plant details with respect to there Efficiency and 
        /// </summary>
        /// <param name="powerPlantDetails"></param>
        /// <returns></returns>
        public static IEnumerable<PowerPlantDetail> OrderPowerPlantDetails(this IEnumerable<PowerPlantDetail> powerPlantDetails)
        {
            return powerPlantDetails.OrderByDescending(i => i.Efficiency).ThenBy(i => i.FuelCost);
        }
    }
}
