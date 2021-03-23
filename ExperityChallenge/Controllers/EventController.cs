using ExperityChallenge.DomainLogic;
using ExperityChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperityChallenge.Controllers
{
    [Route("[Controller]")]
    public class EventController : Controller
    {
        private readonly IExperityEvents _experityEvents;

        /// <summary>
        /// Sets properties of controller
        /// </summary>
        /// <param name="events">Bound implementation of ExperityEvents class</param>
        public EventController(IExperityEvents events)
        {
            _experityEvents = events;
        }

        [HttpGet("register")]
        public async Task<IActionResult> GetRegistration()
        {
            try
            {
                // call register method of ExperityEvents implementation
                var regStrs = await _experityEvents.Register();

                return PartialView("EventResultsPartial", regStrs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving data: {ex.Message}");
            }
            
        }

        [HttpGet("diagnose")]
        public async Task<IActionResult> GetDiagnosis()
        {
            try
            {
                // call diagnose method of ExperityEvents implementation
                var diagStrs = await _experityEvents.Diagnose();

                return PartialView("EventResultsPartial", diagStrs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving data: {ex.Message}");
            }
        }

        [HttpPost("GetEventResult")]
        public async Task<IActionResult> GetEventResult(EventTypeModel eventInput)
        {
            IList<EventResultModel> results = new List<EventResultModel>();

            try
            {
                // compare input against types
                if (eventInput.EventTypeInput == EventTypes.REGISTER_EVENT)
                {
                    // call register method of ExperityEvents implementation
                    results = await _experityEvents.Register();
                }
                else if (eventInput.EventTypeInput == EventTypes.DIAGNOSE_EVENT)
                {
                    // call diagnose method of ExperityEvents implementation
                    results = await _experityEvents.Diagnose();
                }

                return PartialView("EventResultsPartial", results);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving data: {ex}");
            }
            
        }
    }
}
