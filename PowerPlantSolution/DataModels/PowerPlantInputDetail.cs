namespace PowerPlantSolution.DataModels
{
    public class PowerPlantInputDetail
    {
        public decimal Load { get; set; }

        public FuelDetail FuelDetail { get; set; }

        public IEnumerable<PowerPlantDetail> PowerPlanDetails { get; set; }
    }
}
