using ExperityChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperityChallenge.DomainLogic
{
    public class ExperityEvents : IExperityEvents
    {
        /// <summary>
        /// builds string collection for numbers 1 - 100, with special strings created for multiples of 3, 5, and both 3 & 5
        /// </summary>
        /// <returns></returns>
        public async Task<IList<EventResultModel>> Register()
        {
            // call BuildStr to create collection
            IList<EventResultModel> registerCollection = await BuildStr("Register", "Patient", 3, 5);

            return registerCollection;
            
        }

        /// <summary>
        /// builds string collection for numbers 1 - 100, with special strings created for multiples of 2, 7, and both 2 & 7
        /// </summary>
        /// <returns></returns>
        public async Task<IList<EventResultModel>> Diagnose()
        {
            // call BuildStr to create collection
            IList<EventResultModel> diagnoseCollection = await BuildStr("Diagnose", "Patient", 2, 7);

            return diagnoseCollection;
        }

        /// <summary>
        /// Builds string collection based on multiples and strings passed as parameters
        /// </summary>
        /// <param name="contentStrA">Word to be surrounded by quotes</param>
        /// <param name="contentStrB">Word to be surrounded by quotes</param>
        /// <param name="mul1">First multiple</param>
        /// <param name="mul2">Second multiple</param>
        /// <returns></returns>
        private async Task<IList<EventResultModel>> BuildStr(string contentStrA, string contentStrB, int mul1, int mul2)
        {
            IList<EventResultModel> strCollection = new List<EventResultModel>();

            await Task.Run(() =>
            {
                
                for (int i = 1; i <= 100; i++)
                {
                    if (i % (mul1 * mul2) == 0) // multiples of both mul1 and mul2
                    {
                        EventResultModel newModel = new EventResultModel();
                        newModel.Number = i;
                        newModel.StringRepresentation = $"&quot;{contentStrA} {contentStrB}&quot;";

                        strCollection.Add(newModel);
                    }
                    else if (i % mul1 == 0)
                    {
                        EventResultModel newModel = new EventResultModel();
                        newModel.Number = i;
                        newModel.StringRepresentation = $"&quot;{contentStrA}&quot;";

                        strCollection.Add(newModel);
                    }
                    else if (i % mul2 == 0)
                    {
                        EventResultModel newModel = new EventResultModel();
                        newModel.Number = i;
                        newModel.StringRepresentation = $"&quot;{contentStrB}&quot;";

                        strCollection.Add(newModel);
                    }
                    else
                    {
                        EventResultModel newModel = new EventResultModel();
                        newModel.Number = i;
                        newModel.StringRepresentation = i.ToString();

                        strCollection.Add(newModel);
                    }

                    
                }
            });

            return strCollection;
        }
    }
}
