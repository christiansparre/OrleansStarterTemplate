namespace OrleansStarterTemplate.Grains.Interfaces;

[GenerateSerializer]
public record HelloMessage([property: Id(0)] string Message, [property: Id(1)] DateTimeOffset Timestamp);