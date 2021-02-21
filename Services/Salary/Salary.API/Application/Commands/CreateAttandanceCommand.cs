using MediatR;
using System.Runtime.Serialization;

namespace FADY.Services.Salary.API.Application.Commands
{
    [DataContract]
    public class CreateAttandanceCommand : IRequest<bool>
    {
        [DataMember]
        public string Days { get; private set; }

        public CreateAttandanceCommand()
        {

        }

        public CreateAttandanceCommand(string days):this()
        {
            Days = days;
        }
    }
   
}
