using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Encoding;
using URLShortener.Repository;

namespace Tests
{
    public class ShortUrlEncoderTests
    {
        IShortUrlEncoder _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new ShortUrlEncoder();
        }

        [Test]
        public void CanGenerateUniqueIds()
        {
            int samples = 100;

            HashSet<string> ids = new HashSet<string>();

            for (int i = 0; i < samples; i++)
            {
                ids.Add(_uut.GetNextSquid());
            }

            ids.Count.ShouldBe(samples);
        }

        [Test]
        public void IsReproduceable()
        {
            int samples = 100;

            HashSet<string> ids = new HashSet<string>();
            for (int i = 0; i < samples; i++)
            {
                ids.Add(_uut.GetNextSquid());
            }

            _uut = new ShortUrlEncoder();
            HashSet<string> idsSecond = new HashSet<string>();
            for (int i = 0; i < samples; i++)
            {
                idsSecond.Add(_uut.GetNextSquid());
            }


            ids.ShouldBeEquivalentTo(idsSecond);
        }

        [Test]
        public void CanBeOffset()
        {
            int samples = 50;
            int offset = 50;

            for (int i = 0; i < offset; i++)
                _uut.GetNextSquid();

            HashSet<string> ids = new HashSet<string>();
            for (int i = 0; i < samples; i++)
            {
                ids.Add(_uut.GetNextSquid());
            }

            _uut = new ShortUrlEncoder(offset);
            HashSet<string> idsSecond = new HashSet<string>();
            for (int i = 0; i < samples; i++)
            {
                idsSecond.Add(_uut.GetNextSquid());
            }


            ids.ShouldBeEquivalentTo(idsSecond);
        }
    }
}
