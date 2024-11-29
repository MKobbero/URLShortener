using Sqids;

namespace URLShortener.Encoding
{
    public class ShortUrlEncoder : IShortUrlEncoder
    {
        private SqidsEncoder<int> _squids;
        private int currentId = 0;
        public ShortUrlEncoder(int id = 0)
        {
            _squids = new SqidsEncoder<int>(new SqidsOptions()
            {
                MinLength = 0,
            });

            currentId = id;
        }

        public string GetNextSquid()
        {
            return _squids.Encode(currentId++);
        }
    }
}
