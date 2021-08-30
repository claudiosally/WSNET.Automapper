using FluentValidation.Results;
using System.Collections.Generic;

namespace WSNET.Automapper.Domain.Services.Interface
{
    public interface INotification
    {
        void AddFailure(ValidationFailure validationFailure);
        void AddFailures(IEnumerable<ValidationFailure> validationFailures);
        IEnumerable<ValidationFailure> GetFailures();
        bool HasNotifications();
    }
}
