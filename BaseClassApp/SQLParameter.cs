namespace BaseClassApp
{
    public class SQLParameter
    {
        public string Name { get; }

        public object Value { get; set; }

        public SQLParameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString() => string.Format("{0}: {1}", (object)this.Name, this.Value);
    }
}
