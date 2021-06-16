using Camunda.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CamundaExternalServiceTest.Handlers
{
    [HandlerTopics("ExternalTestTopic", LockDuration = 10000)]
    public class ExternalTestHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);

            return new CompleteResult
            {
                Variables = new Dictionary<string, Variable>
                {
                    ["MESSAGE"] = Variable.String("Hello World!")
                }
            };
           
        }
    }
}
