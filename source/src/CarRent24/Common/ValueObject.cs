namespace CarRent24.Common
{
    public abstract class ValueObject : IEquatable<ValueObject?>
    {
        protected ValueObject() { }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj as ValueObject);
        }

        public override int GetHashCode()
        {
            HashCode hashcode = default;
            foreach (var obj in EqualityComponents)
            {
                hashcode.Add(obj);
            }
            return hashcode.ToHashCode();
        }

        public bool Equals(ValueObject? other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return EqualityComponents.SequenceEqual(other.EqualityComponents);
        }

        // implement with yield
        protected abstract IEnumerable<object?> EqualityComponents { get; }
    }
}