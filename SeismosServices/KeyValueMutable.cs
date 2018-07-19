namespace SeismosServices
{
    public class KeyValueMutable<TKey, TVal>
    {
        public TKey Id { get; set; }
        public TVal Text { get; set; }

        public KeyValueMutable() { }

        public KeyValueMutable(TKey key, TVal val)
        {
            this.Id = key;
            this.Text = val;
        }
    }
}