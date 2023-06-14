using Amazon.S3.Model;
using Amazon.S3;
using MvcCorePersonajesAWSLabs.Models;

namespace MvcCorePersonajesAWSLabs.Services
{
    public class ServiceStorageS3
    {
        private string BucketName;

        private IAmazonS3 ClientS3;
        public ServiceStorageS3(KeysModel model
            , IAmazonS3 clientS3)
        {
            this.BucketName = model.S3BucketName;
            this.ClientS3 = clientS3;
        }

        //COMENZAMOS SUBIENDO FICHEROS AL BUCKET
        //NECESITAMOS FileName, Stream y un Key/Value
        public async Task<bool>
            UploadFileAsync(string fileName, Stream stream)
        {
            PutObjectRequest request = new PutObjectRequest
            {
                InputStream = stream,
                Key = fileName,
                BucketName = this.BucketName
            };
            //DEBEMOS OBTENER UNA RESPUESTA CON EL MISMO TIPO 
            //DE REQUEST
            PutObjectResponse response = await
                this.ClientS3.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
