using System.Net;

namespace BasePerson.Application.Exceptions
{
    public abstract class EntityValidationException : Exception
    {
        public EntityValidationException(string message) : base(message)
        {

        }
        public abstract HttpStatusCode StatusCode { get; }

    }
}
