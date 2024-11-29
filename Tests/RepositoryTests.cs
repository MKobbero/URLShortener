using Shouldly;
using URLShortener.Repository;

namespace Tests
{
    public class RepositoryTests
    {
        IUrlRepository _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new UrlRepository();
        }

        [Test]
        public void CanAdd()
        {
            var added = _uut.Add("long", "short");

            added.ShouldBeTrue();
        }

        [Test]
        public void CantAdd()
        {
            _uut.Add("long", "short");
            
            var added = _uut.Add("long", "short");

            added.ShouldBeFalse();
        }

        [Test]
        public void CanGetLongUrl()
        {
            _uut.Add("short", "long");

            _uut.GetLongUrl("short").ShouldBe("long");
        }

        [Test]
        public void CantGetLongUrl()
        {
            _uut.Add("long", "something");

            _uut.GetLongUrl("short").ShouldBeNull();
        }
    }
}