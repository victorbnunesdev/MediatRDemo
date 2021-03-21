using Newtonsoft.Json;
using Scheduler.Domain.Core;
using Scheduler.Domain.Core.Events;
using Scheduler.Infra.Data.Repository.EventSourcing;

namespace Scheduler.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            // Using Newtonsoft.Json because System.Text.Json
            // is a sad joke and far to be considered "Done"
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "_user.Name ?? _user.GetUserEmail()");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}