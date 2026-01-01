using Mehr.Application.ApiValidate.Contracts;
using Mehr.Application.ApiValidate.Contracts.Dtos;
using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Mehr.Application.ApiValidate;

public class ApiValidateService : IApiValidateService
{

    public async Task<Result<bool>> IsValidate(UserLoginDto loginDto, CancellationToken cancellationToken)
    {
        var dto = new ValidateApiDto
        {
            userId = "c5e10967-6113-4594-99e3-5982edc321de",
            userName = 7713785,
            apiKey = "c0d0cd85-f64e-4fcd-8625-c8c37c5bdd85",
            mehrUserName = loginDto.Username,
            mehrPassword = loginDto.Password,
        };

        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://mehraccounting.com/");
                var response = client.PostAsJsonAsync<ValidateApiDto>($"webApi/CheckValidate/", dto).Result;
                var res = JsonConvert.DeserializeObject<ApiValidateResult>(await response.Content.ReadAsStringAsync());
                if (res.IsSuccess)
                {

                    return true;
                }
            }
            return true;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}

public class ApiValidateResult
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ReturnComment { get; set; }
    public object? ReturnObject { get; set; }
    public int? LogId { get; set; }
}