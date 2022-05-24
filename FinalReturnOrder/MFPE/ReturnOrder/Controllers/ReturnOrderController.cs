using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReturnOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ReturnOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnOrderController : ControllerBase
    {
        public static List<ProcessFinalResponse> processFinals = new List<ProcessFinalResponse>();
        public ReturnOrderController()
        {
        }

        [HttpPost]
        [Route("GetDetails")]
        public async Task<IActionResult> GetDetails(ProcessRequestDTO requestDTO)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://20.231.247.214");
                var token = HttpContext.Request.Cookies["Token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                StringContent content = new StringContent(JsonConvert.SerializeObject(requestDTO), Encoding.UTF8, "application/json");
                var myResponse = await client.PostAsync("api/ComponentProcessing/ProcessDetails", content);
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    ProcessResponseDTO processResponse = await myResponse.Content.ReadAsAsync<ProcessResponseDTO>();
                    ProcessFinalResponse processFinalResponse = new ProcessFinalResponse();
                    processFinalResponse.CreditCardNumber = requestDTO.CreditCardNumber;
                    processFinalResponse.Name = requestDTO.Name;
                    processFinalResponse.ComponentName = requestDTO.ComponentName;
                    processFinalResponse.Qunatity = requestDTO.Qunatity;
                    processFinalResponse.DateOfDelivery = processResponse.DateOfDelivery;
                    processFinalResponse.ProcessingCharge = processResponse.ProcessingCharge;
                    processFinalResponse.RequestId = processResponse.RequestId;
                    processFinalResponse.PackagingAndDeliveryCharge = processResponse.PackagingAndDeliveryCharge;
                    processFinals.Add(processFinalResponse);
                    return Ok(processFinalResponse);
                }
                return BadRequest("Something went wrong");

            }
            catch
            {
                ModelState.Clear();
                ModelState.AddModelError("Error", "Error in Sending the request");
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        [Route("CompleteProcessing")]
        public async Task<IActionResult> CompleteProcessing(int flag)
        {
            try
            {
                ProcessFinalResponse processFinal = new ProcessFinalResponse();
                ErrorDto err = new ErrorDto();
                processFinal = processFinals[0];
                if (flag == 0)
                {
                    processFinals.RemoveAt(0);
                    return Ok("Process Aborted");
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://20.231.247.214");
                var token = HttpContext.Request.Cookies["Token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                StringContent content = new StringContent(JsonConvert.SerializeObject(processFinal), Encoding.UTF8, "application/json");
                var myResponse = await client.PostAsync("api/ComponentProcessing/CompleteProcessing", content);
                processFinals.RemoveAt(0);
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = myResponse.Content.ReadAsStringAsync();
                    err.Id = "CompleteProcess";
                    err.Message = result.Result;
                    return Ok(err);
                }
                return BadRequest("Something went wrong");


            }
            catch(Exception ex)
            {
                ModelState.Clear();
                ModelState.AddModelError("Error" , ex.Message);
                return BadRequest(ModelState);
            }

        }

    }
}
