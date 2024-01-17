namespace BotanicalDB.Models
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */

    /* Cookies and session data being used to store favorite plant data
     * which is accessed through the Favorites navlink and displays the
     * number of favorites on the default area Index page
     */

    public class PlantSession
    {
        private const string PlantsKey = "plants";

        private ISession session { get; set; }

        public PlantSession(ISession session)
        {
            this.session = session;
        }

        public List<Plant> GetPlants() => session.GetObject<List<Plant>>(PlantsKey) ?? new List<Plant>();

        public void SetPlants(List<Plant> plants) => session.SetObject(PlantsKey, plants);
    }
}
