using ConversionService.Core.Enums;

namespace ConversionService.Core.Dtos.Response
{
    public class CommonResponse
    {
        public static ApiCommonResponse Send(ResponseCodes code, object payload = null, string message = "")
        {
            return new ApiCommonResponse
            {
                responseCode = ((int)code).ToString().Length == 1 ? $"0{(int)code}" : ((int)code).ToString(),
                responseData = payload,
                responseMsg = string.IsNullOrEmpty(message) ? code.ToString() : message
            };
        }
    }
}
