namespace AcademiaNG.Helper
{
    public class RestServiceBase
    {

        public async Task<List<>> GetOrganizationsAsync(string uri)
        {
            List<Organization> organizations = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    organizations = JsonConvert.DeserializeObject<List<Organization>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return organizations;
        }
    }
}