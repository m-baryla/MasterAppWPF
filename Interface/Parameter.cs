namespace Interface
{
    public class Parameter
    {
        public string Name { get; }

        public object Value { get; set; }

        public Parameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString() => string.Format("{0}: {1}", (object)this.Name, this.Value);
    }
}
