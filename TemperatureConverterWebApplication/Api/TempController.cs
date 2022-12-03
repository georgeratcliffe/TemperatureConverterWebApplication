using Microsoft.AspNetCore.Mvc;
using System.Text;


namespace TemperatureConverterWebApplication.Api
{
    [Route("home/api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        /// <summary>
        /// Returns series of Celsius/Fahrenheit values to be consumed by DataTable jQuery Javascript library
        /// </summary>
        [HttpGet]
        [Route("GetTableData")]
        public async Task<string> Get()
        {
            return await Task.Run(() => GenerateCtoF());
        }


        private string GenerateCtoF()
        {
            StringBuilder sb = new StringBuilder("{\"data\": [");

            for (int x = 0; x <= 100; x++)
            {
                decimal far = (Decimal.Divide(9, 5) * x) + 32;
                string row = $"[{x},{far}],";
                sb.Append(row);
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append("]}");

            return sb.ToString();
        }
    }
}
