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

    public class PlantCookies
    {
        private const string PlantsKey = "myplants";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; } = null!;
        private IResponseCookies responseCookies { get; set; } = null!;

        public PlantCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }

        public PlantCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyPlantIds(List<Plant> plants)
        {
            List<string> ids = plants.Select(p => p.PlantId.ToString()).ToList();
            string idsString = string.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyPlantIds();     // delete old cookie first
            responseCookies.Append(PlantsKey, idsString, options);
        }

        public string[] GetMyPlantIds()
        {
            string cookie = requestCookies[PlantsKey] ?? String.Empty;
            if (string.IsNullOrEmpty(cookie))
                return Array.Empty<string>();   // empty string array
            else
                return cookie.Split(Delimiter);
        }

        public void RemoveMyPlantIds()
        {
            responseCookies.Delete(PlantsKey);
        }
    }
}
