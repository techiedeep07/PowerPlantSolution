namespace PowerPlantSolution.DataModels
{
    public class PowerPlantDetail
    {
        public string Name { get; set; }

        public PlantType PlantType { get; set; }

        public decimal Efficiency { get; set; }

        public decimal PMin { get; set; }

        public decimal PMax { get; set; }

        public decimal FuelCost { get; set; }

        public decimal PActual { get; set; }
    }
}
