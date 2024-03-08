using Employees.Models;
using Newtonsoft.Json;

namespace Employees.Services;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EmployeeViewModel>> GetEmployees()
    {
        try
        {
            var response = await _httpClient.GetStringAsync(
                "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==");
            return JsonConvert.DeserializeObject<List<EmployeeViewModel>>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}