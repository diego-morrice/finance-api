namespace Finance.Common.Events.Interfaces
{
    public interface IErrorEvent : IEvent
    {
        string Message {get;}  
        string Code {get;}
        object[] Data {get;}         
    }
}