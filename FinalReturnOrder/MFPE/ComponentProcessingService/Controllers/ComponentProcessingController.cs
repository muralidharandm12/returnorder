using ComponentProcessingService.Models;
using ComponentProcessingService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ComponentProcessingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ComponentProcessingController : ControllerBase
    {
        private readonly IProcessingRepository _repo;
        public ComponentProcessingController(IProcessingRepository repository)
        {
            _repo = repository;
        }       

        [HttpPost("ProcessDetails")]
        public ActionResult<ProcessResponse> ProcessDetails(ProcessRequest processRequest)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress =new Uri("http://20.232.58.187");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = client.GetAsync("api/PackagingAndDelivery?item=" + processRequest.ComponentType + "&count=" + processRequest.Qunatity).Result;
                if (response.IsSuccessStatusCode)
                {
                    double cost = response.Content.ReadAsAsync<double>().Result;
                    ProcessResponse response1 = new ProcessResponse();
                    
                    response1.RequestId = _repo.GenerateId();
                    response1.PackagingAndDeliveryCharge = cost;
                    //response1.DateOfDelivery = DateTime.Now.Date.AddDays(5);
                    if (processRequest.ComponentType == "Integral")
                    {
                       
                        response1.ProcessingCharge = 500;
                        response1.DateOfDelivery = DateTime.Now.Date.AddDays(5);
                        
                    }
                    else
                    {
                        
                        response1.ProcessingCharge = 300;
                        response1.DateOfDelivery = DateTime.Now.Date.AddDays(2);
                    }                    
                    
                    return Ok(response1);
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [HttpPost("CompleteProcessing")]        
        public ActionResult<string> CompleteProcessing(ProcessFinalResponse paymentDTO)
        {
            
            try
            {                
                _repo.AddCompleteProcess(paymentDTO);
                return Ok("Processed Successfully");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
    }
}
