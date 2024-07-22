using RideHubb.Domain.Abstractions;

namespace RideHubb.Domain.Users.Events;

public record UserRegisterDomainEvent(Guid IdUser) : IDomainEvent;