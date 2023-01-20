using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Client.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<bool>
    {
        public CreateClientDto CreateClientDto { get; set; }
    }
}
