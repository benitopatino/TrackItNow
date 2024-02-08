namespace TrackItNow.Domain.Base;

internal class FixedEntity: BaseEntity<byte>
{
    public string Name { get; set; }
}