namespace BuisnessLayer.Exceptions
{
    public class ExceptionWhileAdding : Exception
    {
        public ExceptionWhileAdding(string Message) : base(Message)
        {
             
        }
    }

    public class ExceptionWhileUpdating : Exception
    {
        public ExceptionWhileUpdating(string Message) : base(Message)
        {

        }
    }

    public class ExceptionWhileFetching : Exception
    {
        public ExceptionWhileFetching(string Message) : base(Message)
        {

        }
    }
}
