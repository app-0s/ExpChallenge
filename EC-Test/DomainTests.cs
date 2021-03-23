using NUnit.Framework;
using ExperityChallenge.DomainLogic;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

namespace EC_Test
{
    public class DomainTests
    {
        private IExperityEvents _experityEvents;

        [SetUp]
        public void Setup()
        {
            _experityEvents = new ExperityEvents();
        }

        [Test]
        /// <summary>
        /// Calls register method
        /// </summary>
        public async Task RegisterTest()
        {

            var events = await _experityEvents.Register();

            StringBuilder sb = new StringBuilder();

            // Compile string    
            foreach (var ev in events)
            {
                if (ev.Number % 15 == 0 && ev.StringRepresentation != "&quot;Register Patient&quot;")   // test only for multiples of 3 & 5 (15)
                {
                    Assert.Fail("Output for multiple of 3 & 5 is incorrect");
                }
                else if(ev.Number % 3 == 0 && !(ev.Number % 5 == 0) && ev.StringRepresentation != "&quot;Register&quot;")   // test for only multiples of 3
                {
                    Assert.Fail("Output for multiple of 3 is incorrect");
                }
                else if (ev.Number % 5 == 0 && !(ev.Number % 3 == 0) && ev.StringRepresentation != "&quot;Patient&quot;") // check for only multiples of 3
                {
                    Assert.Fail("Output for multiple of 5 is incorrect");
                }

                sb.Append($"{ev.StringRepresentation} ");
            }

            if(events.Count > 0) {
                Console.WriteLine(sb.ToString());
                Assert.Pass();
            }
            else
                Assert.Fail("Register string collection was not built");
            
            
        }

        [Test]
        /// <summary>
        /// Calls diagnose method
        /// </summary>
        public async Task DiagnoseTest()
        {

            var events = await _experityEvents.Diagnose();
            StringBuilder sb = new StringBuilder();
                 

            foreach (var ev in events)
            {
                if (ev.Number % 14 == 0 && ev.StringRepresentation != "&quot;Diagnose Patient&quot;")   // test only for multiples of 2 & 7 (14)
                {
                    Assert.Fail("Output for multiple of 2 & 7 is incorrect");
                }
                else if (ev.Number % 2 == 0 && !(ev.Number % 7 == 0) && ev.StringRepresentation != "&quot;Diagnose&quot;")   // test for only multiples of 2
                {
                    Assert.Fail("Output for multiple of 2 is incorrect");
                }
                else if (ev.Number % 7 == 0 && !(ev.Number % 2 == 0) && ev.StringRepresentation != "&quot;Patient&quot;") // check for only multiples of 7
                {
                    Assert.Fail("Output for multiple of 7 is incorrect");
                }

                sb.Append($"{ev.StringRepresentation} ");
            }



            if (events.Count > 0)
            {
                Console.WriteLine(sb.ToString());
                Assert.Pass();
            }
            else
                Assert.Fail("Diagnose string collection was not built");

        }

    }
}