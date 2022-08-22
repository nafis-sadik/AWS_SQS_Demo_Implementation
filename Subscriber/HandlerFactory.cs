using Models;
using System.Text.Json;

namespace Subscriber
{
    public class HandlerFactory
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public HandlerFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _scopeFactory = serviceScopeFactory;
        }

        private readonly Dictionary<string, Type> _modelTypeMapping = new Dictionary<string, Type>
        {
            { nameof(User), typeof(User) },
            { nameof(CabinFilters), typeof(CabinFilters) },
            { nameof(Cabin), typeof(Cabin) },
        };

        private readonly Dictionary<string, Type> _handlerTypeMappings = new Dictionary<string, Type>
        {
            { nameof(User), typeof(UserHandler) },
        };

        public async Task invokeHandler(string msgType, string message)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var typeNames = msgType.Split('.');
                var handlerType = _handlerTypeMappings[typeNames[^1]];
                var mth = handlerType.GetMethod("HandleAsync");
                var handler = ActivatorUtilities.CreateInstance(scope.ServiceProvider, handlerType);
                //mth?.Invoke(handler, new[] { Activator.CreateInstance(_modelTypeMapping[typeNames[^1]]) } );
                mth?.Invoke(handler, new[] { JsonSerializer.Deserialize(message, _modelTypeMapping[typeNames[^1]]) });
            }
        }

        public bool canHandle(IBaseModel message)
        {
            var typeNames = message.MessageTypeName.Split('.');
            var handlerType = _handlerTypeMappings[typeNames[^1]];
            var modelType = _modelTypeMapping[typeNames[^1]];
            return modelType != null && handlerType != null;
        }
    }
}
