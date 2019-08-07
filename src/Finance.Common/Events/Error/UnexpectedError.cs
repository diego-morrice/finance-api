using Finance.Common.Events.Interfaces;

namespace Finance.Common.Events.Error
{
    public class UnexpectedError : IErrorEvent
    {

        public string Message { get; }

        public string Code { get; }

        public object[] Data { get; }

        protected UnexpectedError()
        {

        }

        public UnexpectedError(string code, string message, object[] data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }
    }
}