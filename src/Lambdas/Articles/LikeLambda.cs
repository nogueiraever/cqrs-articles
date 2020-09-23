using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambdas
{
    public class LikeLambda
    {
        public void Function(SNSEvent snsEvent, ILambdaContext lambdaContext)
        {
            foreach (var record in snsEvent.Records)
            {
                lambdaContext.Logger.LogLine(record.Sns.Message);
            }
        }
    }
}