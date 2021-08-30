using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using WSNET.Automapper.Domain.Services.Interface;

namespace WSNET.Automapper.Domain.Services
{
    public class Notification : INotification
    {
        private readonly ICollection<ValidationFailure> _failures;

        public Notification()
        {
            this._failures = new List<ValidationFailure>();
        }

        public void AddFailures(IEnumerable<ValidationFailure> validationFailures)
        {
            foreach (var failure in validationFailures)
                _failures.Add(failure);
        }

        public void AddFailure(ValidationFailure validationFailure) => _failures.Add(validationFailure);

        public bool HasNotifications() => GetFailures().Any();

        public IEnumerable<ValidationFailure> GetFailures() => _failures;

    }
}
