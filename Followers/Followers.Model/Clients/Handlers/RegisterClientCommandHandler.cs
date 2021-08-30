using System.Threading.Tasks;
using FluentValidation;
using Followers.Model.Clients.Dto;
using Followers.Model.MappingConfigs;
using Mapster;
using Microsoft.Extensions.Logging;
using Utilities.MediatR.Extensions.Commands;
using Utilities.MediatR.Extensions.Rules;

namespace Followers.Model.Clients.Handlers
{
    public class RegisterClientCommandHandler : CommandHandler<RegisterClientCommand, ClientData>
    {
        private IClientsManager ClientsManager { get; }
        
        public RegisterClientCommandHandler(ILogger<RegisterClientCommandHandler> logger, 
            IRequestRuleProvider ruleProvider,
            IClientsManager clientsManager) 
            : base(logger, ruleProvider)
        {
            ClientsManager = clientsManager;
        }
        
        protected override async Task<ClientData> ProcessBase()
        {
            var result = await ClientsManager.RegisterClient(Request.RegisterClientRequest.Name);
            return result.Adapt<ClientData>(FollowersMapping.TypeAdapterConfiguration);
        }

        protected override InlineValidator<RegisterClientCommand> Validator
        {
            get
            {
                var validator = new InlineValidator<RegisterClientCommand>();
                validator.RuleFor(q => q.RegisterClientRequest.Name).Length(1, 64);
                return validator;
            }
        }
    }
}