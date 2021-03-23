using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperityChallenge.Models
{
    public class EventTypeModel
    {
        [DisplayName("Event")]  // display name for label
        public string EventTypeInput { get; set; }
    }
}
