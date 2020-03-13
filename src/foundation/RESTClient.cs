namespace Landsknecht.src.foundation
{
    public class RESTClient
    {
        private string targetUrl;

        public RESTClient target(string url){
            this.targetUrl = url;
            return this;
        }
    }
}