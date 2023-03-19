

namespace Course.Service.Utilities {
    public class ResponseObject {
        public ResponseObject()
        {
            this.Data = null;
            this.StatusCode=404;
            this.Message = "Falied Request";
        }
        public object Data { get; set; } 
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
