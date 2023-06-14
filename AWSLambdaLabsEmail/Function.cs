using Amazon.Lambda.Core;
using AWSLambdaLabsEmail.Helpers;
using AWSLambdaLabsEmail.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaLabsEmail;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<string> FunctionHandler(ModelEmail input, ILambdaContext context)
    {
        HelperMail helper = new HelperMail();
        await helper.SendMailAsync(input.Email, input.Asunto, input.Cuerpo);
        return "Mensaje enviado correctamente";
    }
}
