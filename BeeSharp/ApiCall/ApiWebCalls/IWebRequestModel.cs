namespace BeeSharp.ApiCall.ApiWebCalls
{
    public interface IWebRequestModel
    {
        public string RawRequest { get; set; }
        public string RawResponse { get; set; }
        public string NodeUrl { get; set; }
    }
}